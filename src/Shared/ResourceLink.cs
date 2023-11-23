
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureApp.Shared;

[Table("ResourceLink")]
public class ResourceLink
{
    public ResourceLink()
    {
    }

    [Key]
    [Required]
    [DisplayName("Resource Link ID")]
    [Comment("Primary Key")]
    public int Id { get; set; }

    [Required]
    public Resource Resource { get; set; } = new();
    public int ResourceId { get; set; }

    [MaxLength(100)]
    [DisplayName("Name")]
    [Comment("Resource link name")]
    public string? Name { get; set; }

    [MaxLength(500)]
    [DisplayName("Hyperlink")]
    [Comment("Resource link url")]
    public string? URL { get; set; }
}
