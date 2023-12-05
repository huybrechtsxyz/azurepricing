
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

    public ResourceUnit(ResourceRate resourceRate)
    {
        this.ResourceId = resourceRate.ResourceId;
        this.ResourceRateId = resourceRate.Id;
        this.UnitOfMeasure = resourceRate.UnitOfMeasure ?? string.Empty;
    }

    public ResourceUnit(ResourceUnit resourceUnit)
    {
        UpdateFields(resourceUnit);
    }

    public ResourceUnit(SetupDefaultUnit defaultUnit)
    {
        this.Id = 0;
        this.ResourceId = 0;
        this.ResourceRateId = 0;
        this.SetupMeasureUnitId = defaultUnit.SetupMeasureUnitId;
        this.UnitOfMeasure = defaultUnit.UnitOfMeasure;
        this.UnitFactor = defaultUnit.UnitFactor;
        this.DefaultValue = defaultUnit.DefaultValue;
        this.Description = defaultUnit.Description;
    }

    [Key]
    [Required]
    [DisplayName("Resource Unit ID")]
    [Comment("Primary Key")]
    public int Id { get; set; }

    public int ResourceId { get; set; }

    public int ResourceRateId { get; set; }

    [DisplayName("System Unit")]
    [Comment("System Unit")]
    public int SetupMeasureUnitId { get; set; }

    public SetupMeasureUnit SetupMeasureUnit { get; set; } = new();
    
    [Required]
    [MaxLength(30)]
    [DisplayName("Azure Unit of Measure")]
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

    public void UpdateFields(ResourceUnit resourceUnit, bool includeKeys = true)
    {
        if (includeKeys)
        { 
            this.ResourceId = resourceUnit.ResourceId;
            this.ResourceRateId = resourceUnit.ResourceRateId;
        }
        this.SetupMeasureUnitId = resourceUnit.SetupMeasureUnitId;
        this.UnitOfMeasure = resourceUnit.UnitOfMeasure;
        this.UnitFactor = resourceUnit.UnitFactor;
        this.DefaultValue = resourceUnit.DefaultValue;
        this.Description = resourceUnit.Description;
    }
}
