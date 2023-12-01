using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzureApp.Server.Migrations
{
    public partial class AddProjectDesignDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProjectDesign",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "Design description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProjectDesign");
        }
    }
}
