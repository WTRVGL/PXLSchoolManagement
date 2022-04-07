using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PXLSchoolManagement.Migrations
{
    public partial class ManyToManyStudentHandboek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Handboeken_Studenten_StudentId",
                table: "Handboeken");

            migrationBuilder.DropIndex(
                name: "IX_Handboeken_StudentId",
                table: "Handboeken");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Handboeken");

            migrationBuilder.CreateTable(
                name: "HandboekStudent",
                columns: table => new
                {
                    HandboekenHandboekId = table.Column<int>(type: "int", nullable: false),
                    StudentenStudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HandboekStudent", x => new { x.HandboekenHandboekId, x.StudentenStudentId });
                    table.ForeignKey(
                        name: "FK_HandboekStudent_Handboeken_HandboekenHandboekId",
                        column: x => x.HandboekenHandboekId,
                        principalTable: "Handboeken",
                        principalColumn: "HandboekId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HandboekStudent_Studenten_StudentenStudentId",
                        column: x => x.StudentenStudentId,
                        principalTable: "Studenten",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HandboekStudent_StudentenStudentId",
                table: "HandboekStudent",
                column: "StudentenStudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HandboekStudent");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Handboeken",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Handboeken_StudentId",
                table: "Handboeken",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Handboeken_Studenten_StudentId",
                table: "Handboeken",
                column: "StudentId",
                principalTable: "Studenten",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
