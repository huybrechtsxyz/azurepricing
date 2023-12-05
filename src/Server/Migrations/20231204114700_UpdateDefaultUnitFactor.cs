using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzureApp.Server.Migrations
{
    public partial class UpdateDefaultUnitFactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "UnitFactor",
                table: "SetupDefaultUnit",
                type: "decimal(12,6)",
                precision: 12,
                scale: 6,
                nullable: false,
                comment: "Rate conversion factor",
                oldClrType: typeof(decimal),
                oldType: "decimal(12,4)",
                oldPrecision: 12,
                oldScale: 4,
                oldComment: "Rate conversion factor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "UnitFactor",
                table: "SetupDefaultUnit",
                type: "decimal(12,4)",
                precision: 12,
                scale: 4,
                nullable: false,
                comment: "Rate conversion factor",
                oldClrType: typeof(decimal),
                oldType: "decimal(12,6)",
                oldPrecision: 12,
                oldScale: 6,
                oldComment: "Rate conversion factor");
        }
    }
}
