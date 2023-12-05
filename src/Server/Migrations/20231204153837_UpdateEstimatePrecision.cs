using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzureApp.Server.Migrations
{
    public partial class UpdateEstimatePrecision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "ProjectEstimate",
                type: "decimal(20,4)",
                precision: 20,
                scale: 4,
                nullable: false,
                comment: "Estimate Quantity",
                oldClrType: typeof(decimal),
                oldType: "decimal(12,4)",
                oldPrecision: 12,
                oldScale: 4,
                oldComment: "Estimate Quantity");

            migrationBuilder.AlterColumn<decimal>(
                name: "OwnCost",
                table: "ProjectEstimate",
                type: "decimal(22,2)",
                precision: 22,
                scale: 2,
                nullable: false,
                comment: "Own cost",
                oldClrType: typeof(decimal),
                oldType: "decimal(12,4)",
                oldPrecision: 12,
                oldScale: 4,
                oldComment: "Own cost");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "ProjectEstimate",
                type: "decimal(22,2)",
                precision: 22,
                scale: 2,
                nullable: false,
                comment: "Estimated cost",
                oldClrType: typeof(decimal),
                oldType: "decimal(12,4)",
                oldPrecision: 12,
                oldScale: 4,
                oldComment: "Estimated cost");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "ProjectEstimate",
                type: "decimal(12,4)",
                precision: 12,
                scale: 4,
                nullable: false,
                comment: "Estimate Quantity",
                oldClrType: typeof(decimal),
                oldType: "decimal(20,4)",
                oldPrecision: 20,
                oldScale: 4,
                oldComment: "Estimate Quantity");

            migrationBuilder.AlterColumn<decimal>(
                name: "OwnCost",
                table: "ProjectEstimate",
                type: "decimal(12,4)",
                precision: 12,
                scale: 4,
                nullable: false,
                comment: "Own cost",
                oldClrType: typeof(decimal),
                oldType: "decimal(22,2)",
                oldPrecision: 22,
                oldScale: 2,
                oldComment: "Own cost");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "ProjectEstimate",
                type: "decimal(12,4)",
                precision: 12,
                scale: 4,
                nullable: false,
                comment: "Estimated cost",
                oldClrType: typeof(decimal),
                oldType: "decimal(22,2)",
                oldPrecision: 22,
                oldScale: 2,
                oldComment: "Estimated cost");
        }
    }
}
