using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobsApp.Core.Interfaces.Repositories;
using JobsApp.Core.Models;
using JobsApp.Core.Models.Entities;
using JobsApp.Core.Models.FilterModels;
using JobsApp.Core.Models.ViewModels;
using JobsApp.Core.StaticData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace JobsApp.Infrastructure.Repositories
{
    public class JobsRepository : RepositoryBase<Job>, IJobsRepository
    {
        private IMemoryCache _cache;
        public JobsRepository(IMemoryCache cache, AppDbContext context) : base(context)
        {
            _cache = cache;
        }

        public async Task<List<JobViewModel>> GetJobsAsync(JobFilterModel filter)
        {
            IQueryable<Job> jobs = Context.Jobs;
            var data = _cache.Get<List<Job>>(CacheKeys.JOBS);
            if (data != null && data.Any())
            {
                jobs = data.AsQueryable();
            }

            var query = (from j in jobs
                         join cat in Context.Categories on j.CategoryId equals cat.Id
                         join loc in Context.Locations on j.LocationId equals loc.Id
                         join com in Context.Companies on j.CompanyId equals com.Id
                         where (!filter.LocationId.HasValue || loc.Id == filter.LocationId)
                             && (!filter.CategoryId.HasValue || cat.Id == filter.CategoryId)
                             && (string.IsNullOrEmpty(filter.SearchText) || j.Title.ToLower().Contains(filter.SearchText.ToLower()))
                             && ((filter.EmploymentTypes == null || !filter.EmploymentTypes.Any()) || filter.EmploymentTypes.Contains(j.Type))
                         select new JobViewModel
                         {
                             Id = j.Id,
                             ImgUrl = com.LogoUrl,
                             PostedBy = com.Name,
                             PostedDate = j.PostedDate,
                             Location = loc.Name,
                             Type = j.Type,
                             Bookmarked = j.Bookmarked
                         }).Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize);
            return await query.ToListAsync();
        }

        public async Task<JobDetailsModel> GetJobAsync(int id)
        {
            var job = await GetSingleWithIncludeAsync<BaseEntity>(id, j => j.Location, j => j.Category, j => j.Company);
            return new JobDetailsModel
            {
                Id = job.Id,
                Description = job.Description,
                Location = job.Location.Name,
                PostedDate = job.PostedDate,
                Salary = job.Salary ?? 0,
                Type = job.Type,
                Bookmarked = job.Bookmarked,
                ImgUrl = job.Company.LogoUrl,
                PostedBy = job.Company.Name,
                PostedById = job.CompanyId
            };
        }
    }
}
