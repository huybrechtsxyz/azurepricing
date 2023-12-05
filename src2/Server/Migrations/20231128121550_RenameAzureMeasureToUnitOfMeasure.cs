using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzureApp.Server.Migrations
{
    public partial class RenameAzureMeasureToUnitOfMeasure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AzureMeasure",
                table: "SetupDefaultUnit",
                newName: "UnitOfMeasure");

            migrationBuilder.RenameColumn(
                name: "AzureMeasure",
                table: "ResourceUnit",
                newName: "UnitOfMeasure");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SetupMeasuringUnit",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                comment: "System unit",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldComment: "Measuring unit");

            migrationBuilder.AlterColumn<int>(
                name: "SetupMeasureUnitId",
                table: "SetupDefaultUnit",
                type: "int",
                nullable: false,
                comment: "System Unit",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SetupMeasureUnitId",
                table: "ResourceUnit",
                type: "int",
                nullable: false,
                comment: "System Unit",
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitOfMeasure",
                table: "SetupDefaultUnit",
                newName: "AzureMeasure");

            migrationBuilder.RenameColumn(
                name: "UnitOfMeasure",
                table: "ResourceUnit",
                newName: "AzureMeasure");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SetupMeasuringUnit",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                comment: "Measuring unit",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldComment: "System unit");

            migrationBuilder.AlterColumn<int>(
                name: "SetupMeasureUnitId",
                table: "SetupDefaultUnit",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "System Unit");

            migrationBuilder.AlterColumn<int>(
                name: "SetupMeasureUnitId",
                table: "ResourceUnit",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "System Unit");
        }
    }
}
