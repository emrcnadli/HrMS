﻿// <auto-generated />
using System;
using Hr_Management_System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hr_Management_System.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240326191217_initial migration")]
    partial class initialmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hr_Management_System.Models.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Hr_Management_System.Models.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("BirthDay")
                        .HasColumnType("date");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Payment")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("RoleId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Hr_Management_System.Models.Entities.PersonProject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PersonID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProjectID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PersonID");

                    b.HasIndex("ProjectID");

                    b.ToTable("PersonProject");
                });

            modelBuilder.Entity("Hr_Management_System.Models.Entities.PersonSkills", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PersonID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SkillID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PersonID");

                    b.HasIndex("SkillID");

                    b.ToTable("PersonSkills");
                });

            modelBuilder.Entity("Hr_Management_System.Models.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Hr_Management_System.Models.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Hr_Management_System.Models.Entities.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Hr_Management_System.Models.Entities.Person", b =>
                {
                    b.HasOne("Hr_Management_System.Models.Entities.Department", "Department")
                        .WithMany("Persons")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hr_Management_System.Models.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Hr_Management_System.Models.Entities.PersonProject", b =>
                {
                    b.HasOne("Hr_Management_System.Models.Entities.Person", "Person")
                        .WithMany("PersonProjects")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Hr_Management_System.Models.Entities.Project", "Project")
                        .WithMany("PersonProjects")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Person");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Hr_Management_System.Models.Entities.PersonSkills", b =>
                {
                    b.HasOne("Hr_Management_System.Models.Entities.Person", "Person")
                        .WithMany("PersonSkills")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Hr_Management_System.Models.Entities.Skill", "Skill")
                        .WithMany("PersonSkills")
                        .HasForeignKey("SkillID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Person");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Hr_Management_System.Models.Entities.Department", b =>
                {
                    b.Navigation("Persons");
                });

            modelBuilder.Entity("Hr_Management_System.Models.Entities.Person", b =>
                {
                    b.Navigation("PersonProjects");

                    b.Navigation("PersonSkills");
                });

            modelBuilder.Entity("Hr_Management_System.Models.Entities.Project", b =>
                {
                    b.Navigation("PersonProjects");
                });

            modelBuilder.Entity("Hr_Management_System.Models.Entities.Skill", b =>
                {
                    b.Navigation("PersonSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
