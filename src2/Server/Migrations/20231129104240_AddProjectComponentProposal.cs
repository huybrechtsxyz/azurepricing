using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzureApp.Server.Migrations
{
    public partial class AddProjectComponentProposal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Proposal",
                table: "ProjectComponent",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Component proposal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Proposal",
                table: "ProjectComponent");
        }
    }
}
