
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureApp.Shared;

[Table("SetupMeasuringUnit")]
public class SetupMeasureUnit
{
    public static SetupMeasureUnit GetDefaultSetupMeasureUnit() => new() { Name = "Default" };

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
    [DisplayName("System Unit")]
    [Comment("System unit")]
    public string Name { get; set; } = null!;
}
