using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineCenter.DAL.Model;

namespace VaccineCenter.DAL.Configuration
{
    class WorkspaceConfiguration : IEntityTypeConfiguration<Workspace>
    {
        public void Configure(EntityTypeBuilder<Workspace> builder)
        {
            builder
                .HasMany(w => w.Staffs)
                .WithOne(s => s.Workspace)
                .HasForeignKey(s => s.WorkspaceId);
        }
    }
}
