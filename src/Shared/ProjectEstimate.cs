
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

    [Key]
    [Required]
    [DisplayName("Estimate ID")]
    [Comment("Primary Key")]
    public int Id { get; set; }

    [Required]
    public int ProjectId { get; set; }

    [Required]
    public ProjectSimulation ProjectSimulation { get; set; } = new();
    public int ProjectSimulationId { get; set; }

    [Required]
    public int ProjectDesignId { get; set; }

    [Required]
    public int ProjectComponentId { get; set; }

    [Required]
    public int ProjectMeasureId { get; set; }

    [Required]
    public int ProjectScenarioId { get; set; }

    [Required]
    public int SetupMeasureUnitId { get; set; }

    [Required]
    public int ResourceId { get; set; }

    [Required]
    public int ResourceRateId { get; set; }

    //--------------------------------------------------------------------

    [MaxLength(100)]
    [DisplayName("Project")]
    [Comment("Project name")]
    public string? ProjectName { get; set; }

    [MaxLength(100)]
    [DisplayName("Design")]
    [Comment("Design name")]
    public string? DesignName { get; set; }

    [MaxLength(100)]
    [DisplayName("Environment")]
    [Comment("Design environment")]
    public string? Environment { get; set; } = string.Empty;

    [MaxLength(100)]
    [DisplayName("Component")]
    [Comment("Component name")]
    public string? ComponentName { get; set; }

    [MaxLength(100)]
    [DisplayName("Subscription")]
    [Comment("Component subscription")]
    public string? Subscription { get; set; } = string.Empty;

    [MaxLength(100)]
    [DisplayName("Resource Group")]
    [Comment("Component resource group")]
    public string? ResourceGroup { get; set; } = string.Empty;

    [MaxLength(100)]
    [DisplayName("Scenario")]
    [Comment("Scenario name")]
    public string ScenarioName { get; set; } = string.Empty;

    [MaxLength(30)]
    [DisplayName("Measuring Unit")]
    [Comment("Measuring unit")]
    public string? MeasuringUnitCode { get; set; }

    [MaxLength(100)]
    [DisplayName("Resource")]
    [Comment("Resource name")]
    public string? ResourceName { get; set; }

    [MaxLength(100)]
    [DisplayName("Resource Rate")]
    [Comment("Resource rate name")]
    public string? ResourceRateName { get; set; }

    [MaxLength(50)]
    [DisplayName("Location")]
    [Comment("Location name")]
    public string? Location { get; set; }

    [MaxLength(10)]
    [DisplayName("Currency Code")]
    [Comment("Currency code")]
    public string? CurrencyCode { get; set; }

    //--------------------------------------------------------------------

    [DisplayName("Created On")]
    [Comment("Estimate created on")]
    public DateTime CreatedOn { get; set; }

    [DisplayName("% Owned")]
    [Comment("Component % owned")]
    public int Owned { get; set; } = 0;

    [Precision(12,4)]
    [DisplayName("Estimated Cost")]
    [Comment("Estimated cost")]
    public decimal Cost { get; set; } = 0;

    [Precision(12, 4)]
    [DisplayName("Own Cost")]
    [Comment("Own cost")]
    public decimal OwnCost { get; set; } = 0;
}
