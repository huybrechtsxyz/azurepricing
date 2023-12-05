
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureApp.Shared;

[Table("SetupDefaultUnit")]
public class SetupDefaultUnit
{
    public SetupDefaultUnit()
    {
    }

    public SetupDefaultUnit(SetupDefaultUnit unit)
    {
        UpdateFields(unit);
    }

    [Key]
    [Required]
    [DisplayName("Default Unit ID")]
    [Comment("Primary Key")]
    public int Id { get; set; }

    [DisplayName("System Unit")]
    [Comment("System Unit")]
    public int SetupMeasureUnitId { get; set; }

    public SetupMeasureUnit SetupMeasureUnit { get; set; } = null!;

    [Required]
    [MaxLength(30)]
    [DisplayName("Unit of Measure")]
    [Comment("Azure rate unit of measure")]
    public string UnitOfMeasure { get; set; } = String.Empty;

    [Required]
    [Precision(12, 6)]
    [DisplayName("Unit Factor")]
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

    public void UpdateFields(SetupDefaultUnit unit)
    {
        this.SetupMeasureUnitId = unit.SetupMeasureUnitId;
        this.UnitOfMeasure = unit.UnitOfMeasure;
        this.UnitFactor = unit.UnitFactor;
        this.DefaultValue = unit.DefaultValue;
        this.Description = unit.Description;
    }
}
