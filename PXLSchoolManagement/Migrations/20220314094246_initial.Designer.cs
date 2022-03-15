﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PXLSchoolManagement.Data;

#nullable disable

namespace PXLSchoolManagement.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220314094246_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InschrijvingStudent", b =>
                {
                    b.Property<int>("InschrijvingenId")
                        .HasColumnType("int");

                    b.Property<int>("StudentenStudentId")
                        .HasColumnType("int");

                    b.HasKey("InschrijvingenId", "StudentenStudentId");

                    b.HasIndex("StudentenStudentId");

                    b.ToTable("InschrijvingStudent");
                });

            modelBuilder.Entity("PXLSchoolManagement.Models.Academiejaar", b =>
                {
                    b.Property<int>("AcademiejaarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AcademiejaarId"), 1L, 1);

                    b.Property<DateTime>("Startdatum")
                        .HasColumnType("datetime2");

                    b.HasKey("AcademiejaarId");

                    b.ToTable("Academiejaren");
                });

            modelBuilder.Entity("PXLSchoolManagement.Models.Gebruiker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gebruikers");
                });

            modelBuilder.Entity("PXLSchoolManagement.Models.Handboek", b =>
                {
                    b.Property<int>("HandboekId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HandboekId"), 1L, 1);

                    b.Property<string>("Afbeelding")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Kostprijs")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UitgifteDatum")
                        .HasColumnType("datetime2");

                    b.Property<int>("VakId")
                        .HasColumnType("int");

                    b.HasKey("HandboekId");

                    b.HasIndex("StudentId");

                    b.HasIndex("VakId");

                    b.ToTable("Handboeken");
                });

            modelBuilder.Entity("PXLSchoolManagement.Models.Inschrijving", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AcademiejaarId")
                        .HasColumnType("int");

                    b.Property<int?>("VakId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AcademiejaarId");

                    b.HasIndex("VakId");

                    b.ToTable("Inschrijvingen");
                });

            modelBuilder.Entity("PXLSchoolManagement.Models.Lector", b =>
                {
                    b.Property<int>("LectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LectorId"), 1L, 1);

                    b.Property<int>("GebruikerId")
                        .HasColumnType("int");

                    b.HasKey("LectorId");

                    b.HasIndex("GebruikerId");

                    b.ToTable("Lectoren");
                });

            modelBuilder.Entity("PXLSchoolManagement.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"), 1L, 1);

                    b.Property<int>("GebruikerId")
                        .HasColumnType("int");

                    b.HasKey("StudentId");

                    b.HasIndex("GebruikerId");

                    b.ToTable("Studenten");
                });

            modelBuilder.Entity("PXLSchoolManagement.Models.Vak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Studiepunten")
                        .HasColumnType("int");

                    b.Property<string>("VakNaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vakken");
                });

            modelBuilder.Entity("PXLSchoolManagement.Models.Vaklector", b =>
                {
                    b.Property<int>("VakLectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VakLectorId"), 1L, 1);

                    b.Property<int>("InschrijvingId")
                        .HasColumnType("int");

                    b.Property<int>("LectorId")
                        .HasColumnType("int");

                    b.HasKey("VakLectorId");

                    b.HasIndex("InschrijvingId");

                    b.HasIndex("LectorId");

                    b.ToTable("Vaklectoren");
                });

            modelBuilder.Entity("InschrijvingStudent", b =>
                {
                    b.HasOne("PXLSchoolManagement.Models.Inschrijving", null)
                        .WithMany()
                        .HasForeignKey("InschrijvingenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PXLSchoolManagement.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentenStudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PXLSchoolManagement.Models.Handboek", b =>
                {
                    b.HasOne("PXLSchoolManagement.Models.Student", "Student")
                        .WithMany("Handboeken")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PXLSchoolManagement.Models.Vak", "Vak")
                        .WithMany()
                        .HasForeignKey("VakId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Vak");
                });

            modelBuilder.Entity("PXLSchoolManagement.Models.Inschrijving", b =>
                {
                    b.HasOne("PXLSchoolManagement.Models.Academiejaar", "Academiejaar")
                        .WithMany("Inschrijvingen")
                        .HasForeignKey("AcademiejaarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PXLSchoolManagement.Models.Vak", null)
                        .WithMany("Inschrijvingen")
                        .HasForeignKey("VakId");

                    b.Navigation("Academiejaar");
                });

            modelBuilder.Entity("PXLSchoolManagement.Models.Lector", b =>
                {
                    b.HasOne("PXLSchoolManagement.Models.Gebruiker", "Gebruiker")
                        .WithMany()
                        .HasForeignKey("GebruikerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gebruiker");
                });

            modelBuilder.Entity("PXLSchoolManagement.Models.Student", b =>
                {
                    b.HasOne("PXLSchoolManagement.Models.Gebruiker", "Gebruiker")
                        .WithMany()
                        .HasForeignKey("GebruikerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gebruiker");
                });

            modelBuilder.Entity("PXLSchoolManagement.Models.Vaklector", b =>
                {
                    b.HasOne("PXLSchoolManagement.Models.Inschrijving", "Inschrijving")
                        .WithMany("Vaklectors")
                        .HasForeignKey("InschrijvingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PXLSchoolManagement.Models.Lector", "Lector")
                        .WithMany()
                        .HasForeignKey("LectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inschrijving");

                    b.Navigation("Lector");
                });

            modelBuilder.Entity("PXLSchoolManagement.Models.Academiejaar", b =>
                {
                    b.Navigation("Inschrijvingen");
                });

            modelBuilder.Entity("PXLSchoolManagement.Models.Inschrijving", b =>
                {
                    b.Navigation("Vaklectors");
                });

            modelBuilder.Entity("PXLSchoolManagement.Models.Student", b =>
                {
                    b.Navigation("Handboeken");
                });

            modelBuilder.Entity("PXLSchoolManagement.Models.Vak", b =>
                {
                    b.Navigation("Inschrijvingen");
                });
#pragma warning restore 612, 618
        }
    }
}
