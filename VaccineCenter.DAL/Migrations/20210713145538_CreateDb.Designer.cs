﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VaccineCenter;

namespace VaccineCenter.DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210713145538_CreateDb")]
    partial class CreateDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VaccineCenter.Model.Account", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountType")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MainAccountId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Password")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("VaccineCenter.Model.Center", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InActivityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResponsibleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InActivityId")
                        .IsUnique();

                    b.HasIndex("ResponsibleId");

                    b.ToTable("Centers");
                });

            modelBuilder.Entity("VaccineCenter.Model.InActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CenterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Closing")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Opening")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("InActivitties");
                });

            modelBuilder.Entity("VaccineCenter.Model.InjectionTaken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PlanificationsId")
                        .HasColumnType("int");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlanificationsId");

                    b.HasIndex("StaffId");

                    b.ToTable("InjectionTakens");
                });

            modelBuilder.Entity("VaccineCenter.Model.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CenterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LogType")
                        .HasColumnType("int");

                    b.Property<int>("LotId")
                        .HasColumnType("int");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CenterId");

                    b.HasIndex("LotId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("VaccineCenter.Model.Lot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("LotId")
                        .HasColumnType("bigint");

                    b.Property<int>("ProviderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.ToTable("Lots");
                });

            modelBuilder.Entity("VaccineCenter.Model.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CommunicationType")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("MedicationIndications")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("NationalRegistrationNumber")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("VaccineCenter.Model.Planification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CenterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("VaccinId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CenterId");

                    b.HasIndex("PatientId");

                    b.HasIndex("VaccinId");

                    b.ToTable("Planifications");
                });

            modelBuilder.Entity("VaccineCenter.Model.Provider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VaccinId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VaccinId");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("VaccineCenter.Model.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CenterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CloseAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OpenAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CenterId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("VaccineCenter.Model.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<byte[]>("INAMI")
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("WorkspaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("WorkspaceId");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("VaccineCenter.Model.Vaccin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CenterId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CenterId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Vaccins");
                });

            modelBuilder.Entity("VaccineCenter.Model.VaccinInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("QuantityAvailable")
                        .HasColumnType("bigint");

                    b.Property<int?>("VaccinId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VaccinId");

                    b.ToTable("VaccinInfos");
                });

            modelBuilder.Entity("VaccineCenter.Model.Workspace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CenterId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResponsibleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CenterId");

                    b.HasIndex("ResponsibleId");

                    b.ToTable("Workspaces");
                });

            modelBuilder.Entity("VaccineCenter.Model.Center", b =>
                {
                    b.HasOne("VaccineCenter.Model.InActivity", "InActivity")
                        .WithOne("Center")
                        .HasForeignKey("VaccineCenter.Model.Center", "InActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VaccineCenter.Model.Staff", "Responsible")
                        .WithMany()
                        .HasForeignKey("ResponsibleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InActivity");

                    b.Navigation("Responsible");
                });

            modelBuilder.Entity("VaccineCenter.Model.InjectionTaken", b =>
                {
                    b.HasOne("VaccineCenter.Model.Planification", "Planifications")
                        .WithMany()
                        .HasForeignKey("PlanificationsId");

                    b.HasOne("VaccineCenter.Model.Staff", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Planifications");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("VaccineCenter.Model.Log", b =>
                {
                    b.HasOne("VaccineCenter.Model.Center", "Center")
                        .WithMany("Log")
                        .HasForeignKey("CenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VaccineCenter.Model.Lot", "Lot")
                        .WithMany()
                        .HasForeignKey("LotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Center");

                    b.Navigation("Lot");
                });

            modelBuilder.Entity("VaccineCenter.Model.Lot", b =>
                {
                    b.HasOne("VaccineCenter.Model.Provider", "Provider")
                        .WithMany()
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("VaccineCenter.Model.Patient", b =>
                {
                    b.HasOne("VaccineCenter.Model.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("VaccineCenter.Model.Planification", b =>
                {
                    b.HasOne("VaccineCenter.Model.Center", "Center")
                        .WithMany("Planifications")
                        .HasForeignKey("CenterId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("VaccineCenter.Model.Patient", "Patient")
                        .WithMany("Planification")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("VaccineCenter.Model.Vaccin", "Vaccin")
                        .WithMany("Planifications")
                        .HasForeignKey("VaccinId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Center");

                    b.Navigation("Patient");

                    b.Navigation("Vaccin");
                });

            modelBuilder.Entity("VaccineCenter.Model.Provider", b =>
                {
                    b.HasOne("VaccineCenter.Model.Vaccin", "Vaccin")
                        .WithMany()
                        .HasForeignKey("VaccinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vaccin");
                });

            modelBuilder.Entity("VaccineCenter.Model.Schedule", b =>
                {
                    b.HasOne("VaccineCenter.Model.Center", "Center")
                        .WithMany("Schedule")
                        .HasForeignKey("CenterId");

                    b.Navigation("Center");
                });

            modelBuilder.Entity("VaccineCenter.Model.Staff", b =>
                {
                    b.HasOne("VaccineCenter.Model.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VaccineCenter.Model.Workspace", null)
                        .WithMany("Staffs")
                        .HasForeignKey("WorkspaceId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("VaccineCenter.Model.Vaccin", b =>
                {
                    b.HasOne("VaccineCenter.Model.Center", null)
                        .WithMany("Vaccin")
                        .HasForeignKey("CenterId");
                });

            modelBuilder.Entity("VaccineCenter.Model.VaccinInfo", b =>
                {
                    b.HasOne("VaccineCenter.Model.Vaccin", "Vaccin")
                        .WithMany()
                        .HasForeignKey("VaccinId");

                    b.Navigation("Vaccin");
                });

            modelBuilder.Entity("VaccineCenter.Model.Workspace", b =>
                {
                    b.HasOne("VaccineCenter.Model.Center", null)
                        .WithMany("Workspace")
                        .HasForeignKey("CenterId");

                    b.HasOne("VaccineCenter.Model.Staff", "Responsible")
                        .WithMany()
                        .HasForeignKey("ResponsibleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Responsible");
                });

            modelBuilder.Entity("VaccineCenter.Model.Center", b =>
                {
                    b.Navigation("Log");

                    b.Navigation("Planifications");

                    b.Navigation("Schedule");

                    b.Navigation("Vaccin");

                    b.Navigation("Workspace");
                });

            modelBuilder.Entity("VaccineCenter.Model.InActivity", b =>
                {
                    b.Navigation("Center");
                });

            modelBuilder.Entity("VaccineCenter.Model.Patient", b =>
                {
                    b.Navigation("Planification");
                });

            modelBuilder.Entity("VaccineCenter.Model.Vaccin", b =>
                {
                    b.Navigation("Planifications");
                });

            modelBuilder.Entity("VaccineCenter.Model.Workspace", b =>
                {
                    b.Navigation("Staffs");
                });
#pragma warning restore 612, 618
        }
    }
}
