﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.DataAccess;

namespace WebAPI.Migrations
{
    [DbContext(typeof(FamilyContext))]
    partial class FamilyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("WebAPI.Models.Adult", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Age")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChildId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EyeColor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("FamilyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HairColor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Height")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("JobTitleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float?>("Weight")
                        .IsRequired()
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.HasIndex("FamilyId");

                    b.HasIndex("JobTitleId");

                    b.ToTable("Adult");
                });

            modelBuilder.Entity("WebAPI.Models.Child", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Age")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EyeColor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("FamilyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HairColor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Height")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float?>("Weight")
                        .IsRequired()
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.ToTable("Child");
                });

            modelBuilder.Entity("WebAPI.Models.Family", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StreetName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Families");
                });

            modelBuilder.Entity("WebAPI.Models.Interest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChildId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.ToTable("Interest");
                });

            modelBuilder.Entity("WebAPI.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("JobTitle")
                        .HasColumnType("TEXT");

                    b.Property<int>("Salary")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("WebAPI.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Age")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FamilyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.ToTable("Pet");
                });

            modelBuilder.Entity("WebAPI.Models.Adult", b =>
                {
                    b.HasOne("WebAPI.Models.Child", null)
                        .WithMany("Pets")
                        .HasForeignKey("ChildId");

                    b.HasOne("WebAPI.Models.Family", null)
                        .WithMany("Adults")
                        .HasForeignKey("FamilyId");

                    b.HasOne("WebAPI.Models.Job", "JobTitle")
                        .WithMany()
                        .HasForeignKey("JobTitleId");

                    b.Navigation("JobTitle");
                });

            modelBuilder.Entity("WebAPI.Models.Child", b =>
                {
                    b.HasOne("WebAPI.Models.Family", null)
                        .WithMany("Children")
                        .HasForeignKey("FamilyId");
                });

            modelBuilder.Entity("WebAPI.Models.Interest", b =>
                {
                    b.HasOne("WebAPI.Models.Child", null)
                        .WithMany("Interests")
                        .HasForeignKey("ChildId");
                });

            modelBuilder.Entity("WebAPI.Models.Pet", b =>
                {
                    b.HasOne("WebAPI.Models.Family", null)
                        .WithMany("Pets")
                        .HasForeignKey("FamilyId");
                });

            modelBuilder.Entity("WebAPI.Models.Child", b =>
                {
                    b.Navigation("Interests");

                    b.Navigation("Pets");
                });

            modelBuilder.Entity("WebAPI.Models.Family", b =>
                {
                    b.Navigation("Adults");

                    b.Navigation("Children");

                    b.Navigation("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}
