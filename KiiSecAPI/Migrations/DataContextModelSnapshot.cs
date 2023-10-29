﻿// <auto-generated />
using System;
using KiiSecAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KiiSecAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KiiSecAPI.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Permissions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("KiiSecAPI.Models.Organization", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("KiiSecAPI.Models.Visit", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int?>("OrganizationID")
                        .HasColumnType("int");

                    b.Property<string>("VisitPurpose")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VisitRequestID")
                        .HasColumnType("int");

                    b.Property<int>("VisitorsGroupID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("KiiSecAPI.Models.VisitRequest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int?>("OrganizationID")
                        .HasColumnType("int");

                    b.Property<string>("VisitPurpose")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VisitStatus")
                        .HasColumnType("int");

                    b.Property<int>("VisitorsGroupID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("VisitRequests");
                });

            modelBuilder.Entity("KiiSecAPI.Models.Visitor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VisitorOrganization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VisitorsGroupID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("VisitorsGroupID");

                    b.ToTable("Visitors");
                });

            modelBuilder.Entity("KiiSecAPI.Models.VisitorsGroup", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("OrganizationID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("VisitorsGroup");
                });

            modelBuilder.Entity("KiiSecAPI.Models.Employee", b =>
                {
                    b.HasOne("KiiSecAPI.Models.Organization", null)
                        .WithMany("Employees")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KiiSecAPI.Models.Visit", b =>
                {
                    b.HasOne("KiiSecAPI.Models.Organization", null)
                        .WithMany("Visits")
                        .HasForeignKey("OrganizationID");
                });

            modelBuilder.Entity("KiiSecAPI.Models.VisitRequest", b =>
                {
                    b.HasOne("KiiSecAPI.Models.Organization", null)
                        .WithMany("VisitRequests")
                        .HasForeignKey("OrganizationID");
                });

            modelBuilder.Entity("KiiSecAPI.Models.Visitor", b =>
                {
                    b.HasOne("KiiSecAPI.Models.VisitorsGroup", null)
                        .WithMany("Visitors")
                        .HasForeignKey("VisitorsGroupID");
                });

            modelBuilder.Entity("KiiSecAPI.Models.VisitorsGroup", b =>
                {
                    b.HasOne("KiiSecAPI.Models.Organization", null)
                        .WithMany("VisitorsGroups")
                        .HasForeignKey("OrganizationID");
                });

            modelBuilder.Entity("KiiSecAPI.Models.Organization", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("VisitRequests");

                    b.Navigation("VisitorsGroups");

                    b.Navigation("Visits");
                });

            modelBuilder.Entity("KiiSecAPI.Models.VisitorsGroup", b =>
                {
                    b.Navigation("Visitors");
                });
#pragma warning restore 612, 618
        }
    }
}