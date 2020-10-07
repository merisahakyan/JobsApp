using System;
using System.Collections.Generic;
using System.Text;
using JobsApp.Core.Models.Enums;

namespace JobsApp.Core.Models.ViewModels
{
    public class JobDetailsModel
    {
        public int Id { get; set; }
        public int PostedById { get; set; }
        public string PostedBy { get; set; }
        public string Location { get; set; }
        public string ImgUrl { get; set; }
        public bool Bookmarked { get; set; }
        public DateTime PostedDate { get; set; }
        public EmploymentType Type { get; set; }
        public decimal Salary { get; set; }
        public string Description { get; set; }
    }
}
