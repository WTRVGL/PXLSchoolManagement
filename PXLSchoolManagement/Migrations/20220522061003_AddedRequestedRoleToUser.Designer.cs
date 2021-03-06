// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PXLSchoolManagement.Data;

namespace PXLSchoolManagement.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220522061003_AddedRequestedRoleToUser")]
    partial class AddedRequestedRoleToUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("HandboekStudent", b =>
                {
                    b.Property<int>("HandboekenHandboekId")
                        .HasColumnType("int");

                    b.Property<int>("StudentenStudentId")
                        .HasColumnType("int");

                    b.HasKey("HandboekenHandboekId", "StudentenStudentId");

                    b.HasIndex("StudentenStudentId");

                    b.ToTable("HandboekStudent");
                });

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

            modelBuilder.Entity("InschrijvingVaklector", b =>
                {
                    b.Property<int>("InschrijvingenId")
                        .HasColumnType("int");

                    b.Property<int>("VaklectorsVakLectorId")
                        .HasColumnType("int");

                    b.HasKey("InschrijvingenId", "VaklectorsVakLectorId");

                    b.HasIndex("VaklectorsVakLectorId");

                    b.ToTable("InschrijvingVaklector");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GebruikerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("GebruikerId");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PXLSchoolManagement.Models.Academiejaar", b =>
                {
                    b.Property<int>("AcademiejaarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Startdatum")
                        .HasColumnType("datetime2");

                    b.HasKey("AcademiejaarId");

                    b.ToTable("Academiejaren");
                });

            modelBuilder.Entity("PXLSchoolManagement.Models.Gebruiker", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTemporarilyAccount")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RequestedRoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("RequestedRoleId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("PXLSchoolManagement.Models.Handboek", b =>
                {
                    b.Property<int>("HandboekId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Afbeelding")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Kostprijs")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UitgifteDatum")
                        .HasColumnType("datetime2");

                    b.Property<int>("VakId")
                        .HasColumnType("int");

                    b.HasKey("HandboekId");

                    b.HasIndex("VakId");

                    b.ToTable("Handboeken");
                });

            modelBuilder.Entity("PXLSchoolManagement.Models.Inschrijving", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AcademiejaarId")
                        .HasColumnType("int");

                    b.Property<int>("VakId")
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
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("GebruikerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LectorId");

                    b.HasIndex("GebruikerId");

                    b.ToTable("Lectoren");
                });

            modelBuilder.Entity("PXLSchoolManagement.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("GebruikerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("StudentId");

                    b.HasIndex("GebruikerId");

                    b.ToTable("Studenten");
                });

            modelBuilder.Entity("PXLSchoolManagement.Models.Vak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

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
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("LectorId")
                        .HasColumnType("int");

                    b.HasKey("VakLectorId");

                    b.HasIndex("LectorId")
                        .IsUnique();

                    b.ToTable("Vaklectoren");
                });

            modelBuilder.Entity("HandboekStudent", b =>
                {
                    b.HasOne("PXLSchoolManagement.Models.Handboek", null)
                        .WithMany()
                        .HasForeignKey("HandboekenHandboekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PXLSchoolManagement.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentenStudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("InschrijvingVaklector", b =>
                {
                    b.HasOne("PXLSchoolManagement.Models.Inschrijving", null)
                        .WithMany()
                        .HasForeignKey("InschrijvingenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PXLSchoolManagement.Models.Vaklector", null)
                        .WithMany()
                        .HasForeignKey("VaklectorsVakLectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.HasOne("PXLSchoolManagement.Models.Gebruiker", null)
                        .WithMany("Roles")
                        .HasForeignKey("GebruikerId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PXLSchoolManagement.Models.Gebruiker", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PXLSchoolManagement.Models.Gebruiker", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PXLSchoolManagement.Models.Gebruiker", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PXLSchoolManagement.Models.Gebruiker", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PXLSchoolManagement.Models.Gebruiker", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", "RequestedRole")
                        .WithMany()
                        .HasForeignKey("RequestedRoleId");

                    b.Navigation("RequestedRole");
                });

            modelBuilder.Entity("PXLSchoolManagement.Models.Handboek", b =>
                {
                    b.HasOne("PXLSchoolManagement.Models.Vak", "Vak")
                        .WithMany("Handboeken")
                        .HasForeignKey("VakId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vak");
                });

            modelBuilder.Entity("PXLSchoolManagement.Models.Inschrijving", b =>
                {
                    b.HasOne("PXLSchoolManagement.Models.Academiejaar", "Academiejaar")
                        .WithMany("Inschrijvingen")
                        .HasForeignKey("AcademiejaarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PXLSchoolManagement.Models.Vak", "Vak")
                        .WithMany("Inschrijvingen")
                        .HasForeignKey("VakId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Academiejaar");

                    b.Navigation("Vak");
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
                    b.HasOne("PXLSchoolManagement.Models.Lector", "Lector")
                        .WithOne("Vaklector")
                        .HasForeignKey("PXLSchoolManagement.Models.Vaklector", "LectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lector");
                });

            modelBuilder.Entity("PXLSchoolManagement.Models.Academiejaar", b =>
                {
                    b.Navigation("Inschrijvingen");
                });

            modelBuilder.Entity("PXLSchoolManagement.Models.Gebruiker", b =>
                {
                    b.Navigation("Roles");
                });

            modelBuilder.Entity("PXLSchoolManagement.Models.Lector", b =>
                {
                    b.Navigation("Vaklector");
                });

            modelBuilder.Entity("PXLSchoolManagement.Models.Vak", b =>
                {
                    b.Navigation("Handboeken");

                    b.Navigation("Inschrijvingen");
                });
#pragma warning restore 612, 618
        }
    }
}
