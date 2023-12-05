using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzureApp.Server.Migrations
{
    public partial class AddServiceEnabled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "SetupService",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is the service enabled?");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "SetupService");
        }
    }
}
