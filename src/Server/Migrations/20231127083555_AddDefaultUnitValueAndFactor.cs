using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzureApp.Server.Migrations
{
    public partial class AddDefaultUnitValueAndFactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DefaultValue",
                table: "SetupDefaultUnit",
                type: "decimal(12,4)",
                precision: 12,
                scale: 4,
                nullable: false,
                defaultValue: 0m,
                comment: "Default unit rate");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SetupDefaultUnit",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                comment: "Measuring unit description");

            migrationBuilder.AddColumn<decimal>(
                name: "UnitFactor",
                table: "SetupDefaultUnit",
                type: "decimal(12,4)",
                precision: 12,
                scale: 4,
                nullable: false,
                defaultValue: 0m,
                comment: "Rate conversion factor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultValue",
                table: "SetupDefaultUnit");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "SetupDefaultUnit");

            migrationBuilder.DropColumn(
                name: "UnitFactor",
                table: "SetupDefaultUnit");
        }
    }
}
