
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureApp.Shared;

[Table("ResourceUnit")]
public class ResourceUnit
{
    public ResourceUnit()
    {
    }

    public ResourceUnit(SetupDefaultUnit defaultUnit)
    {
        this.Id = 0;
        this.ResourceId = 0;
        this.ResourceRateId = 0;
        this.SetupMeasureUnitId = defaultUnit.SetupMeasureUnitId;
        this.AzureMeasure = defaultUnit.AzureMeasure;
        this.UnitFactor = 1;
        this.DefaultValue = 1;
        this.Description = string.Empty;
    }

    [Key]
    [Required]
    [DisplayName("Resource Unit ID")]
    [Comment("Primary Key")]
    public int Id { get; set; }

    [Required]
    public int ResourceId { get; set; }

    [Required]
    public ResourceRate ResourceRate { get; set; } = new();
    public int ResourceRateId { get; set; }

    [Required]
    public SetupMeasureUnit SetupMeasureUnit { get; set; } = new();
    public int SetupMeasureUnitId { get; set; }

    [Required]
    [MaxLength(30)]
    [DisplayName("Azure Unit of Measure")]
    [Comment("Azure rate unit of measure")]
    public string AzureMeasure { get; set; } = String.Empty;

    [Required]
    [Precision(12, 4)]
    [DisplayName("Conversion Factor")]
    [Comment("Rate conversion factor")]
    public decimal UnitFactor { get; set; } = 0;

    [Required]
    [Precision(12, 4)]
    [DisplayName("Default unit")]
    [Comment("Default unit rate")]
    public decimal DefaultValue { get; set; } = 0;

    [MaxLength(200)]
    [DisplayName("Description")]
    [Comment("Measuring unit description")]
    public string Description { get; set; } = string.Empty;
}
