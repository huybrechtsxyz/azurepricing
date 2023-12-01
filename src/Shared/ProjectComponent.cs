
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureApp.Shared;

[Table("ProjectComponent")]
public class ProjectComponent
{
    public ProjectComponent()
    {
    }

    public ProjectComponent(Project project)
    {
        this.ProjectId = project.Id;
    }

    public ProjectComponent(ProjectDesign design)
    {
        this.ProjectId = design.ProjectId;
        this.ProjectDesignId = design.Id;
    }

    public ProjectComponent(ProjectComponent component)
    {
        UpdateFields(component);
    }


    [Key]
    [Required]
    [DisplayName("Component ID")]
    [Comment("Primary Key")]
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int ProjectDesignId { get; set; }

    [DisplayName("Resource")]
    [Comment("Resource")]
    public int ResourceId { get; set; }
    public Resource Resource { get; set; } = new();
    
    [Required]
    [MaxLength(100)]
    [DisplayName("Name")]
    [Comment("Component name")]
    public string Name { get; set; } = string.Empty;

    [MaxLength(100)]
    [DisplayName("Proposal")]
    [Comment("Component proposal")]
    public string? Proposal { get; set; }

    [Required]
    [MaxLength(50)]
    [DisplayName("Location")]
    [Comment("Component location")]
    public string Location { get; set; } = string.Empty;

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
    public string? Owner { get; set; }

    [DisplayName("% Owned")]
    [Comment("Component % owned")]
    public int Owned { get; set; } = 0;

    [MaxLength(200)]
    [DisplayName("Description")]
    [Comment("Component Description")]
    public string? Description { get; set; }

    [MaxLength(200)]
    [DisplayName("Remark")]
    [Comment("Component Remark")]
    public string? Remark { get; set; }

    public ICollection<ProjectMeasure>? ProjectMeasures { get; set; }

    public void UpdateFields(ProjectComponent component)
    {
        this.ProjectId = component.ProjectId;
        this.ProjectDesignId = component.ProjectDesignId;
        this.ResourceId = component.ResourceId;
        this.Name = component.Name;
        this.Proposal = component.Proposal;
        this.Location = component.Location;
        this.Subscription = component.Subscription;
        this.ResourceGroup = component.ResourceGroup;
        this.Owner = component.Owner;
        this.Owned = component.Owned;
        this.Description = component.Description;
        this.Remark = component.Remark;
    }
}
