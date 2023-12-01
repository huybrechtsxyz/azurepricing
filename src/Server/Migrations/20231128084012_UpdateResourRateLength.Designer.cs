﻿// <auto-generated />
using System;
using AzureApp.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AzureApp.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231128084012_UpdateResourRateLength")]
    partial class UpdateResourRateLength
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AzureApp.Shared.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Primary Key");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CurrencyCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasComment("Project currency");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Project name");

                    b.HasKey("Id");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("AzureApp.Shared.ProjectComponent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Primary Key");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Component Description");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Component location");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Component name");

                    b.Property<int>("Owned")
                        .HasColumnType("int")
                        .HasComment("Component % owned");

                    b.Property<string>("Owner")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Component owner");

                    b.Property<int>("ProjectDesignId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Remark")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Component Remark");

                    b.Property<string>("ResourceGroup")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Component resource group");

                    b.Property<int>("ResourceId")
                        .HasColumnType("int");

                    b.Property<string>("Subscription")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Component subscription");

                    b.HasKey("Id");

                    b.HasIndex("ProjectDesignId");

                    b.HasIndex("ResourceId");

                    b.ToTable("ProjectComponent");
                });

            modelBuilder.Entity("AzureApp.Shared.ProjectDesign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Primary Key");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Environment")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Design environment");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Design name");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectDesign");
                });

            modelBuilder.Entity("AzureApp.Shared.ProjectEstimate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Primary Key");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ComponentName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Component name");

                    b.Property<decimal>("Cost")
                        .HasPrecision(12, 4)
                        .HasColumnType("decimal(12,4)")
                        .HasComment("Estimated cost");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Estimate created on");

                    b.Property<string>("CurrencyCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasComment("Currency code");

                    b.Property<string>("DesignName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Design name");

                    b.Property<string>("Environment")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Design environment");

                    b.Property<string>("Location")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Location name");

                    b.Property<string>("MeasuringUnitCode")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Measuring unit");

                    b.Property<decimal>("OwnCost")
                        .HasPrecision(12, 4)
                        .HasColumnType("decimal(12,4)")
                        .HasComment("Own cost");

                    b.Property<int>("Owned")
                        .HasColumnType("int")
                        .HasComment("Component % owned");

                    b.Property<int>("ProjectComponentId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectDesignId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectMeasureId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Project name");

                    b.Property<int>("ProjectScenarioId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectSimulationId")
                        .HasColumnType("int");

                    b.Property<string>("ResourceGroup")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Component resource group");

                    b.Property<int>("ResourceId")
                        .HasColumnType("int");

                    b.Property<string>("ResourceName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Resource name");

                    b.Property<int>("ResourceRateId")
                        .HasColumnType("int");

                    b.Property<string>("ResourceRateName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Resource rate name");

                    b.Property<string>("ScenarioName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Scenario name");

                    b.Property<int>("SetupMeasureUnitId")
                        .HasColumnType("int");

                    b.Property<string>("Subscription")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Component subscription");

                    b.HasKey("Id");

                    b.HasIndex("ProjectSimulationId");

                    b.ToTable("ProjectEstimate");
                });

            modelBuilder.Entity("AzureApp.Shared.ProjectMeasure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Primary Key");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Measure Description");

                    b.Property<string>("Expression")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Measure expression");

                    b.Property<int>("ProjectComponentId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectDesignId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Remark")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Measure Remark");

                    b.Property<int>("SetupMeasureUnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectComponentId");

                    b.HasIndex("SetupMeasureUnitId");

                    b.ToTable("ProjectMeasure");
                });

            modelBuilder.Entity("AzureApp.Shared.ProjectScenario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Primary Key");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DimObjectSize")
                        .HasColumnType("int")
                        .HasComment("Scenario objects");

                    b.Property<int>("DimObjects")
                        .HasColumnType("int")
                        .HasComment("Scenario objects");

                    b.Property<int>("DimRequestFactor")
                        .HasColumnType("int")
                        .HasComment("Scenario request factor");

                    b.Property<int>("DimRequestSize")
                        .HasColumnType("int")
                        .HasComment("Scenario request size");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Scenario name");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectScenario");
                });

            modelBuilder.Entity("AzureApp.Shared.ProjectSimulation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Primary Key");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Estimate created on");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Simulation name");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectSimulation");
                });

            modelBuilder.Entity("AzureApp.Shared.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Primary Key");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AboutURL")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("About resource url");

                    b.Property<string>("Category")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Service category");

                    b.Property<string>("CostBasedOn")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Resource cost is based on");

                    b.Property<string>("CostDriver")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Resource cost driver");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Resource description");

                    b.Property<string>("Limitations")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Resource limitations");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Resource name");

                    b.Property<string>("PricingURL")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Resource link url");

                    b.Property<string>("Product")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Product");

                    b.Property<string>("ProductId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Product id");

                    b.Property<string>("Remarks")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasComment("Resource remarks");

                    b.Property<string>("Service")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Service name");

                    b.Property<string>("ServiceId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Service id");

                    b.Property<string>("Size")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Resource size");

                    b.HasKey("Id");

                    b.ToTable("Resource");
                });

            modelBuilder.Entity("AzureApp.Shared.ResourceRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Primary Key");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Category")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Service category");

                    b.Property<string>("CurrencyCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasComment("Currency code");

                    b.Property<bool?>("IsPrimaryRegion")
                        .HasColumnType("bit")
                        .HasComment("Is primary meter region");

                    b.Property<string>("Location")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Location name");

                    b.Property<string>("MeterId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Meter id");

                    b.Property<string>("MeterName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Meter name");

                    b.Property<decimal>("MiminumUnits")
                        .HasPrecision(12, 4)
                        .HasColumnType("decimal(12,4)")
                        .HasComment("Tier miminum units");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Resource rate name");

                    b.Property<string>("Product")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Product");

                    b.Property<string>("ProductId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Product id");

                    b.Property<string>("Region")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Region");

                    b.Property<int>("ResourceId")
                        .HasColumnType("int");

                    b.Property<decimal>("RetailPrice")
                        .HasPrecision(12, 4)
                        .HasColumnType("decimal(12,4)")
                        .HasComment("Retail price");

                    b.Property<string>("Service")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Service name");

                    b.Property<string>("ServiceId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Service id");

                    b.Property<string>("Sku")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Sku name");

                    b.Property<string>("SkuId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Sku id");

                    b.Property<string>("Type")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Rate type");

                    b.Property<string>("UnitOfMeasure")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Azure rate unit of measure");

                    b.Property<decimal>("UnitPrice")
                        .HasPrecision(12, 4)
                        .HasColumnType("decimal(12,4)")
                        .HasComment("Unit price");

                    b.Property<DateTime>("ValidFrom")
                        .HasColumnType("datetime2")
                        .HasComment("Rate is valid from");

                    b.HasKey("Id");

                    b.HasIndex("ResourceId");

                    b.ToTable("ResourceRate");
                });

            modelBuilder.Entity("AzureApp.Shared.ResourceUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Primary Key");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AzureMeasure")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Azure rate unit of measure");

                    b.Property<decimal>("DefaultValue")
                        .HasPrecision(12, 4)
                        .HasColumnType("decimal(12,4)")
                        .HasComment("Default unit rate");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Measuring unit description");

                    b.Property<int>("ResourceId")
                        .HasColumnType("int");

                    b.Property<int>("ResourceRateId")
                        .HasColumnType("int");

                    b.Property<int>("SetupMeasureUnitId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitFactor")
                        .HasPrecision(12, 4)
                        .HasColumnType("decimal(12,4)")
                        .HasComment("Rate conversion factor");

                    b.HasKey("Id");

                    b.HasIndex("ResourceRateId");

                    b.HasIndex("SetupMeasureUnitId");

                    b.ToTable("ResourceUnit");
                });

            modelBuilder.Entity("AzureApp.Shared.SearchRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Primary Key");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Category")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Service category");

                    b.Property<string>("CurrencyCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasComment("Currency code");

                    b.Property<bool?>("IsPrimaryRegion")
                        .HasColumnType("bit")
                        .HasComment("Is primary meter region");

                    b.Property<string>("Location")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Location name");

                    b.Property<string>("MeterId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Meter id");

                    b.Property<string>("MeterName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Meter name");

                    b.Property<decimal>("MiminumUnits")
                        .HasPrecision(12, 4)
                        .HasColumnType("decimal(12,4)")
                        .HasComment("Tier miminum units");

                    b.Property<string>("Product")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Product");

                    b.Property<string>("ProductId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Product id");

                    b.Property<string>("Region")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Region");

                    b.Property<decimal>("RetailPrice")
                        .HasPrecision(12, 4)
                        .HasColumnType("decimal(12,4)")
                        .HasComment("Retail price");

                    b.Property<string>("Service")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Service name");

                    b.Property<string>("ServiceId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Service id");

                    b.Property<string>("Sku")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Sku name");

                    b.Property<string>("SkuId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Sku id");

                    b.Property<string>("Type")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Rate type");

                    b.Property<string>("UnitOfMeasure")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Azure rate unit of measure");

                    b.Property<decimal>("UnitPrice")
                        .HasPrecision(12, 4)
                        .HasColumnType("decimal(12,4)")
                        .HasComment("Unit price");

                    b.Property<DateTime>("ValidFrom")
                        .HasColumnType("datetime2")
                        .HasComment("Rate is valid from");

                    b.HasKey("Id");

                    b.ToTable("SearchRate");
                });

            modelBuilder.Entity("AzureApp.Shared.SetupCurrency", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasComment("Primary Key");

                    b.HasKey("Code");

                    b.ToTable("SetupCurrency");
                });

            modelBuilder.Entity("AzureApp.Shared.SetupDefaultUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Primary Key");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AzureMeasure")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Azure rate unit of measure");

                    b.Property<decimal>("DefaultValue")
                        .HasPrecision(12, 4)
                        .HasColumnType("decimal(12,4)")
                        .HasComment("Default unit rate");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Measuring unit description");

                    b.Property<int>("SetupMeasureUnitId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitFactor")
                        .HasPrecision(12, 4)
                        .HasColumnType("decimal(12,4)")
                        .HasComment("Rate conversion factor");

                    b.HasKey("Id");

                    b.HasIndex("SetupMeasureUnitId");

                    b.ToTable("SetupDefaultUnit");
                });

            modelBuilder.Entity("AzureApp.Shared.SetupLocation", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Primary Key");

                    b.Property<string>("ShortName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Name");

                    b.ToTable("SetupLocation");
                });

            modelBuilder.Entity("AzureApp.Shared.SetupMeasureUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Primary Key");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Measuring unit");

                    b.HasKey("Id");

                    b.ToTable("SetupMeasuringUnit");
                });

            modelBuilder.Entity("AzureApp.Shared.SetupService", b =>
                {
                    b.Property<string>("ServiceId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Service id");

                    b.Property<string>("Category")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Service category");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit")
                        .HasComment("Is the service enabled?");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Service name");

                    b.HasKey("ServiceId");

                    b.ToTable("SetupService");
                });

            modelBuilder.Entity("AzureApp.Shared.ProjectComponent", b =>
                {
                    b.HasOne("AzureApp.Shared.ProjectDesign", "ProjectDesign")
                        .WithMany("Components")
                        .HasForeignKey("ProjectDesignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AzureApp.Shared.Resource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectDesign");

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("AzureApp.Shared.ProjectDesign", b =>
                {
                    b.HasOne("AzureApp.Shared.Project", "Project")
                        .WithMany("ProjectDesigns")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("AzureApp.Shared.ProjectEstimate", b =>
                {
                    b.HasOne("AzureApp.Shared.ProjectSimulation", "ProjectSimulation")
                        .WithMany("Estimates")
                        .HasForeignKey("ProjectSimulationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectSimulation");
                });

            modelBuilder.Entity("AzureApp.Shared.ProjectMeasure", b =>
                {
                    b.HasOne("AzureApp.Shared.ProjectComponent", "ProjectComponent")
                        .WithMany("Measures")
                        .HasForeignKey("ProjectComponentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AzureApp.Shared.SetupMeasureUnit", "SetupMeasureUnit")
                        .WithMany()
                        .HasForeignKey("SetupMeasureUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectComponent");

                    b.Navigation("SetupMeasureUnit");
                });

            modelBuilder.Entity("AzureApp.Shared.ProjectScenario", b =>
                {
                    b.HasOne("AzureApp.Shared.Project", "Project")
                        .WithMany("ProjectScenarios")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("AzureApp.Shared.ProjectSimulation", b =>
                {
                    b.HasOne("AzureApp.Shared.Project", "Project")
                        .WithMany("ProjectSimulations")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("AzureApp.Shared.ResourceRate", b =>
                {
                    b.HasOne("AzureApp.Shared.Resource", null)
                        .WithMany("ResourceRates")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AzureApp.Shared.ResourceUnit", b =>
                {
                    b.HasOne("AzureApp.Shared.ResourceRate", null)
                        .WithMany("ResourceUnits")
                        .HasForeignKey("ResourceRateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AzureApp.Shared.SetupMeasureUnit", "SetupMeasureUnit")
                        .WithMany()
                        .HasForeignKey("SetupMeasureUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SetupMeasureUnit");
                });

            modelBuilder.Entity("AzureApp.Shared.SetupDefaultUnit", b =>
                {
                    b.HasOne("AzureApp.Shared.SetupMeasureUnit", "SetupMeasureUnit")
                        .WithMany()
                        .HasForeignKey("SetupMeasureUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SetupMeasureUnit");
                });

            modelBuilder.Entity("AzureApp.Shared.Project", b =>
                {
                    b.Navigation("ProjectDesigns");

                    b.Navigation("ProjectScenarios");

                    b.Navigation("ProjectSimulations");
                });

            modelBuilder.Entity("AzureApp.Shared.ProjectComponent", b =>
                {
                    b.Navigation("Measures");
                });

            modelBuilder.Entity("AzureApp.Shared.ProjectDesign", b =>
                {
                    b.Navigation("Components");
                });

            modelBuilder.Entity("AzureApp.Shared.ProjectSimulation", b =>
                {
                    b.Navigation("Estimates");
                });

            modelBuilder.Entity("AzureApp.Shared.Resource", b =>
                {
                    b.Navigation("ResourceRates");
                });

            modelBuilder.Entity("AzureApp.Shared.ResourceRate", b =>
                {
                    b.Navigation("ResourceUnits");
                });
#pragma warning restore 612, 618
        }
    }
}
