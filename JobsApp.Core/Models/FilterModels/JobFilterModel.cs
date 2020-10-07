using System;
using System.Collections.Generic;
using System.Text;
using JobsApp.Core.Models.Enums;

namespace JobsApp.Core.Models.FilterModels
{
    public class JobFilterModel
    {
        public int? CategoryId { get; set; }
        public int? LocationId { get; set; }
        public string SearchText { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public List<EmploymentType> EmploymentTypes { get; set; }
    }
}
