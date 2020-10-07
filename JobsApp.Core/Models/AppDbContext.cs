using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using JobsApp.Core.Models.Configurations;
using JobsApp.Core.Models.Entities;
using JobsApp.Core.Models.Enums;

namespace JobsApp.Core.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new JobConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());

            var categories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Development"
                },
                new Category
                {
                    Id = 2,
                    Name = "Management"
                }
            };

            var locations = new List<Location>
            {
                new Location
                {
                    Id = 1,
                    Name = "Armenia, Yerevan"
                }
            };

            modelBuilder.Entity<Location>().HasData(locations);
            modelBuilder.Entity<Category>().HasData(categories);

            var companies = new List<Company>
            {
                new Company
                {
                    Id=1,
                    Name = "Benivo"
                },
                new Company
                {
                    Id = 2,
                    Name = "PCS AM"
                }
            };

            modelBuilder.Entity<Company>().HasData(companies);

            var jobs = new List<Job>
            {
                new Job
                {
                    Id = 1,
                    Title = "Software Developer",
                    Description = "Seeking of .Net Developer",
                    PostedDate = DateTime.Now.AddDays(-1),
                    Type = EmploymentType.FullTime,
                    Bookmarked = false,
                    LocationId = 1,
                    CategoryId = 1,
                    CompanyId = 1
                },
                new Job
                {
                    Id = 2,
                    Title = "Senior Software Developer",
                    Description = "Seeking of Senior Developer",
                    PostedDate = DateTime.Now.AddDays(-5),
                    Type = EmploymentType.Contractor,
                    Bookmarked = false,
                    LocationId = 1,
                    CategoryId = 1,
                    Salary = 200000,
                    CompanyId = 1
                },
                new Job
                {
                    Id = 3,
                    Title = "Senior React Developer",
                    Description = "Seeking of Senior React Developer",
                    PostedDate = DateTime.Now.AddDays(-8),
                    Type = EmploymentType.Seasonal,
                    Bookmarked = false,
                    LocationId = 1,
                    CategoryId = 1,
                    CompanyId = 1
                },
                new Job
                {
                    Id = 4,
                    Title = ".Net Developer",
                    Description = "Seeking of .Net Developer",
                    PostedDate = DateTime.Now.AddDays(-7),
                    Type = EmploymentType.PartTime,
                    Bookmarked = true,
                    LocationId = 1,
                    CategoryId = 1,
                    Salary = 100000,
                    CompanyId = 2
                },
                new Job
                {
                    Id = 5,
                    Title = "CTO",
                    Description = "Seeking of CTO",
                    PostedDate = DateTime.Now.AddDays(-3),
                    Type = EmploymentType.Intern,
                    Bookmarked = false,
                    LocationId=1,
                    CategoryId = 2,
                    CompanyId = 2
                },
                new Job
                {
                    Id = 6,
                    Title = "Project Manager",
                    Description = "Seeking of Project Manager",
                    PostedDate = DateTime.Now.AddDays(-3),
                    Type = EmploymentType.FullTime,
                    Bookmarked = false,
                    LocationId=1,
                    CategoryId = 2,
                    CompanyId = 2
                }
            };

            modelBuilder.Entity<Job>().HasData(jobs);

            base.OnModelCreating(modelBuilder);
        }
    }
}
