using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PXLSchoolManagement.Migrations
{
    public partial class UserIdIsNowString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectoren_AspNetUsers_GebruikerId1",
                table: "Lectoren");

            migrationBuilder.DropForeignKey(
                name: "FK_Studenten_AspNetUsers_GebruikerId1",
                table: "Studenten");

            migrationBuilder.DropIndex(
                name: "IX_Studenten_GebruikerId1",
                table: "Studenten");

            migrationBuilder.DropIndex(
                name: "IX_Lectoren_GebruikerId1",
                table: "Lectoren");

            migrationBuilder.DropColumn(
                name: "GebruikerId1",
                table: "Studenten");

            migrationBuilder.DropColumn(
                name: "GebruikerId1",
                table: "Lectoren");

            migrationBuilder.AlterColumn<string>(
                name: "GebruikerId",
                table: "Studenten",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "GebruikerId",
                table: "Lectoren",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Studenten_GebruikerId",
                table: "Studenten",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectoren_GebruikerId",
                table: "Lectoren",
                column: "GebruikerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectoren_AspNetUsers_GebruikerId",
                table: "Lectoren",
                column: "GebruikerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Studenten_AspNetUsers_GebruikerId",
                table: "Studenten",
                column: "GebruikerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectoren_AspNetUsers_GebruikerId",
                table: "Lectoren");

            migrationBuilder.DropForeignKey(
                name: "FK_Studenten_AspNetUsers_GebruikerId",
                table: "Studenten");

            migrationBuilder.DropIndex(
                name: "IX_Studenten_GebruikerId",
                table: "Studenten");

            migrationBuilder.DropIndex(
                name: "IX_Lectoren_GebruikerId",
                table: "Lectoren");

            migrationBuilder.AlterColumn<int>(
                name: "GebruikerId",
                table: "Studenten",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "GebruikerId1",
                table: "Studenten",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GebruikerId",
                table: "Lectoren",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "GebruikerId1",
                table: "Lectoren",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Studenten_GebruikerId1",
                table: "Studenten",
                column: "GebruikerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Lectoren_GebruikerId1",
                table: "Lectoren",
                column: "GebruikerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectoren_AspNetUsers_GebruikerId1",
                table: "Lectoren",
                column: "GebruikerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Studenten_AspNetUsers_GebruikerId1",
                table: "Studenten",
                column: "GebruikerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
