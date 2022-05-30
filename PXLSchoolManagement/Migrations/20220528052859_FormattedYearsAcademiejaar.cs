using Microsoft.EntityFrameworkCore.Migrations;

namespace PXLSchoolManagement.Migrations
{
    public partial class FormattedYearsAcademiejaar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JarenGeformatteerd",
                table: "Academiejaren",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JarenGeformatteerd",
                table: "Academiejaren");
        }
    }
}
