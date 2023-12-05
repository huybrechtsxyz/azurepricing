
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

    public ProjectMeasure(ProjectComponent component)
    {
        this.ProjectId = component.ProjectId;
        this.ProjectDesignId = component.ProjectDesignId;
        this.ProjectComponentId = component.Id;
    }

    public ProjectMeasure(ProjectMeasure measure)
    {
        UpdateFields(measure);
    }

    [Key]
    [Required]
    [DisplayName("Measure ID")]
    [Comment("Primary Key")]
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int ProjectDesignId { get; set; }

    public int ProjectComponentId { get; set; }

    public int SetupMeasureUnitId { get; set; }
    public SetupMeasureUnit SetupMeasureUnit { get; set; } = new();

    [MaxLength(200)]
    [DisplayName("Variable")]
    [Comment("Measure variable")]
    public string Variable { get; set; } = string.Empty;

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

    [NotMapped]
    public double CalcQuantity = 0;

    public void UpdateFields(ProjectMeasure measure)
    {
        this.ProjectId = measure.ProjectId;
        this.ProjectDesignId = measure.ProjectDesignId;
        this.ProjectComponentId = measure.ProjectComponentId;
        this.SetupMeasureUnitId = measure.SetupMeasureUnitId;
        this.Variable = measure.Variable;
        this.Expression = measure.Expression;
        this.Description = measure.Description;
        this.Remark = measure.Remark;
    }
}
