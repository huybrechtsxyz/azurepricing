using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzureApp.Server.Migrations
{
    public partial class ExtendProjectEstimate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectEstimate_Project_ProjectId",
                table: "ProjectEstimate");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectEstimate_ProjectComponent_ProjectComponentId",
                table: "ProjectEstimate");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectEstimate_ProjectScenario_ProjectScenarioId",
                table: "ProjectEstimate");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectEstimate_Resource_ResourceId",
                table: "ProjectEstimate");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectEstimate_ResourceRate_ResourceRateId",
                table: "ProjectEstimate");

            migrationBuilder.DropIndex(
                name: "IX_ProjectEstimate_ProjectComponentId",
                table: "ProjectEstimate");

            migrationBuilder.DropIndex(
                name: "IX_ProjectEstimate_ProjectId",
                table: "ProjectEstimate");

            migrationBuilder.DropIndex(
                name: "IX_ProjectEstimate_ProjectScenarioId",
                table: "ProjectEstimate");

            migrationBuilder.DropIndex(
                name: "IX_ProjectEstimate_ResourceId",
                table: "ProjectEstimate");

            migrationBuilder.DropIndex(
                name: "IX_ProjectEstimate_ResourceRateId",
                table: "ProjectEstimate");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "ProjectEstimate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Service category");

            migrationBuilder.AddColumn<string>(
                name: "ComponentOwner",
                table: "ProjectEstimate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Component owner");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "ProjectEstimate",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "Component location");

            migrationBuilder.AddColumn<string>(
                name: "MeterName",
                table: "ProjectEstimate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Meter name");

            migrationBuilder.AddColumn<decimal>(
                name: "MiminumUnits",
                table: "ProjectEstimate",
                type: "decimal(12,4)",
                precision: 12,
                scale: 4,
                nullable: false,
                defaultValue: 0m,
                comment: "Tier miminum units");

            migrationBuilder.AddColumn<string>(
                name: "Product",
                table: "ProjectEstimate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Product");

            migrationBuilder.AddColumn<string>(
                name: "ProductSku",
                table: "ProjectEstimate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Sku name");

            migrationBuilder.AddColumn<string>(
                name: "ProjectComponentName",
                table: "ProjectEstimate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "Component name");

            migrationBuilder.AddColumn<string>(
                name: "ProjectDesignName",
                table: "ProjectEstimate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Design name");

            migrationBuilder.AddColumn<string>(
                name: "ProjectName",
                table: "ProjectEstimate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Project name");

            migrationBuilder.AddColumn<string>(
                name: "ProjectScenarioName",
                table: "ProjectEstimate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Scenario name");

            migrationBuilder.AddColumn<string>(
                name: "RateType",
                table: "ProjectEstimate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Rate type");

            migrationBuilder.AddColumn<string>(
                name: "ResourceGroup",
                table: "ProjectEstimate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Component resource group");

            migrationBuilder.AddColumn<string>(
                name: "ResourceName",
                table: "ProjectEstimate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Resource name");

            migrationBuilder.AddColumn<string>(
                name: "ResourceRateName",
                table: "ProjectEstimate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "Resource rate name");

            migrationBuilder.AddColumn<string>(
                name: "Service",
                table: "ProjectEstimate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Service name");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "ProjectEstimate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Resource size");

            migrationBuilder.AddColumn<string>(
                name: "Subscription",
                table: "ProjectEstimate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Component subscription");

            migrationBuilder.AddColumn<string>(
                name: "UnitOfMeasure",
                table: "ProjectEstimate",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                comment: "Azure rate unit of measure");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "ProjectEstimate");

            migrationBuilder.DropColumn(
                name: "ComponentOwner",
                table: "ProjectEstimate");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "ProjectEstimate");

            migrationBuilder.DropColumn(
                name: "MeterName",
                table: "ProjectEstimate");

            migrationBuilder.DropColumn(
                name: "MiminumUnits",
                table: "ProjectEstimate");

            migrationBuilder.DropColumn(
                name: "Product",
                table: "ProjectEstimate");

            migrationBuilder.DropColumn(
                name: "ProductSku",
                table: "ProjectEstimate");

            migrationBuilder.DropColumn(
                name: "ProjectComponentName",
                table: "ProjectEstimate");

            migrationBuilder.DropColumn(
                name: "ProjectDesignName",
                table: "ProjectEstimate");

            migrationBuilder.DropColumn(
                name: "ProjectName",
                table: "ProjectEstimate");

            migrationBuilder.DropColumn(
                name: "ProjectScenarioName",
                table: "ProjectEstimate");

            migrationBuilder.DropColumn(
                name: "RateType",
                table: "ProjectEstimate");

            migrationBuilder.DropColumn(
                name: "ResourceGroup",
                table: "ProjectEstimate");

            migrationBuilder.DropColumn(
                name: "ResourceName",
                table: "ProjectEstimate");

            migrationBuilder.DropColumn(
                name: "ResourceRateName",
                table: "ProjectEstimate");

            migrationBuilder.DropColumn(
                name: "Service",
                table: "ProjectEstimate");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "ProjectEstimate");

            migrationBuilder.DropColumn(
                name: "Subscription",
                table: "ProjectEstimate");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasure",
                table: "ProjectEstimate");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEstimate_ProjectComponentId",
                table: "ProjectEstimate",
                column: "ProjectComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEstimate_ProjectId",
                table: "ProjectEstimate",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEstimate_ProjectScenarioId",
                table: "ProjectEstimate",
                column: "ProjectScenarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEstimate_ResourceId",
                table: "ProjectEstimate",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEstimate_ResourceRateId",
                table: "ProjectEstimate",
                column: "ResourceRateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectEstimate_Project_ProjectId",
                table: "ProjectEstimate",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectEstimate_ProjectComponent_ProjectComponentId",
                table: "ProjectEstimate",
                column: "ProjectComponentId",
                principalTable: "ProjectComponent",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectEstimate_ProjectScenario_ProjectScenarioId",
                table: "ProjectEstimate",
                column: "ProjectScenarioId",
                principalTable: "ProjectScenario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectEstimate_Resource_ResourceId",
                table: "ProjectEstimate",
                column: "ResourceId",
                principalTable: "Resource",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectEstimate_ResourceRate_ResourceRateId",
                table: "ProjectEstimate",
                column: "ResourceRateId",
                principalTable: "ResourceRate",
                principalColumn: "Id");
        }
    }
}
