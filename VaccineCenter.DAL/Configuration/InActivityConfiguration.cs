using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaccineCenter.Model;

namespace VaccineCenter.DAL.Configuration
{
    public class InActivityConfiguration : IEntityTypeConfiguration<InActivity>
    {
        public void Configure(EntityTypeBuilder<InActivity> builder)
        {
            builder
                .HasOne(ia => ia.Center)
                .WithOne(c => c.InActivity)
                .HasForeignKey<Center>(c => c.InActivityId);
        }
    }
}
