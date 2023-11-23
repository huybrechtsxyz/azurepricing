
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureApp.Shared;

[Table("Project")]
public class Project
{
    public Project()
    {
    }

    [Key]
    [Required]
    [DisplayName("Project ID")]
    [Comment("Primary Key")]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    [DisplayName("Name")]
    [Comment("Project name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(10)]
    [DisplayName("Currency Code")]
    [Comment("Project currency")]
    public string CurrencyCode { get; set; } = string.Empty;

    public ICollection<ProjectDesign>? ProjectDesigns { get; set; }

    public ICollection<ProjectScenario>? ProjectScenarios { get; set; }

    public ICollection<ProjectSimulation>? ProjectSimulations { get; set; }
}
