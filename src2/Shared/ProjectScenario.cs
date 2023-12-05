
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

    public ProjectScenario(Project project)
    {
        this.ProjectId = project.Id;
    }

    [Key]
    [Required]
    [DisplayName("Scenario ID")]
    [Comment("Primary Key")]
    public int Id { get; set; }

    public int ProjectId { get; set; }
    
    [Required]
    [MaxLength(100)]
    [DisplayName("Name")]
    [Comment("Scenario name")]
    public string Name { get; set; } = string.Empty;

    [MaxLength(200)]
    [DisplayName("Description")]
    [Comment("Scenario description")]
    public string? Description { get; set; }

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
    [DisplayName("Requests per month")]
    public decimal FactRequestsPerMonth => decimal.Round((DimRequestSize != 0 && DimObjectSize != 0 ? (((decimal)DimObjects * (decimal)DimRequestFactor) / ((decimal)DimRequestSize / (decimal)DimObjectSize)) : 0),4);

    [NotMapped]
    [DisplayName("Bandwith per month")]
    public decimal FactBandwidthPerMonth => decimal.Round((((decimal)DimRequestSize * (decimal)FactRequestsPerMonth) / (decimal)(1024 * 1024)),4);

    [NotMapped]
    [DisplayName("Requests per hour")]
    public decimal FactRequestsPerHour => decimal.Round((FactRequestsPerMonth / (decimal)730),4);

    [NotMapped]
    [DisplayName("Bandwith per hour")]
    public decimal FactBandwidthPerHour => decimal.Round((FactBandwidthPerMonth / (decimal)730),4);

    public Dictionary<string, double> GetAsVariables()
    {
        return new Dictionary<string, double>()
        {
            { "objects" , this.DimObjects },
            { "objectsize" , this.DimObjectSize },
            { "requestsize" , this.DimRequestSize },
            { "requestfactor" , this.DimRequestFactor },
            { "requests" , (double)this.FactRequestsPerMonth },
            { "bandwidth" , (double)this.FactBandwidthPerMonth }
        };
    }

    public void UpdateFields(ProjectScenario scenario)
    {
        this.ProjectId = scenario.ProjectId;
        this.Name = scenario.Name;
        this.Description = scenario.Description;
        this.DimObjects = scenario.DimObjects;
        this.DimObjectSize = scenario.DimObjectSize;
        this.DimRequestFactor = scenario.DimRequestFactor;
        this.DimRequestSize = scenario.DimRequestSize;
    }
}
