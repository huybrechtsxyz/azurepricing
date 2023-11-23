
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AzureApp.Shared;

[Table("SetupMeasuringUnit")]
public class SetupMeasureUnit
{
    public SetupMeasureUnit()
    {
    }

    [Key]
    [Required]
    [DisplayName("Measuring Unit ID")]
    [Comment("Primary Key")]
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    [DisplayName("Measuring Unit")]
    [Comment("Measuring unit")]
    public string Name { get; set; } = string.Empty;
}
