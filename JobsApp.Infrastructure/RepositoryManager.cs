using System;
using System.Collections.Generic;
using System.Text;
using JobsApp.Core.Interfaces;
using JobsApp.Core.Interfaces.Repositories;
using JobsApp.Core.Models;
using JobsApp.Infrastructure.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace JobsApp.Infrastructure
{
    public class RepositoryManager : IRepositoryManager
    {
        private AppDbContext context;
        private ICategoriesRepository _categories;
        private ILocationsRepository _locations;
        private ICompaniesRepository _companies;
        private IJobsRepository _jobs;
        private IMemoryCache _cache;

        public RepositoryManager(IMemoryCache cache, AppDbContext context)
        {
            this.context = context;
            _cache = cache;
        }

        public ICategoriesRepository Categories
        {
            get
            {

                if (_categories == null)
                {
                    _categories = new CategoriesRepository(context);
                }
                return _categories;
            }
        }

        public ILocationsRepository Locations
        {
            get
            {

                if (_locations == null)
                {
                    _locations = new LocationsRepository(context);
                }
                return _locations;
            }
        }

        public ICompaniesRepository Companies
        {
            get
            {

                if (_companies == null)
                {
                    _companies = new CompaniesRepository(context);
                }
                return _companies;
            }
        }
        public IJobsRepository Jobs
        {
            get
            {

                if (_jobs == null)
                {
                    _jobs = new JobsRepository(_cache, context);
                }
                return _jobs;
            }
        }
    }
}
