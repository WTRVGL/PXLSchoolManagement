using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PXLSchoolManagement.Migrations
{
    public partial class VaklectorLectorRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vaklectoren_LectorId",
                table: "Vaklectoren");

            migrationBuilder.CreateIndex(
                name: "IX_Vaklectoren_LectorId",
                table: "Vaklectoren",
                column: "LectorId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vaklectoren_LectorId",
                table: "Vaklectoren");

            migrationBuilder.CreateIndex(
                name: "IX_Vaklectoren_LectorId",
                table: "Vaklectoren",
                column: "LectorId");
        }
    }
}
