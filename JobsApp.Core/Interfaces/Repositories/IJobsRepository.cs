using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JobsApp.Core.Models.Entities;
using JobsApp.Core.Models.FilterModels;
using JobsApp.Core.Models.ViewModels;

namespace JobsApp.Core.Interfaces.Repositories
{
    public interface IJobsRepository : IRepositoryBase<Job>
    {
        Task<List<JobViewModel>> GetJobsAsync(JobFilterModel filter);
        Task<JobDetailsModel> GetJobAsync(int id);
    }
}
