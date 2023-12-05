
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureApp.Shared;

[Table("ProjectEstimate")]
public class ProjectEstimate
{
    public ProjectEstimate()
    {
    }

    public ProjectEstimate(ProjectSimulation simulation)
    {
        this.ProjectId = simulation.ProjectId;
        this.ProjectSimulationId = simulation.Id;
    }

    [Key]
    [Required]
    [DisplayName("Estimate ID")]
    [Comment("Primary Key")]
    public int Id { get; set; }

    public int? ProjectId { get; set; }

    public int ProjectSimulationId { get; set; }

    public int? ProjectDesignId { get; set; }

    public int? ProjectComponentId { get; set; }

    [Obsolete]
    public int? ProjectMeasureId { get; set; }

    public int? ProjectScenarioId { get; set; }

    public int? ResourceId { get; set; }

    public int? ResourceRateId { get; set; }

    //--------------------------------------------------------------------

    [Precision(20, 4)]
    [DisplayName("Quantity")]
    [Comment("Estimate Quantity")]
    public decimal Quantity { get; set; }

    [Precision(12, 4)]
    [DisplayName("Retail Price")]
    [Comment("Retail price")]
    public decimal RetailPrice { get; set; }

    [Precision(12, 4)]
    [DisplayName("Unit Price")]
    [Comment("Unit price")]
    public decimal UnitPrice { get; set; }

    [Precision(22, 2)]
    [DisplayName("Estimated Cost")]
    [Comment("Estimated cost")]
    public decimal Cost { get; set; } = 0;

    [DisplayName("% Owned")]
    [Comment("Component % owned")]
    public int Owned { get; set; } = 0;

    [Precision(22, 2)]
    [DisplayName("Own Cost")]
    [Comment("Own cost")]
    public decimal OwnCost { get; set; } = 0;

    public void CalculateCost()
    {
        this.Cost = decimal.Round(Quantity * RetailPrice, 2);
        this.OwnCost = decimal.Round(Cost * (Owned / 100), 2);
    }

    public void RoundNumbers()
    {
        this.Quantity = decimal.Round(this.Quantity, 4);
        this.RetailPrice = decimal.Round(this.RetailPrice, 4);
        this.UnitPrice = decimal.Round(this.UnitPrice, 4);
        this.Cost = decimal.Round(this.Cost, 2);
        this.OwnCost = decimal.Round(this.OwnCost, 2);
    }

    //--------------------------------------------------------------------

    [MaxLength(100)]
    [DisplayName("Project")]
    [Comment("Project name")]
    public string? ProjectName { get; set; }

    public void SetProjectFields(Project project)
    {
        this.ProjectId = project.Id;
        this.ProjectName = project.Name;
    }

    //--------------------------------------------------------------------

    [MaxLength(100)]
    [DisplayName("Scenario")]
    [Comment("Scenario name")]
    public string? ProjectScenarioName { get; set; }

    public void SetProjectScenarioFields(ProjectScenario scenario)
    {
        this.ProjectScenarioId = scenario.Id;
        this.ProjectScenarioName = scenario.Name;
    }

    //--------------------------------------------------------------------

    [MaxLength(100)]
    [DisplayName("Design")]
    [Comment("Design name")]
    public string? ProjectDesignName { get; set; }

    public void SetProjectDesignFields(ProjectDesign design)
    {
        this.ProjectDesignId = design.Id;
        this.ProjectDesignName = design.Name;
    }

    //--------------------------------------------------------------------

    [MaxLength(100)]
    [DisplayName("Component")]
    [Comment("Component name")]
    public string ProjectComponentName { get; set; } = string.Empty;

    [MaxLength(50)]
    [DisplayName("Location")]
    [Comment("Component location")]
    public string? Location { get; set; }

    [MaxLength(100)]
    [DisplayName("Subscription")]
    [Comment("Component subscription")]
    public string? Subscription { get; set; }

    [MaxLength(100)]
    [DisplayName("Resource Group")]
    [Comment("Component resource group")]
    public string? ResourceGroup { get; set; }

    [MaxLength(100)]
    [DisplayName("Owner")]
    [Comment("Component owner")]
    public string? ComponentOwner { get; set; }

    public void SetProjectComponentFields(ProjectComponent component)
    {
        this.ProjectComponentId = component.Id;
        this.ProjectComponentName = component.Name;
        this.Location = component.Location;
        this.Subscription = component.Subscription;
        this.ResourceGroup = component.ResourceGroup;
        this.ComponentOwner = component.Owner;
    }

    //--------------------------------------------------------------------

    [MaxLength(100)]
    [DisplayName("Resource")]
    [Comment("Resource name")]
    public string? ResourceName { get; set; }

    [MaxLength(100)]
    [DisplayName("Service")]
    [Comment("Service name")]
    public string? Service { get; set; }

    [MaxLength(100)]
    [DisplayName("Category")]
    [Comment("Service category")]
    public string? Category { get; set; }

    [MaxLength(100)]
    [DisplayName("Product")]
    [Comment("Product")]
    public string? Product { get; set; }

    [MaxLength(100)]
    [DisplayName("Size")]
    [Comment("Resource size")]
    public string? Size { get; set; }

    public void SetResourceFields(Resource resource)
    {
        this.ResourceId = resource.Id;
        this.ResourceName = resource.Name;
        this.Service = resource.Service;
        this.Product = resource.Product;
        this.Size = resource.Size;
    }

    //--------------------------------------------------------------------

    [MaxLength(100)]
    [DisplayName("Rate")]
    [Comment("Resource rate name")]
    public string ResourceRateName { get; set; } = string.Empty;

    [Precision(12, 4)]
    [DisplayName("Miminum Units")]
    [Comment("Tier miminum units")]
    public decimal MiminumUnits { get; set; } = 0;

    [MaxLength(30)]
    [DisplayName("Unit of Measure")]
    [Comment("Azure rate unit of measure")]
    public string? UnitOfMeasure { get; set; }

    [MaxLength(100)]
    [DisplayName("Meter Name")]
    [Comment("Meter name")]
    public string? MeterName { get; set; }

    [MaxLength(100)]
    [DisplayName("Sku")]
    [Comment("Sku name")]
    public string? ProductSku { get; set; }

    [MaxLength(100)]
    [DisplayName("Rate Type")]
    [Comment("Rate type")]
    public string? RateType { get; set; }

    public void SetResourceRateFields(ResourceRate rate)
    {
        this.ResourceRateId = rate.Id;
        this.ResourceRateName = rate.Name;
        this.RetailPrice = rate.RetailPrice;
        this.UnitPrice = rate.UnitPrice;
        this.MiminumUnits = rate.MiminumUnits;
        this.UnitOfMeasure = rate.UnitOfMeasure;
        this.MeterName = rate.MeterName;
        this.ProductSku = rate.Sku;
        this.RateType = rate.Type;
    }
}
