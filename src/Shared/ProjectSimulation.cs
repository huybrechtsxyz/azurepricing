
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureApp.Shared;

[Table("ProjectSimulation")]
public class ProjectSimulation
{
    public ProjectSimulation()
    {
    }

    public ProjectSimulation(Project project)
    {
        this.ProjectId = project.Id;
        this.CreatedOn = DateTime.Today;
    }

    public ProjectSimulation(ProjectSimulation simulation)
    {
        UpdateFields(simulation);
    }

    public void UpdateFields(ProjectSimulation simulation)
    {
        this.ProjectId = simulation.ProjectId;
        this.ProjectDesignId = simulation.ProjectDesignId;
        this.Name = simulation.Name;
        this.Proposal = simulation.Proposal;
        this.Description = simulation.Description;
        this.CreatedOn = simulation.CreatedOn;
    }

    [Key]
    [Required]
    [DisplayName("Simulation ID")]
    [Comment("Primary Key")]
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int? ProjectDesignId { get; set; }

    public ProjectDesign ProjectDesign { get; set; } = new();

    [Required]
    [MaxLength(100)]
    [DisplayName("Name")]
    [Comment("Simulation name")]
    public string Name { get; set; } = string.Empty;

    [MaxLength(100)]
    [DisplayName("Proposal")]
    [Comment("Simulation for proposal")]
    public string? Proposal { get; set; }

    [MaxLength(200)]
    [DisplayName("Name")]
    [Comment("Simulation name")]
    public string? Description { get; set; }

    //--------------------------------------------------------------------

    [DisplayName("Created On")]
    [Comment("Estimate created on")]
    public DateTime CreatedOn { get; set; }

    [MaxLength(100)]
    [DisplayName("Environment")]
    [Comment("Design environment")]
    public string? Environment { get; set; }

    [MaxLength(50)]
    [DisplayName("Location")]
    [Comment("Location name")]
    public string? Location { get; set; }

    [MaxLength(10)]
    [DisplayName("Currency Code")]
    [Comment("Currency code")]
    public string? CurrencyCode { get; set; }

    public ICollection<ProjectEstimate>? Estimates { get; set; }
}
