using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzureApp.Server.Migrations
{
    public partial class UpdatedDefaultUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefaultUnit_SetupMeasuringUnit_SetupMeasureUnitId",
                table: "DefaultUnit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DefaultUnit",
                table: "DefaultUnit");

            migrationBuilder.RenameTable(
                name: "DefaultUnit",
                newName: "SetupDefaultUnit");

            migrationBuilder.RenameIndex(
                name: "IX_DefaultUnit_SetupMeasureUnitId",
                table: "SetupDefaultUnit",
                newName: "IX_SetupDefaultUnit_SetupMeasureUnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SetupDefaultUnit",
                table: "SetupDefaultUnit",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SetupDefaultUnit_SetupMeasuringUnit_SetupMeasureUnitId",
                table: "SetupDefaultUnit",
                column: "SetupMeasureUnitId",
                principalTable: "SetupMeasuringUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SetupDefaultUnit_SetupMeasuringUnit_SetupMeasureUnitId",
                table: "SetupDefaultUnit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SetupDefaultUnit",
                table: "SetupDefaultUnit");

            migrationBuilder.RenameTable(
                name: "SetupDefaultUnit",
                newName: "DefaultUnit");

            migrationBuilder.RenameIndex(
                name: "IX_SetupDefaultUnit_SetupMeasureUnitId",
                table: "DefaultUnit",
                newName: "IX_DefaultUnit_SetupMeasureUnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DefaultUnit",
                table: "DefaultUnit",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultUnit_SetupMeasuringUnit_SetupMeasureUnitId",
                table: "DefaultUnit",
                column: "SetupMeasureUnitId",
                principalTable: "SetupMeasuringUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
