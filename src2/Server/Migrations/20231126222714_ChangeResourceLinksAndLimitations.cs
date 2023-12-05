using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzureApp.Server.Migrations
{
    public partial class ChangeResourceLinksAndLimitations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResourceLimit");

            migrationBuilder.DropTable(
                name: "ResourceLink");

            migrationBuilder.AlterColumn<string>(
                name: "ShortName",
                table: "SetupLocation",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "AboutURL",
                table: "Resource",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                comment: "About resource url");

            migrationBuilder.AddColumn<string>(
                name: "Limitations",
                table: "Resource",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "Resource limitations");

            migrationBuilder.AddColumn<string>(
                name: "PricingURL",
                table: "Resource",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                comment: "Resource link url");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutURL",
                table: "Resource");

            migrationBuilder.DropColumn(
                name: "Limitations",
                table: "Resource");

            migrationBuilder.DropColumn(
                name: "PricingURL",
                table: "Resource");

            migrationBuilder.AlterColumn<string>(
                name: "ShortName",
                table: "SetupLocation",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ResourceLimit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary Key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceId = table.Column<int>(type: "int", nullable: false),
                    MeasuringUnit = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Measuring unit"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Resource limit name"),
                    Value = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: false, comment: "Resource limit value")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceLimit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceLimit_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceLink",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary Key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Resource link name"),
                    URL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "Resource link url")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceLink_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResourceLimit_ResourceId",
                table: "ResourceLimit",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceLink_ResourceId",
                table: "ResourceLink",
                column: "ResourceId");
        }
    }
}
