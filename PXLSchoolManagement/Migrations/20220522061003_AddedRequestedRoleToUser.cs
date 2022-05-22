using Microsoft.EntityFrameworkCore.Migrations;

namespace PXLSchoolManagement.Migrations
{
    public partial class AddedRequestedRoleToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTemporarilyAccount",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RequestedRoleId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RequestedRoleId",
                table: "AspNetUsers",
                column: "RequestedRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_RequestedRoleId",
                table: "AspNetUsers",
                column: "RequestedRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_RequestedRoleId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RequestedRoleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsTemporarilyAccount",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RequestedRoleId",
                table: "AspNetUsers");
        }
    }
}
