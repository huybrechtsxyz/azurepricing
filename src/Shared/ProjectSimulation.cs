
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

    [Key]
    [Required]
    [DisplayName("Simulation ID")]
    [Comment("Primary Key")]
    public int Id { get; set; }

    [Required]
    [ForeignKey(nameof(ProjectId))]
    public Project Project { get; set; } = new();
    public int ProjectId { get; set; }

    [Required]
    [MaxLength(100)]
    [DisplayName("Name")]
    [Comment("Simulation name")]
    public string Name { get; set; } = string.Empty;

    [DisplayName("Created On")]
    [Comment("Estimate created on")]
    public DateTime CreatedOn { get; set; }

    public ICollection<ProjectEstimate>? Estimates { get; set; }
}
