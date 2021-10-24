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
    [Migration("20211020175153_relationships")]
    partial class relationships
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

                    b.HasIndex("AcademieJaarId");

                    b.HasIndex("StudentId");

                    b.HasIndex("VakLectorId");

                    b.ToTable("Inschrijvingen");
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

                    b.HasIndex("GebruikerId");

                    b.ToTable("Lectoren");
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

                    b.HasIndex("GebruikerId");

                    b.ToTable("students");
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VakId");

                    b.HasIndex("HandboekId");

                    b.ToTable("Vakken");
                });

            modelBuilder.Entity("HogeschoolPxl.Models.VakLector", b =>
                {
                    b.Property<int>("VakLectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LectorId")
                        .HasColumnType("int");

                    b.Property<int>("VakId")
                        .HasColumnType("int");

                    b.HasKey("VakLectorId");

                    b.HasIndex("LectorId");

                    b.HasIndex("VakId");

                    b.ToTable("VakLectoren");
                });

            modelBuilder.Entity("HogeschoolPxl.Models.Inschrijving", b =>
                {
                    b.HasOne("HogeschoolPxl.Models.AcademieJaar", "AcademieJaar")
                        .WithMany("Inschrijvingen")
                        .HasForeignKey("AcademieJaarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HogeschoolPxl.Models.Student", "Student")
                        .WithMany("Inschrijvingen")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HogeschoolPxl.Models.VakLector", "VakLector")
                        .WithMany("Inschrijvingen")
                        .HasForeignKey("VakLectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HogeschoolPxl.Models.Lector", b =>
                {
                    b.HasOne("HogeschoolPxl.Models.Gebruiker", "Gebruiker")
                        .WithMany("lectoren")
                        .HasForeignKey("GebruikerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HogeschoolPxl.Models.Student", b =>
                {
                    b.HasOne("HogeschoolPxl.Models.Gebruiker", "Gebruiker")
                        .WithMany("Studenten")
                        .HasForeignKey("GebruikerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HogeschoolPxl.Models.Vak", b =>
                {
                    b.HasOne("HogeschoolPxl.Models.Handboek", "Handboek")
                        .WithMany("Vakken")
                        .HasForeignKey("HandboekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HogeschoolPxl.Models.VakLector", b =>
                {
                    b.HasOne("HogeschoolPxl.Models.Lector", "Lector")
                        .WithMany("VakLectoren")
                        .HasForeignKey("LectorId");

                    b.HasOne("HogeschoolPxl.Models.Vak", "Vak")
                        .WithMany("VakLectoren")
                        .HasForeignKey("VakId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
