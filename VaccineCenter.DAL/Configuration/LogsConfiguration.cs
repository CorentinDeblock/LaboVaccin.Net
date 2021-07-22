using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaccineCenter.DAL.Model;

namespace VaccineCenter.DAL.Configuration
{
    public class LogsConfiguration : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder
                .HasOne(l => l.VaccinInfo)
                .WithMany(v => v.Logs)
                .HasForeignKey(l => l.VaccinInfoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
