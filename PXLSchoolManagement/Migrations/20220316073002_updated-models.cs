using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PXLSchoolManagement.Migrations
{
    public partial class updatedmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inschrijvingen_Vakken_VakId",
                table: "Inschrijvingen");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaklectoren_Inschrijvingen_InschrijvingId",
                table: "Vaklectoren");

            migrationBuilder.DropIndex(
                name: "IX_Vaklectoren_InschrijvingId",
                table: "Vaklectoren");

            migrationBuilder.DropColumn(
                name: "InschrijvingId",
                table: "Vaklectoren");

            migrationBuilder.AlterColumn<int>(
                name: "VakId",
                table: "Inschrijvingen",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "InschrijvingVaklector",
                columns: table => new
                {
                    InschrijvingenId = table.Column<int>(type: "int", nullable: false),
                    VaklectorsVakLectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InschrijvingVaklector", x => new { x.InschrijvingenId, x.VaklectorsVakLectorId });
                    table.ForeignKey(
                        name: "FK_InschrijvingVaklector_Inschrijvingen_InschrijvingenId",
                        column: x => x.InschrijvingenId,
                        principalTable: "Inschrijvingen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InschrijvingVaklector_Vaklectoren_VaklectorsVakLectorId",
                        column: x => x.VaklectorsVakLectorId,
                        principalTable: "Vaklectoren",
                        principalColumn: "VakLectorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InschrijvingVaklector_VaklectorsVakLectorId",
                table: "InschrijvingVaklector",
                column: "VaklectorsVakLectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inschrijvingen_Vakken_VakId",
                table: "Inschrijvingen",
                column: "VakId",
                principalTable: "Vakken",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inschrijvingen_Vakken_VakId",
                table: "Inschrijvingen");

            migrationBuilder.DropTable(
                name: "InschrijvingVaklector");

            migrationBuilder.AddColumn<int>(
                name: "InschrijvingId",
                table: "Vaklectoren",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "VakId",
                table: "Inschrijvingen",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Vaklectoren_InschrijvingId",
                table: "Vaklectoren",
                column: "InschrijvingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inschrijvingen_Vakken_VakId",
                table: "Inschrijvingen",
                column: "VakId",
                principalTable: "Vakken",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vaklectoren_Inschrijvingen_InschrijvingId",
                table: "Vaklectoren",
                column: "InschrijvingId",
                principalTable: "Inschrijvingen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
