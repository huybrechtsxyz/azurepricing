
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureApp.Shared;

[Table("SetupService")]
public class SetupService
{
    public SetupService()
    {
    }

    [Key]
    [MaxLength(50)]
    [DisplayName("Service ID")]
    [Comment("Service id")]
    public string? ServiceId { get; set; }

    [MaxLength(100)]
    [DisplayName("Service")]
    [Comment("Service name")]
    public string? Name { get; set; }

    [MaxLength(100)]
    [DisplayName("Category")]
    [Comment("Service category")]
    public string? Category { get; set; }

    [DisplayName("Is Enabled?")]
    [Comment("Is the service enabled?")]
    public bool Enabled { get; set; } = false;



    public void UpdateFields(SetupService service)
    {
        this.Name = service.Name;
        this.Category = service.Category;
        this.Enabled = service.Enabled;
    }
}
