﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RatingApp.Database;

namespace RatingApp.Migrations
{
    [DbContext(typeof(RatingAppDBContext))]
    [Migration("20220113143730_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("RatingApp.Database.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BannerImage")
                        .HasColumnType("varchar(MAX)");

                    b.Property<int>("BlogCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Hit")
                        .HasColumnType("int");

                    b.Property<string>("ListImage")
                        .HasColumnType("varchar(MAX)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Text")
                        .HasColumnType("varchar(MAX)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Blogs");
                });
#pragma warning restore 612, 618
        }
    }
}
