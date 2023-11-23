
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

    


    [Key]
    [Required]
    [DisplayName("Component ID")]
    [Comment("Primary Key")]
    public int Id { get; set; }

    [Required]
    public int ProjectId { get; set; }

    [Required]
    public ProjectDesign ProjectDesign { get; set; } = new();
    public int ProjectDesignId { get; set; }

    [Required]
    public Resource Resource { get; set; } = new();
    public int ResourceId { get; set; }

    [Required]
    [MaxLength(100)]
    [DisplayName("Name")]
    [Comment("Component name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    [DisplayName("Location")]
    [Comment("Component location")]
    public string Location { get; set; } = string.Empty;

    [MaxLength(100)]
    [DisplayName("Subscription")]
    [Comment("Component subscription")]
    public string? Subscription { get; set; } = string.Empty;

    [MaxLength(100)]
    [DisplayName("Resource Group")]
    [Comment("Component resource group")]
    public string? ResourceGroup { get; set; } = string.Empty;

    [MaxLength(100)]
    [DisplayName("Owner")]
    [Comment("Component owner")]
    public string? Owner { get; set; } = string.Empty;

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

    public ICollection<ProjectMeasure>? Measures { get; set; }
}
