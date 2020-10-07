using System;
using System.Collections.Generic;
using System.Text;
using JobsApp.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobsApp.Core.Models.Configurations
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasKey(j => j.Id);

            builder.Property(j => j.Id).ValueGeneratedOnAdd();

            builder.HasOne(j => j.Company)
                .WithMany(c => c.Jobs);

            builder.HasOne(j => j.Category);

            builder.HasOne(j => j.Location);
        }
    }
}
