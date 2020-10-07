using System;
using System.Collections.Generic;
using System.Text;
using JobsApp.Core.Models.Enums;

namespace JobsApp.Core.Models.Entities
{
    public class Job : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Bookmarked { get; set; }
        public decimal? Salary { get; set; }
        public DateTime PostedDate { get; set; }
        public EmploymentType Type { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
