using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.IO;
using VaccineCenter.DAL.Configuration;
using VaccineCenter.DAL.Model;

namespace VaccineCenter
{
    internal class JSONDbConfig
    {
        public string SQL { get; }
    }
    internal class JSONConfig
    {
        public JSONDbConfig ConnectionStrings { get; }
    }

    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                 .AddJsonFile("appsettings.json", optional: false)
                 .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
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
