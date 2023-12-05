using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzureApp.Server.Migrations
{
    public partial class RefactorForProjectEstimate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComponentName",
                table: "ProjectEstimate");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "ProjectEstimate");

            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "ProjectEstimate");

            migrationBuilder.DropColumn(
                name: "DesignName",
                table: "ProjectEstimate");

            migrationBuilder.DropColumn(
                name: "Environment",
                table: "ProjectEstimate");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "ProjectEstimate");

            migrationBuilder.DropColumn(
                name: "MeasuringUnitCode",
                table: "ProjectEstimate");

            migrationBuilder.DropColumn(
                name: "ProjectName",
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
                name: "ScenarioName",
                table: "ProjectEstimate");

            migrationBuilder.DropColumn(
                name: "SetupMeasureUnitId",
                table: "ProjectEstimate");

            migrationBuilder.DropColumn(
                name: "Subscription",
                table: "ProjectEstimate");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ProjectSimulation",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "Simulation name",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "Simulation name");

            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "ProjectSimulation",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                comment: "Currency code");

            migrationBuilder.AddColumn<string>(
                name: "Environment",
                table: "ProjectSimulation",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Design environment");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "ProjectSimulation",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "Location name");

            migrationBuilder.AddColumn<int>(
                name: "ProjectDesignId",
                table: "ProjectSimulation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Proposal",
                table: "ProjectSimulation",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Simulation for proposal");

            migrationBuilder.AddColumn<string>(
                name: "Variable",
                table: "ProjectMeasure",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                comment: "Measure variable");

            migrationBuilder.AlterColumn<int>(
                name: "ResourceRateId",
                table: "ProjectEstimate",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ResourceId",
                table: "ProjectEstimate",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectScenarioId",
                table: "ProjectEstimate",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectMeasureId",
                table: "ProjectEstimate",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "ProjectEstimate",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectDesignId",
                table: "ProjectEstimate",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectComponentId",
                table: "ProjectEstimate",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "ProjectEstimate",
                type: "decimal(12,4)",
                precision: 12,
                scale: 4,
                nullable: false,
                defaultValue: 0m,
                comment: "Estimate Quantity");

            migrationBuilder.AddColumn<decimal>(
                name: "RetailPrice",
                table: "ProjectEstimate",
                type: "decimal(12,4)",
                precision: 12,
                scale: 4,
                nullable: false,
                defaultValue: 0m,
                comment: "Retail price");

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "ProjectEstimate",
                type: "decimal(12,4)",
                precision: 12,
                scale: 4,
                nullable: false,
                defaultValue: 0m,
                comment: "Unit price");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSimulation_ProjectDesignId",
                table: "ProjectSimulation",
                column: "ProjectDesignId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectSimulation_ProjectDesign_ProjectDesignId",
                table: "ProjectSimulation",
                column: "ProjectDesignId",
                principalTable: "ProjectDesign",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSimulation_ProjectDesign_ProjectDesignId",
                table: "ProjectSimulation");

            migrationBuilder.DropIndex(
                name: "IX_ProjectSimulation_ProjectDesignId",
                table: "ProjectSimulation");

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

            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "ProjectSimulation");

            migrationBuilder.DropColumn(
                name: "Environment",
                table: "ProjectSimulation");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "ProjectSimulation");

            migrationBuilder.DropColumn(
                name: "ProjectDesignId",
                table: "ProjectSimulation");

            migrationBuilder.DropColumn(
                name: "Proposal",
                table: "ProjectSimulation");

            migrationBuilder.DropColumn(
                name: "Variable",
                table: "ProjectMeasure");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ProjectEstimate");

            migrationBuilder.DropColumn(
                name: "RetailPrice",
                table: "ProjectEstimate");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "ProjectEstimate");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ProjectSimulation",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                comment: "Simulation name",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true,
                oldComment: "Simulation name");

            migrationBuilder.AlterColumn<int>(
                name: "ResourceRateId",
                table: "ProjectEstimate",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ResourceId",
                table: "ProjectEstimate",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectScenarioId",
                table: "ProjectEstimate",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectMeasureId",
                table: "ProjectEstimate",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "ProjectEstimate",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectDesignId",
                table: "ProjectEstimate",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectComponentId",
                table: "ProjectEstimate",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComponentName",
                table: "ProjectEstimate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Component name");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "ProjectEstimate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Estimate created on");

            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "ProjectEstimate",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                comment: "Currency code");

            migrationBuilder.AddColumn<string>(
                name: "DesignName",
                table: "ProjectEstimate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Design name");

            migrationBuilder.AddColumn<string>(
                name: "Environment",
                table: "ProjectEstimate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Design environment");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "ProjectEstimate",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "Location name");

            migrationBuilder.AddColumn<string>(
                name: "MeasuringUnitCode",
                table: "ProjectEstimate",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                comment: "Measuring unit");

            migrationBuilder.AddColumn<string>(
                name: "ProjectName",
                table: "ProjectEstimate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Project name");

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
                nullable: true,
                comment: "Resource rate name");

            migrationBuilder.AddColumn<string>(
                name: "ScenarioName",
                table: "ProjectEstimate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "Scenario name");

            migrationBuilder.AddColumn<int>(
                name: "SetupMeasureUnitId",
                table: "ProjectEstimate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Subscription",
                table: "ProjectEstimate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Component subscription");
        }
    }
}
