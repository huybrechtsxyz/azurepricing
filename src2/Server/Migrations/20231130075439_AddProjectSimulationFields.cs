using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzureApp.Server.Migrations
{
    public partial class AddProjectSimulationFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProjectSimulation",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                comment: "Simulation name");

            migrationBuilder.AlterColumn<int>(
                name: "ResourceId",
                table: "ProjectComponent",
                type: "int",
                nullable: false,
                comment: "Resource",
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProjectSimulation");

            migrationBuilder.AlterColumn<int>(
                name: "ResourceId",
                table: "ProjectComponent",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Resource");
        }
    }
}
