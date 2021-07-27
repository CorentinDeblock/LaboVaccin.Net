using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text;
using VaccineCenter.DAL.Model;

namespace VaccineCenter.DAL.Generator
{
    public class Generator
    {
        public static ModelBuilder builder { get; set; }

        public static Schedule GenerateSchedule(int id, Center center, int hourStart, int hourEnd)
        {
            Schedule schedule = new Schedule
            {
                Id = id,
                Name = "Default",
                OpenAt = new DateTime(1, 1, 1, hourStart, 0, 0),
                CloseAt = new DateTime(1, 1, 1, hourEnd, 0, 0),
                CenterId = center.Id
            };

            builder.Entity<Schedule>().HasData(schedule);

            return schedule;
        }

        public static InActivity GenerateInActivity(int id, DateTime OpenAt,DateTime CloseAt)
        {
            InActivity inActivity = new InActivity
            {
                Id = 1,
                Opening = DateTime.Now,
                Closing = DateTime.Now.AddYears(1)
            };

            builder.Entity<InActivity>().HasData(inActivity);

            return inActivity;
        }

        public static VaccinInfo GenerateVaccinInfo(int id, Vaccin vaccin, Center center)
        {
            VaccinInfo info = new VaccinInfo
            {
                Id = id,
                QuantityAvailable = 0,
                VaccinId = vaccin.Id,
                CenterId = center.Id
            };

            builder.Entity<VaccinInfo>().HasData(info);

            return info;
        }

        public static Workspace GenerateWorkspace(int id,Staff staff,Center center,string name,string address)
        {
            Workspace workspace = new Workspace
            {
                Id = id,
                Address = address,
                Name = name,
                CenterId = center.Id
            };
            builder.Entity<Workspace>().HasData(workspace);

            return workspace;
        }

        public static Staff GenerateStaff(int id, int workspaceId, string email, string password, string firstName, string lastName, DAL.Enum.StaffGrade Grade, string INAMI)
        {
            Staff staff = new Staff
            {
                Id = id,
                Grade = Grade,
                INAMI = INAMI,
                Responsible = true,
                AccountId = GenerateAccount(id, email, password, firstName, lastName).Id,
                WorkspaceId = workspaceId
            };
            builder.Entity<Staff>().HasData(staff); 

            return staff;
        }

        public static Account GenerateAccount(int id, string email, string password,string firstName, string lastName)
        {
            Account acc = new Account
            {
                Id = id,
                Email = email,
                Password = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password)),
                FirstName = firstName,
                LastName = lastName,
                AccountTypeId = GenerateAccountType(id).Id
            };

            builder.Entity<Account>().HasData(acc);
            return acc;
        }

        public static AccountType GenerateAccountType(int id)
        {
            AccountType accType = new AccountType
            {
                Id = id,
                IsStaff = true,
                IsPatient = false
            };

            builder.Entity<AccountType>().HasData(accType);
            return accType;
        }
    }
}
