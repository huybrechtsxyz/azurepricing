
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureApp.Shared;

[Table("ProjectScenario")]
public class ProjectScenario
{
    public ProjectScenario()
    {
    }

    [Key]
    [Required]
    [DisplayName("Scenario ID")]
    [Comment("Primary Key")]
    public int Id { get; set; }

    [Required]
    public Project Project { get; set; } = new();
    public int ProjectId { get; set; }

    [Required]
    [MaxLength(100)]
    [DisplayName("Name")]
    [Comment("Scenario name")]
    public string Name { get; set; } = string.Empty;

    [DisplayName("# Objects")]
    [Comment("Scenario objects")]
    public int DimObjects { get; set; } = 0;

    [DisplayName("Object size (Kb)")]
    [Comment("Scenario objects")]
    public int DimObjectSize { get; set; } = 0;

    [DisplayName("Request Size (Kb)")]
    [Comment("Scenario request size")]
    public int DimRequestSize { get; set; } = 0;

    [DisplayName("Request Factor")]
    [Comment("Scenario request factor")]
    public int DimRequestFactor { get; set; } = 0;

    [NotMapped]
    public decimal FactRequestsPerMonth => ((DimObjects * DimRequestFactor) / DimRequestSize / DimObjectSize);

    [NotMapped]
    public decimal FactBandwidthPerMonth => ( (DimRequestSize * FactRequestsPerMonth) / (1024 * 1024) );

    [NotMapped]
    public decimal FactRequestsPerHour => (FactRequestsPerMonth / 730);

    [NotMapped]
    public decimal FactBandwidthPerHour => (FactBandwidthPerMonth / 730);
}
