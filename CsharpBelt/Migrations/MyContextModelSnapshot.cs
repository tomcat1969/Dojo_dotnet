﻿// <auto-generated />
using System;
using CsharpBelt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CsharpBelt.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CsharpBelt.Models.Association", b =>
                {
                    b.Property<int>("AssociationId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DojoActivityId");

                    b.Property<int>("UserId");

                    b.HasKey("AssociationId");

                    b.HasIndex("DojoActivityId");

                    b.HasIndex("UserId");

                    b.ToTable("Associations");
                });

            modelBuilder.Entity("CsharpBelt.Models.DojoActivity", b =>
                {
                    b.Property<int>("DojoActivityId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("Duration");

                    b.Property<string>("DurationUnit")
                        .IsRequired();

                    b.Property<DateTime>("Time");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("UserId");

                    b.HasKey("DojoActivityId");

                    b.HasIndex("UserId");

                    b.ToTable("DojoActivities");
                });

            modelBuilder.Entity("CsharpBelt.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CsharpBelt.Models.Association", b =>
                {
                    b.HasOne("CsharpBelt.Models.DojoActivity", "DojoActivity")
                        .WithMany("Associations")
                        .HasForeignKey("DojoActivityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CsharpBelt.Models.User", "User")
                        .WithMany("Associations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CsharpBelt.Models.DojoActivity", b =>
                {
                    b.HasOne("CsharpBelt.Models.User", "Creator")
                        .WithMany("CreatedDojoActivities")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}