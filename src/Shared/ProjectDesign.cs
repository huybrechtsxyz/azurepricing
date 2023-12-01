
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

    public ProjectDesign(Project project)
    {
        this.ProjectId = project.Id;
    }

    public ProjectDesign(ProjectDesign design)
    {
        UpdateFields(design);
    }

    [Key]
    [Required]
    [DisplayName("Design ID")]
    [Comment("Primary Key")]
    public int Id { get; set; }

    public int ProjectId { get; set; }

    [Required]
    [MaxLength(100)]
    [DisplayName("Name")]
    [Comment("Design name")]
    public string Name { get; set; } = string.Empty;

    [MaxLength(200)]
    [DisplayName("Description")]
    [Comment("Design description")]
    public string? Description { get; set; }

    [MaxLength(100)]
    [DisplayName("Environment")]
    [Comment("Design environment")]
    public string? Environment { get; set; } = string.Empty;

    public ICollection<ProjectComponent>? ProjectComponents { get; set; }

    public void UpdateFields(ProjectDesign design)
    {
        this.ProjectId = design.ProjectId;
        this.Name = design.Name;
        this.Description = design.Description;
        this.Environment = design.Environment;
    }
}
