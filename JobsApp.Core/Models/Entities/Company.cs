using System;
using System.Collections.Generic;
using System.Text;

namespace JobsApp.Core.Models.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public List<Job> Jobs { get; set; }
    }
}
