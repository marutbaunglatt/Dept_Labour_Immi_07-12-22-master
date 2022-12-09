﻿// <auto-generated />
using System;
using Dept_Labour_Immi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dept_Labour_Immi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221207104919_InitialCatalog_V1_07-12-22")]
    partial class InitialCatalog_V1_071222
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Dept_Labour_Immi.Models.Agency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AgencyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BOD_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LicenseEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LicenseStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("agencies");
                });

            modelBuilder.Entity("Dept_Labour_Immi.Models.Blacklist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AgencyID")
                        .HasColumnType("int");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ThaiCompanyID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Todate")
                        .HasColumnType("datetime2");

                    b.Property<string>("penaltyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AgencyID");

                    b.HasIndex("ThaiCompanyID");

                    b.ToTable("blacklists");
                });

            modelBuilder.Entity("Dept_Labour_Immi.Models.BOD", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("AgencyID")
                        .HasColumnType("int");

                    b.Property<string>("NRC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AgencyID");

                    b.ToTable("bODs");
                });

            modelBuilder.Entity("Dept_Labour_Immi.Models.Country", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("countries");
                });

            modelBuilder.Entity("Dept_Labour_Immi.Models.DOE", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("DOE_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("DOE_NO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("DOEs");
                });

            modelBuilder.Entity("Dept_Labour_Immi.Models.InternationalSending", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("AgencyID")
                        .HasColumnType("int");

                    b.Property<int>("CountryID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfWorker")
                        .HasColumnType("int");

                    b.Property<int?>("ServiceThaiWorkerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AgencyID");

                    b.HasIndex("CountryID");

                    b.HasIndex("ServiceThaiWorkerID");

                    b.ToTable("internationalSendings");
                });

            modelBuilder.Entity("Dept_Labour_Immi.Models.Operation_1", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AgencyID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("Apply_Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DOEDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DOEID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Document_Complete_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("FemaleWorkers")
                        .HasColumnType("int");

                    b.Property<int>("MaleWorkers")
                        .HasColumnType("int");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ThaiCompanyID")
                        .HasColumnType("int");

                    b.Property<int>("TotalWorkers")
                        .HasColumnType("int");

                    b.Property<string>("WorkType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AgencyID");

                    b.HasIndex("DOEID");

                    b.HasIndex("ThaiCompanyID");

                    b.ToTable("operation_1s");
                });

            modelBuilder.Entity("Dept_Labour_Immi.Models.Operation_2", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("Actual_Contract_Female_Worker")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("Actual_Contract_Male_Worker")
                        .HasColumnType("int");

                    b.Property<int?>("Actual_Contract_Total_Worker")
                        .HasColumnType("int");

                    b.Property<int?>("AgencyID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Apply_Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Contract_Granted_Date")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Contract_Request_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DOEID")
                        .HasColumnType("int");

                    b.Property<int?>("Permit_Female_Worker")
                        .HasColumnType("int");

                    b.Property<int?>("Permit_Male_Worker")
                        .HasColumnType("int");

                    b.Property<int>("Permit_Total_Worker")
                        .HasColumnType("int");

                    b.Property<int>("Remain_Female_Worker")
                        .HasColumnType("int");

                    b.Property<int>("Remain_Male_Worker")
                        .HasColumnType("int");

                    b.Property<int>("Remain_Total_Worker")
                        .HasColumnType("int");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Request_Female_Worker")
                        .HasColumnType("int");

                    b.Property<int?>("Request_Male_Worker")
                        .HasColumnType("int");

                    b.Property<int?>("Request_Total_Workers")
                        .HasColumnType("int");

                    b.Property<int?>("ThaiCompanyID")
                        .HasColumnType("int");

                    b.Property<string>("WorkType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AgencyID");

                    b.HasIndex("DOEID");

                    b.HasIndex("ThaiCompanyID");

                    b.ToTable("operation_2s");
                });

            modelBuilder.Entity("Dept_Labour_Immi.Models.Penalty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AgencyID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Todate")
                        .HasColumnType("datetime2");

                    b.Property<string>("penaltyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AgencyID");

                    b.ToTable("penalties");
                });

            modelBuilder.Entity("Dept_Labour_Immi.Models.ServiceforThaiWorker", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("CICardServiceCount")
                        .HasColumnType("int");

                    b.Property<int?>("PinkCardServiceCount")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("serviceforThaiWorkers");
                });

            modelBuilder.Entity("Dept_Labour_Immi.Models.ThaiCompany", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("AgencyID")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AgencyID");

                    b.ToTable("thaiCompanies");
                });

            modelBuilder.Entity("Dept_Labour_Immi.Models.ThaiSending", b =>
                {
                    b.Property<int>("ThaiSendingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ThaiSendingId"), 1L, 1);

                    b.Property<int?>("AgencyID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime?>("ApplyDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ContractSigningDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int?>("CountOfThaiCompany")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DepartureFromMWDDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("InchargePersonFromAgency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("MWDAwaitingDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("OWICDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int?>("PermitFemaleWorker")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("PermitMaleWorker")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("PermitTotalWorker")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RequestFemaleWorker")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("RequestMaleWorker")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("RequestTotalWorkers")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("ThaiCompanyID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("YangonDepartureDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.HasKey("ThaiSendingId");

                    b.HasIndex("AgencyID");

                    b.HasIndex("ThaiCompanyID");

                    b.ToTable("thaiSendings");
                });

            modelBuilder.Entity("Dept_Labour_Immi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Dept_Labour_Immi.Models.Blacklist", b =>
                {
                    b.HasOne("Dept_Labour_Immi.Models.Agency", "agency")
                        .WithMany("blacklists")
                        .HasForeignKey("AgencyID");

                    b.HasOne("Dept_Labour_Immi.Models.ThaiCompany", "thaiCompany")
                        .WithMany("blacklists")
                        .HasForeignKey("ThaiCompanyID");

                    b.Navigation("agency");

                    b.Navigation("thaiCompany");
                });

            modelBuilder.Entity("Dept_Labour_Immi.Models.BOD", b =>
                {
                    b.HasOne("Dept_Labour_Immi.Models.Agency", "agency")
                        .WithMany("bODs")
                        .HasForeignKey("AgencyID");

                    b.Navigation("agency");
                });

            modelBuilder.Entity("Dept_Labour_Immi.Models.InternationalSending", b =>
                {
                    b.HasOne("Dept_Labour_Immi.Models.Agency", "Agency")
                        .WithMany()
                        .HasForeignKey("AgencyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dept_Labour_Immi.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dept_Labour_Immi.Models.ServiceforThaiWorker", "ServiceThaiWorker")
                        .WithMany()
                        .HasForeignKey("ServiceThaiWorkerID");

                    b.Navigation("Agency");

                    b.Navigation("Country");

                    b.Navigation("ServiceThaiWorker");
                });

            modelBuilder.Entity("Dept_Labour_Immi.Models.Operation_1", b =>
                {
                    b.HasOne("Dept_Labour_Immi.Models.Agency", "agency")
                        .WithMany("Operation_1s")
                        .HasForeignKey("AgencyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dept_Labour_Immi.Models.DOE", "dOE")
                        .WithMany("Operation_1s")
                        .HasForeignKey("DOEID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dept_Labour_Immi.Models.ThaiCompany", "thaiCompany")
                        .WithMany("Operation_1s")
                        .HasForeignKey("ThaiCompanyID");

                    b.Navigation("agency");

                    b.Navigation("dOE");

                    b.Navigation("thaiCompany");
                });

            modelBuilder.Entity("Dept_Labour_Immi.Models.Operation_2", b =>
                {
                    b.HasOne("Dept_Labour_Immi.Models.Agency", "agency")
                        .WithMany()
                        .HasForeignKey("AgencyID");

                    b.HasOne("Dept_Labour_Immi.Models.DOE", "dOE")
                        .WithMany()
                        .HasForeignKey("DOEID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dept_Labour_Immi.Models.ThaiCompany", "thaiCompany")
                        .WithMany()
                        .HasForeignKey("ThaiCompanyID");

                    b.Navigation("agency");

                    b.Navigation("dOE");

                    b.Navigation("thaiCompany");
                });

            modelBuilder.Entity("Dept_Labour_Immi.Models.Penalty", b =>
                {
                    b.HasOne("Dept_Labour_Immi.Models.Agency", "agency")
                        .WithMany()
                        .HasForeignKey("AgencyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("agency");
                });

            modelBuilder.Entity("Dept_Labour_Immi.Models.ThaiCompany", b =>
                {
                    b.HasOne("Dept_Labour_Immi.Models.Agency", "agency")
                        .WithMany("thaiCompanies")
                        .HasForeignKey("AgencyID");

                    b.Navigation("agency");
                });

            modelBuilder.Entity("Dept_Labour_Immi.Models.ThaiSending", b =>
                {
                    b.HasOne("Dept_Labour_Immi.Models.Agency", "agency")
                        .WithMany()
                        .HasForeignKey("AgencyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dept_Labour_Immi.Models.ThaiCompany", "thaiCompany")
                        .WithMany()
                        .HasForeignKey("ThaiCompanyID");

                    b.Navigation("agency");

                    b.Navigation("thaiCompany");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dept_Labour_Immi.Models.Agency", b =>
                {
                    b.Navigation("Operation_1s");

                    b.Navigation("bODs");

                    b.Navigation("blacklists");

                    b.Navigation("thaiCompanies");
                });

            modelBuilder.Entity("Dept_Labour_Immi.Models.DOE", b =>
                {
                    b.Navigation("Operation_1s");
                });

            modelBuilder.Entity("Dept_Labour_Immi.Models.ThaiCompany", b =>
                {
                    b.Navigation("Operation_1s");

                    b.Navigation("blacklists");
                });
#pragma warning restore 612, 618
        }
    }
}
