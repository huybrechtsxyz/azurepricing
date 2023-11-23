
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureApp.Shared;

[Table("ProjectDesign")]
public class ProjectDesign
{
    public ProjectDesign()
    {
    }

    [Key]
    [Required]
    [DisplayName("Design ID")]
    [Comment("Primary Key")]
    public int Id { get; set; }

    [Required]
    public Project Project { get; set; } = new();
    public int ProjectId { get; set; }

    [Required]
    [MaxLength(100)]
    [DisplayName("Name")]
    [Comment("Design name")]
    public string Name { get; set; } = string.Empty;

    [MaxLength(100)]
    [DisplayName("Environment")]
    [Comment("Design environment")]
    public string? Environment { get; set; } = string.Empty;

    public ICollection<ProjectComponent>? Components { get; set; }
}
