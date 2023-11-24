
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

    [Key]
    [Required]
    [DisplayName("Default Unit ID")]
    [Comment("Primary Key")]
    public int Id { get; set; }

    public int SetupMeasureUnitId { get; set; }

    [Required]
    [MaxLength(30)]
    [DisplayName("Azure Unit of Measure")]
    [Comment("Azure rate unit of measure")]
    public string AzureMeasure { get; set; } = String.Empty;
}
