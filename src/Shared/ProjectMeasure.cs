
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureApp.Shared;

[Table("ProjectMeasure")]
public class ProjectMeasure
{
    public ProjectMeasure()
    {
    }

    [Key]
    [Required]
    [DisplayName("Measure ID")]
    [Comment("Primary Key")]
    public int Id { get; set; }

    [Required]
    public int ProjectId { get; set; }

    [Required]
    public int ProjectDesignId { get; set; }

    [Required]
    public ProjectComponent ProjectComponent { get; set; } = new();
    public int ProjectComponentId { get; set; }

    [Required]
    public SetupMeasureUnit SetupMeasureUnit { get; set; } = new();
    public int SetupMeasureUnitId { get; set; }

    [MaxLength(200)]
    [DisplayName("Expression")]
    [Comment("Measure expression")]
    public string? Expression { get; set; }

    [MaxLength(200)]
    [DisplayName("Description")]
    [Comment("Measure Description")]
    public string? Description { get; set; }

    [MaxLength(200)]
    [DisplayName("Remark")]
    [Comment("Measure Remark")]
    public string? Remark { get; set; }
}
