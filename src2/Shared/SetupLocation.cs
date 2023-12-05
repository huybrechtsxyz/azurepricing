
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureApp.Shared;

[Table("SetupLocation")]
public class SetupLocation
{
    public SetupLocation()
    {
    }

    [Key]
    [Required]
    [MaxLength(50)]
    [DisplayName("Location")]
    [Comment("Primary Key")]
    public string Name { get; set; } = string.Empty;

    [MaxLength(30)]
    [DisplayName("Abbreviation")]
    public string? ShortName { get; set; }
}
