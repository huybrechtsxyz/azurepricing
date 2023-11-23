
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureApp.Shared;

[Table("ResourceLimit")]
public class ResourceLimit
{
    public ResourceLimit()
    {
    }

    [Key]
    [Required]
    [DisplayName("Resource Limit ID")]
    [Comment("Primary Key")]
    public int Id { get; set; }

    [Required]
    public Resource Resource { get; set; } = new();
    public int ResourceId { get; set; }

    [Required]
    [MaxLength(100)]
    [DisplayName("Name")]
    [Comment("Resource limit name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(30)]
    [DisplayName("Measuring Unit")]
    [Comment("Measuring unit")]
    public string MeasuringUnit { get; set; } = string.Empty;

    [Precision(12, 4)]
    [DisplayName("Value")]
    [Comment("Resource limit value")]
    public decimal Value { get; set; } = 0;
}
