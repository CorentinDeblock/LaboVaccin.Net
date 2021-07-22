using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaccineCenter.DAL.Model;

namespace VaccineCenter.DAL.Configuration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder
                .HasOne(p => p.Communication)
                .WithOne(c => c.Patient)
                .HasForeignKey<Patient>(p => p.CommunicationId);
        }
    }
}
