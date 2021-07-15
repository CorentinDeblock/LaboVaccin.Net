using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaccineCenter.Model;

namespace VaccineCenter.DAL.Configuration
{
    public class PlanificationConfiguration : IEntityTypeConfiguration<Planification>
    {
        public void Configure(EntityTypeBuilder<Planification> builder)
        {
            builder
                .HasOne(pl => pl.Patient)
                .WithMany(p => p.Planification)
                .HasForeignKey(pl => pl.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(pl => pl.Center)
                .WithMany(c => c.Planifications)
                .HasForeignKey(pl => pl.CenterId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(pl => pl.Vaccin)
                .WithMany(v => v.Planifications)
                .HasForeignKey(pl => pl.VaccinId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
