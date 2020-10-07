using System;
using System.Collections.Generic;
using System.Text;
using JobsApp.Core.Interfaces.Repositories;

namespace JobsApp.Core.Interfaces
{
    public interface IRepositoryManager
    {
        ICategoriesRepository Categories { get; }
        ILocationsRepository Locations { get; }
        ICompaniesRepository Companies { get; }
        IJobsRepository Jobs { get; }
    }
}
