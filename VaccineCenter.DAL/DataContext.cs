using Microsoft.EntityFrameworkCore;
using VaccineCenter.DAL.Configuration;
using VaccineCenter.DAL.Model;

namespace VaccineCenter
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-C1EJAU3;Database = LaboVaccin;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new VaccinConfiguration());
            modelBuilder.ApplyConfiguration(new InActivityConfiguration());
            modelBuilder.ApplyConfiguration(new PlanificationConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new LogsConfiguration());
        }
        public DbSet<Communication> Communications { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Planification> Planifications { get; set; }
        public DbSet<InjectionTaken> InjectionTakens { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Vaccin> Vaccins { get; set; }
        public DbSet<VaccinInfo> VaccinInfos { get; set; }
        public DbSet<Workspace> Workspaces { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<InActivity> InActivitties { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<Provider> Providers { get; set; }
    }
}
