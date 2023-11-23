using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzureApp.Server.Migrations
{
    public partial class CreateInitialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary Key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Project name"),
                    CurrencyCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Project currency")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary Key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Resource name"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Resource description"),
                    CostDriver = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Resource cost driver"),
                    CostBasedOn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Resource cost is based on"),
                    ServiceId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Service id"),
                    Service = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Service name"),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Service category"),
                    ProductId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Product id"),
                    Product = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Product"),
                    Size = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Resource size"),
                    Remarks = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true, comment: "Resource remarks")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SearchRate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary Key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Rate is valid from"),
                    ServiceId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Service id"),
                    Service = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Service name"),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Service category"),
                    Region = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Region"),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Location name"),
                    CurrencyCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, comment: "Currency code"),
                    RetailPrice = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: false, comment: "Retail price"),
                    UnitPrice = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: false, comment: "Unit price"),
                    MiminumUnits = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: false, comment: "Tier miminum units"),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "Azure rate unit of measure"),
                    ProductId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Product id"),
                    Product = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Product"),
                    MeterId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Meter id"),
                    MeterName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Meter name"),
                    SkuId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Sku id"),
                    Sku = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Sku name"),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Rate type"),
                    IsPrimaryRegion = table.Column<bool>(type: "bit", nullable: true, comment: "Is primary meter region")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchRate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SetupCurrency",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Primary Key")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetupCurrency", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "SetupLocation",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Primary Key")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetupLocation", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "SetupMeasuringUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary Key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Measuring unit")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetupMeasuringUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SetupService",
                columns: table => new
                {
                    ServiceId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Service id"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Service name"),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Service category")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetupService", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectDesign",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary Key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Design name"),
                    Environment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Design environment")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDesign", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectDesign_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectScenario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary Key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Scenario name"),
                    DimObjects = table.Column<int>(type: "int", nullable: false, comment: "Scenario objects"),
                    DimObjectSize = table.Column<int>(type: "int", nullable: false, comment: "Scenario objects"),
                    DimRequestSize = table.Column<int>(type: "int", nullable: false, comment: "Scenario request size"),
                    DimRequestFactor = table.Column<int>(type: "int", nullable: false, comment: "Scenario request factor")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectScenario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectScenario_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectSimulation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary Key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Simulation name"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Estimate created on")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSimulation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectSimulation_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceLimit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary Key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Resource limit name"),
                    MeasuringUnit = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Measuring unit"),
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

            migrationBuilder.CreateTable(
                name: "ResourceRate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary Key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Resource rate name"),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Rate is valid from"),
                    ServiceId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Service id"),
                    Service = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Service name"),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Service category"),
                    Region = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Region"),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Location name"),
                    CurrencyCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, comment: "Currency code"),
                    RetailPrice = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: false, comment: "Retail price"),
                    UnitPrice = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: false, comment: "Unit price"),
                    MiminumUnits = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: false, comment: "Tier miminum units"),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "Azure rate unit of measure"),
                    ProductId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Product id"),
                    Product = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Product"),
                    MeterId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Meter id"),
                    MeterName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Meter name"),
                    SkuId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Sku id"),
                    Sku = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Sku name"),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Rate type"),
                    IsPrimaryRegion = table.Column<bool>(type: "bit", nullable: true, comment: "Is primary meter region")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceRate_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DefaultUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary Key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SetupMeasureUnitId = table.Column<int>(type: "int", nullable: false),
                    AzureMeasure = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Azure rate unit of measure")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefaultUnit_SetupMeasuringUnit_SetupMeasureUnitId",
                        column: x => x.SetupMeasureUnitId,
                        principalTable: "SetupMeasuringUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectComponent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary Key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ProjectDesignId = table.Column<int>(type: "int", nullable: false),
                    ResourceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Component name"),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Component location"),
                    Subscription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Component subscription"),
                    ResourceGroup = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Component resource group"),
                    Owner = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Component owner"),
                    Owned = table.Column<int>(type: "int", nullable: false, comment: "Component % owned"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Component Description"),
                    Remark = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Component Remark")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectComponent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectComponent_ProjectDesign_ProjectDesignId",
                        column: x => x.ProjectDesignId,
                        principalTable: "ProjectDesign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectComponent_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectEstimate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary Key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ProjectSimulationId = table.Column<int>(type: "int", nullable: false),
                    ProjectDesignId = table.Column<int>(type: "int", nullable: false),
                    ProjectComponentId = table.Column<int>(type: "int", nullable: false),
                    ProjectMeasureId = table.Column<int>(type: "int", nullable: false),
                    ProjectScenarioId = table.Column<int>(type: "int", nullable: false),
                    SetupMeasureUnitId = table.Column<int>(type: "int", nullable: false),
                    ResourceId = table.Column<int>(type: "int", nullable: false),
                    ResourceRateId = table.Column<int>(type: "int", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Project name"),
                    DesignName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Design name"),
                    Environment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Design environment"),
                    ComponentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Component name"),
                    Subscription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Component subscription"),
                    ResourceGroup = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Component resource group"),
                    ScenarioName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Scenario name"),
                    MeasuringUnitCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "Measuring unit"),
                    ResourceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Resource name"),
                    ResourceRateName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Resource rate name"),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Location name"),
                    CurrencyCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, comment: "Currency code"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Estimate created on"),
                    Owned = table.Column<int>(type: "int", nullable: false, comment: "Component % owned"),
                    Cost = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: false, comment: "Estimated cost"),
                    OwnCost = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: false, comment: "Own cost")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEstimate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectEstimate_ProjectSimulation_ProjectSimulationId",
                        column: x => x.ProjectSimulationId,
                        principalTable: "ProjectSimulation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary Key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceId = table.Column<int>(type: "int", nullable: false),
                    ResourceRateId = table.Column<int>(type: "int", nullable: false),
                    SetupMeasureUnitId = table.Column<int>(type: "int", nullable: false),
                    AzureMeasure = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Azure rate unit of measure"),
                    UnitFactor = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: false, comment: "Rate conversion factor"),
                    DefaultValue = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: false, comment: "Default unit rate"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Measuring unit description")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceUnit_ResourceRate_ResourceRateId",
                        column: x => x.ResourceRateId,
                        principalTable: "ResourceRate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceUnit_SetupMeasuringUnit_SetupMeasureUnitId",
                        column: x => x.SetupMeasureUnitId,
                        principalTable: "SetupMeasuringUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectMeasure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary Key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ProjectDesignId = table.Column<int>(type: "int", nullable: false),
                    ProjectComponentId = table.Column<int>(type: "int", nullable: false),
                    SetupMeasureUnitId = table.Column<int>(type: "int", nullable: false),
                    Expression = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Measure expression"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Measure Description"),
                    Remark = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Measure Remark")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectMeasure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectMeasure_ProjectComponent_ProjectComponentId",
                        column: x => x.ProjectComponentId,
                        principalTable: "ProjectComponent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectMeasure_SetupMeasuringUnit_SetupMeasureUnitId",
                        column: x => x.SetupMeasureUnitId,
                        principalTable: "SetupMeasuringUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DefaultUnit_SetupMeasureUnitId",
                table: "DefaultUnit",
                column: "SetupMeasureUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectComponent_ProjectDesignId",
                table: "ProjectComponent",
                column: "ProjectDesignId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectComponent_ResourceId",
                table: "ProjectComponent",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDesign_ProjectId",
                table: "ProjectDesign",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEstimate_ProjectSimulationId",
                table: "ProjectEstimate",
                column: "ProjectSimulationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMeasure_ProjectComponentId",
                table: "ProjectMeasure",
                column: "ProjectComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMeasure_SetupMeasureUnitId",
                table: "ProjectMeasure",
                column: "SetupMeasureUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectScenario_ProjectId",
                table: "ProjectScenario",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSimulation_ProjectId",
                table: "ProjectSimulation",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceLimit_ResourceId",
                table: "ResourceLimit",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceLink_ResourceId",
                table: "ResourceLink",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceRate_ResourceId",
                table: "ResourceRate",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceUnit_ResourceRateId",
                table: "ResourceUnit",
                column: "ResourceRateId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceUnit_SetupMeasureUnitId",
                table: "ResourceUnit",
                column: "SetupMeasureUnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DefaultUnit");

            migrationBuilder.DropTable(
                name: "ProjectEstimate");

            migrationBuilder.DropTable(
                name: "ProjectMeasure");

            migrationBuilder.DropTable(
                name: "ProjectScenario");

            migrationBuilder.DropTable(
                name: "ResourceLimit");

            migrationBuilder.DropTable(
                name: "ResourceLink");

            migrationBuilder.DropTable(
                name: "ResourceUnit");

            migrationBuilder.DropTable(
                name: "SearchRate");

            migrationBuilder.DropTable(
                name: "SetupCurrency");

            migrationBuilder.DropTable(
                name: "SetupLocation");

            migrationBuilder.DropTable(
                name: "SetupService");

            migrationBuilder.DropTable(
                name: "ProjectSimulation");

            migrationBuilder.DropTable(
                name: "ProjectComponent");

            migrationBuilder.DropTable(
                name: "ResourceRate");

            migrationBuilder.DropTable(
                name: "SetupMeasuringUnit");

            migrationBuilder.DropTable(
                name: "ProjectDesign");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
