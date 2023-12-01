using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzureApp.Server.Migrations
{
    public partial class UpdateResourRateLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ResourceRate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Resource rate name",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Resource rate name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ResourceRate",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Resource rate name",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Resource rate name");
        }
    }
}
