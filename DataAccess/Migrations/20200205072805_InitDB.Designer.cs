﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project_Anglia.Data;

namespace DataAccess.Migrations
{
    [DbContext(typeof(VelhoContext))]
    [Migration("20200205072805_InitDB")]
    partial class InitDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("Project_Anglia.Data.Agent", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("BirthYear")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DeathYear")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FamilyName")
                        .HasColumnType("TEXT");

                    b.Property<int>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<string>("GivenName")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Dead");
                });

            modelBuilder.Entity("Project_Anglia.Data.Family", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("DesiredChildren")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Families");
                });
#pragma warning restore 612, 618
        }
    }
}