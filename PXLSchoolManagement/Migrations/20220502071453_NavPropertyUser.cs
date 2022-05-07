using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PXLSchoolManagement.Migrations
{
    public partial class NavPropertyUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GebruikerId",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_GebruikerId",
                table: "AspNetRoles",
                column: "GebruikerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_GebruikerId",
                table: "AspNetRoles",
                column: "GebruikerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_GebruikerId",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_GebruikerId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "GebruikerId",
                table: "AspNetRoles");
        }
    }
}
