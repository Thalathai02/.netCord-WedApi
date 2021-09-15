﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WedApi.Models;

namespace WedApi.Migrations
{
    [DbContext(typeof(locationContext))]
    [Migration("20210915022749_TestApi")]
    partial class TestApi
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("WedApi.Models.location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("User")
                        .HasColumnType("int");

                    b.Property<double>("lat")
                        .HasColumnType("double");

                    b.Property<double>("lng")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("location");
                });

            modelBuilder.Entity("WedApi.Models.user", b =>
                {
                    b.Property<int>("IdUsers")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("UUID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("IdUsers");

                    b.ToTable("user");
                });
#pragma warning restore 612, 618
        }
    }
}
