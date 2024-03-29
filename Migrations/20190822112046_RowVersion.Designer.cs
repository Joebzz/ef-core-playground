﻿// <auto-generated />
using System;
using EFCore.Playground.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCore.Playground.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    [Migration("20190822112046_RowVersion")]
    partial class RowVersion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCore.Playground.DataAccess.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OfficeId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(-1);

                    b.Property<string>("Title");

                    b.HasKey("DepartmentId");

                    b.HasIndex("OfficeId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentId = -1,
                            OfficeId = -1,
                            Title = "HR"
                        },
                        new
                        {
                            DepartmentId = -2,
                            OfficeId = -1,
                            Title = "IT"
                        },
                        new
                        {
                            DepartmentId = -3,
                            OfficeId = -2,
                            Title = "Software"
                        });
                });

            modelBuilder.Entity("EFCore.Playground.DataAccess.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Email");

                    b.Property<string>("Firstname");

                    b.Property<int?>("ManagerId");

                    b.Property<string>("PhoneNumber");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("SocialSecurityNumber");

                    b.Property<string>("Surname");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("ManagerId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = -1,
                            DepartmentId = -1,
                            Email = "ssmith@company.com",
                            Firstname = "Stan",
                            PhoneNumber = "+1234567893",
                            SocialSecurityNumber = "P1234567890",
                            Surname = "Smith",
                            Username = "ssmith"
                        },
                        new
                        {
                            EmployeeId = -2,
                            DepartmentId = -3,
                            Email = "tbean@company.com",
                            Firstname = "Tim",
                            PhoneNumber = "+1234567894",
                            SocialSecurityNumber = "P1234567891",
                            Surname = "Bean",
                            Username = "tbean"
                        },
                        new
                        {
                            EmployeeId = -3,
                            DepartmentId = -3,
                            Email = "jblack@company.com",
                            Firstname = "Jack",
                            ManagerId = -2,
                            PhoneNumber = "+1234567895",
                            SocialSecurityNumber = "P1234567892",
                            Surname = "Black",
                            Username = "jblack"
                        });
                });

            modelBuilder.Entity("EFCore.Playground.DataAccess.Models.EmployeeRole", b =>
                {
                    b.Property<int>("EmployeeId");

                    b.Property<int>("RoleId");

                    b.HasKey("EmployeeId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("EmployeeRoles");

                    b.HasData(
                        new
                        {
                            EmployeeId = -1,
                            RoleId = -1
                        },
                        new
                        {
                            EmployeeId = -2,
                            RoleId = -2
                        },
                        new
                        {
                            EmployeeId = -2,
                            RoleId = -1
                        },
                        new
                        {
                            EmployeeId = -3,
                            RoleId = -2
                        });
                });

            modelBuilder.Entity("EFCore.Playground.DataAccess.Models.Office", b =>
                {
                    b.Property<int>("OfficeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Title");

                    b.HasKey("OfficeId");

                    b.ToTable("Office");

                    b.HasData(
                        new
                        {
                            OfficeId = -1,
                            PhoneNumber = "+1234567891",
                            PostalCode = "SK2 5JY",
                            Title = "London (HQ)"
                        },
                        new
                        {
                            OfficeId = -2,
                            PhoneNumber = "+1234567892",
                            PostalCode = "10001",
                            Title = "New York"
                        });
                });

            modelBuilder.Entity("EFCore.Playground.DataAccess.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = -1,
                            Title = "Administrator"
                        },
                        new
                        {
                            RoleId = -2,
                            Title = "Developer"
                        });
                });

            modelBuilder.Entity("EFCore.Playground.DataAccess.Models.Department", b =>
                {
                    b.HasOne("EFCore.Playground.DataAccess.Models.Office", "Office")
                        .WithMany("Departments")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFCore.Playground.DataAccess.Models.Employee", b =>
                {
                    b.HasOne("EFCore.Playground.DataAccess.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFCore.Playground.DataAccess.Models.Employee", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");
                });

            modelBuilder.Entity("EFCore.Playground.DataAccess.Models.EmployeeRole", b =>
                {
                    b.HasOne("EFCore.Playground.DataAccess.Models.Employee", "Employee")
                        .WithMany("EmployeeRoles")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFCore.Playground.DataAccess.Models.Role", "Role")
                        .WithMany("EmployeeRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
