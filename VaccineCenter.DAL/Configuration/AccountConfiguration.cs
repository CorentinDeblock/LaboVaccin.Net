using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaccineCenter.DAL.Model;

namespace VaccineCenter.DAL.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder
                .HasIndex(a => a.Email)
                .IsUnique();

            builder
                .HasOne(a => a.AccountType)
                .WithOne(a => a.Account)
                .HasForeignKey<Account>(a => a.AccountTypeId);
        }
    }
}
