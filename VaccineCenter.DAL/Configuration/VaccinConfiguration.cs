using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VaccineCenter.DAL.Model;

namespace VaccineCenter.DAL.Configuration
{
    public class VaccinConfiguration : IEntityTypeConfiguration<Vaccin>
    {
        public void Configure(EntityTypeBuilder<Vaccin> builder)
        {
            builder
                .HasIndex(v => v.Name)
                .IsUnique();
        }
    }
}
