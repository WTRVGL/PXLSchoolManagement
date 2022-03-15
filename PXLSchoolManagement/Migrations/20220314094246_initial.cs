using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PXLSchoolManagement.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Academiejaren",
                columns: table => new
                {
                    AcademiejaarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Startdatum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Academiejaren", x => x.AcademiejaarId);
                });

            migrationBuilder.CreateTable(
                name: "Gebruikers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruikers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vakken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VakNaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Studiepunten = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vakken", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lectoren",
                columns: table => new
                {
                    LectorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GebruikerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectoren", x => x.LectorId);
                    table.ForeignKey(
                        name: "FK_Lectoren_Gebruikers_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "Gebruikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Studenten",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GebruikerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenten", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Studenten_Gebruikers_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "Gebruikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inschrijvingen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademiejaarId = table.Column<int>(type: "int", nullable: false),
                    VakId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inschrijvingen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inschrijvingen_Academiejaren_AcademiejaarId",
                        column: x => x.AcademiejaarId,
                        principalTable: "Academiejaren",
                        principalColumn: "AcademiejaarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inschrijvingen_Vakken_VakId",
                        column: x => x.VakId,
                        principalTable: "Vakken",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Handboeken",
                columns: table => new
                {
                    HandboekId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kostprijs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UitgifteDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Afbeelding = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VakId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Handboeken", x => x.HandboekId);
                    table.ForeignKey(
                        name: "FK_Handboeken_Studenten_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Studenten",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Handboeken_Vakken_VakId",
                        column: x => x.VakId,
                        principalTable: "Vakken",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InschrijvingStudent",
                columns: table => new
                {
                    InschrijvingenId = table.Column<int>(type: "int", nullable: false),
                    StudentenStudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InschrijvingStudent", x => new { x.InschrijvingenId, x.StudentenStudentId });
                    table.ForeignKey(
                        name: "FK_InschrijvingStudent_Inschrijvingen_InschrijvingenId",
                        column: x => x.InschrijvingenId,
                        principalTable: "Inschrijvingen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InschrijvingStudent_Studenten_StudentenStudentId",
                        column: x => x.StudentenStudentId,
                        principalTable: "Studenten",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vaklectoren",
                columns: table => new
                {
                    VakLectorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LectorId = table.Column<int>(type: "int", nullable: false),
                    InschrijvingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaklectoren", x => x.VakLectorId);
                    table.ForeignKey(
                        name: "FK_Vaklectoren_Inschrijvingen_InschrijvingId",
                        column: x => x.InschrijvingId,
                        principalTable: "Inschrijvingen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vaklectoren_Lectoren_LectorId",
                        column: x => x.LectorId,
                        principalTable: "Lectoren",
                        principalColumn: "LectorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Handboeken_StudentId",
                table: "Handboeken",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Handboeken_VakId",
                table: "Handboeken",
                column: "VakId");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijvingen_AcademiejaarId",
                table: "Inschrijvingen",
                column: "AcademiejaarId");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijvingen_VakId",
                table: "Inschrijvingen",
                column: "VakId");

            migrationBuilder.CreateIndex(
                name: "IX_InschrijvingStudent_StudentenStudentId",
                table: "InschrijvingStudent",
                column: "StudentenStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectoren_GebruikerId",
                table: "Lectoren",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_Studenten_GebruikerId",
                table: "Studenten",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaklectoren_InschrijvingId",
                table: "Vaklectoren",
                column: "InschrijvingId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaklectoren_LectorId",
                table: "Vaklectoren",
                column: "LectorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Handboeken");

            migrationBuilder.DropTable(
                name: "InschrijvingStudent");

            migrationBuilder.DropTable(
                name: "Vaklectoren");

            migrationBuilder.DropTable(
                name: "Studenten");

            migrationBuilder.DropTable(
                name: "Inschrijvingen");

            migrationBuilder.DropTable(
                name: "Lectoren");

            migrationBuilder.DropTable(
                name: "Academiejaren");

            migrationBuilder.DropTable(
                name: "Vakken");

            migrationBuilder.DropTable(
                name: "Gebruikers");
        }
    }
}
