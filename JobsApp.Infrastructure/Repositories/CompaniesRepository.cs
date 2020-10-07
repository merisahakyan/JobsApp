using System;
using System.Collections.Generic;
using System.Text;
using JobsApp.Core.Interfaces.Repositories;
using JobsApp.Core.Models;
using JobsApp.Core.Models.Entities;

namespace JobsApp.Infrastructure.Repositories
{
    public class CompaniesRepository : RepositoryBase<Company>, ICompaniesRepository
    {
        public CompaniesRepository(AppDbContext context) : base(context)
        {

        }
    }
}
