using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using VaccineCenter.DAL.Configuration;
using VaccineCenter.DAL.Generator;
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
        private ModelBuilder ModelBuilder { get; set; }

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

            ModelBuilder = modelBuilder;

            Generator.builder = modelBuilder;

            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new VaccinConfiguration());
            modelBuilder.ApplyConfiguration(new InActivityConfiguration());
            modelBuilder.ApplyConfiguration(new PlanificationConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new LogsConfiguration());
            modelBuilder.ApplyConfiguration(new WorkspaceConfiguration());

            Vaccin VaccinFirst = new Vaccin { Id = 1, Name = "Pfizer" };
            Vaccin VaccinSecond = new Vaccin { Id = 2, Name = "Moderna" };
            Vaccin VaccinThird = new Vaccin { Id = 3, Name = "Aztrazeneka" };

            Staff staff = Generator.GenerateStaff(
                1,
                1,
                "roger@gmail.com",
                "roger",
                "Roger",
                "LaMontagne",
                DAL.Enum.StaffGrade.Doctor,
                "1454548478794692"
            );

            GenerateVaccin(new Provider
            {
                Id = 1,
                Address = "Rue de la montagne, 6",
                Name = "Biontech"
            }, VaccinFirst, VaccinSecond);

            GenerateVaccin(new Provider
            {
                Id = 2,
                Address = "Rue de saint pagne, 89",
                Name = "Johnson & Johnson"
            }, VaccinThird);

            Center center = new Center
            {
                Id = 1,
                Address = "Rue des flocons, 6, 6200, Chaleroi",
                Name = "Vaccine toi",
                InActivityId = Generator.GenerateInActivity(1,DateTime.Now, DateTime.Now.AddYears(1)).Id
            };

            GenerateCenter(center);
            Generator.GenerateWorkspace(1, staff, center, "Default", center.Address);

            Generator.GenerateVaccinInfo(1, VaccinFirst, center);
            Generator.GenerateVaccinInfo(2, VaccinSecond, center);
            Generator.GenerateVaccinInfo(3, VaccinThird, center);

            Generator.GenerateSchedule(1,center, 9, 18);
        }

        private void GenerateCenter(params Center[] center)
        {
            foreach(Center c in center)
            {
                ModelBuilder.Entity<Center>().HasData(c);
            }
        }

        private void GenerateVaccin(Provider provider, params Vaccin[] vaccin)
        {
            ModelBuilder.Entity<Provider>().HasData(provider);

            foreach (Vaccin v in vaccin)
            {
                v.ProviderId = provider.Id;
                ModelBuilder.Entity<Vaccin>().HasData(v);
            }
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
