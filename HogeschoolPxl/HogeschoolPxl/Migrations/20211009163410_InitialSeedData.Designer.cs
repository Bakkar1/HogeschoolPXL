﻿// <auto-generated />
using System;
using HogeschoolPxl.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HogeschoolPxl.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211009163410_InitialSeedData")]
    partial class InitialSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HogeschoolPxl.Models.AcademieJaar", b =>
                {
                    b.Property<int>("AcademieJaarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("StartDatum")
                        .HasColumnType("datetime2");

                    b.HasKey("AcademieJaarId");

                    b.ToTable("AcademieJaaren");

                    b.HasData(
                        new
                        {
                            AcademieJaarId = 1,
                            StartDatum = new DateTime(2021, 10, 9, 18, 34, 9, 739, DateTimeKind.Local).AddTicks(8769)
                        });
                });

            modelBuilder.Entity("HogeschoolPxl.Models.Gebruiker", b =>
                {
                    b.Property<int>("GebruikerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VoorNaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GebruikerId");

                    b.ToTable("Gebruikers");

                    b.HasData(
                        new
                        {
                            GebruikerId = 1,
                            Email = "mbark.bakkar@pxl.be",
                            Naam = "Bakkar",
                            VoorNaam = "Mbark"
                        },
                        new
                        {
                            GebruikerId = 2,
                            Email = "Kristof.Palmaers@pxl.be",
                            Naam = "Palmaers",
                            VoorNaam = "Kristof"
                        });
                });

            modelBuilder.Entity("HogeschoolPxl.Models.Handboek", b =>
                {
                    b.Property<int>("HandboekId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Afbeelding")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("KostPrijs")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UitGifteDatum")
                        .HasColumnType("datetime2");

                    b.HasKey("HandboekId");

                    b.ToTable("handboeken");

                    b.HasData(
                        new
                        {
                            HandboekId = 1,
                            KostPrijs = 30.0,
                            Title = "C# Web 1",
                            UitGifteDatum = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("HogeschoolPxl.Models.Inschrijving", b =>
                {
                    b.Property<int>("InschrijvingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AcademieJaarId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("VakLectorId")
                        .HasColumnType("int");

                    b.HasKey("InschrijvingId");

                    b.ToTable("Inschrijvingen");

                    b.HasData(
                        new
                        {
                            InschrijvingId = 1,
                            AcademieJaarId = 1,
                            StudentId = 1,
                            VakLectorId = 1
                        });
                });

            modelBuilder.Entity("HogeschoolPxl.Models.Lector", b =>
                {
                    b.Property<int>("LectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GebruikerId")
                        .HasColumnType("int");

                    b.HasKey("LectorId");

                    b.ToTable("Lectoren");

                    b.HasData(
                        new
                        {
                            LectorId = 1,
                            GebruikerId = 2
                        });
                });

            modelBuilder.Entity("HogeschoolPxl.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GebruikerId")
                        .HasColumnType("int");

                    b.HasKey("StudentId");

                    b.ToTable("students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            GebruikerId = 1
                        });
                });

            modelBuilder.Entity("HogeschoolPxl.Models.Vak", b =>
                {
                    b.Property<int>("VakId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HandboekId")
                        .HasColumnType("int");

                    b.Property<int>("Studiepunten")
                        .HasColumnType("int");

                    b.Property<string>("VakNaam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VakId");

                    b.ToTable("Vakken");

                    b.HasData(
                        new
                        {
                            VakId = 1,
                            HandboekId = 1,
                            Studiepunten = 5,
                            VakNaam = "C# Web"
                        });
                });

            modelBuilder.Entity("HogeschoolPxl.Models.VakLector", b =>
                {
                    b.Property<int>("VakLectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GebruikerId")
                        .HasColumnType("int");

                    b.Property<int>("LectorId")
                        .HasColumnType("int");

                    b.HasKey("VakLectorId");

                    b.ToTable("VakLectoren");

                    b.HasData(
                        new
                        {
                            VakLectorId = 1,
                            GebruikerId = 1,
                            LectorId = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
