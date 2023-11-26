
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AzureApp.Shared;

[Table("Resource")]
public class Resource
{
    public Resource()
    {
    }

    [Key]
    [Required]
    [DisplayName("Resource ID")]
    [Comment("Primary Key")]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    [DisplayName("Name")]
    [Comment("Resource name")]
    public string Name { get; set; } = String.Empty;

    [MaxLength(200)]
    [DisplayName("Description")]
    [Comment("Resource description")]
    public string? Description { get; set; }

    [MaxLength(200)]
    [DisplayName("Cost Driver")]
    [Comment("Resource cost driver")]
    public string? CostDriver { get; set; }

    [MaxLength(100)]
    [DisplayName("Cost is Based on")]
    [Comment("Resource cost is based on")]
    public string? CostBasedOn { get; set; }

    [MaxLength(200)]
    [DisplayName("Limitations")]
    [Comment("Resource limitations")]
    public string? Limitations { get; set; }

    [MaxLength(500)]
    [DisplayName("About Link")]
    [Comment("About resource url")]
    public string? AboutURL { get; set; }

    [MaxLength(500)]
    [DisplayName("Pricing Link")]
    [Comment("Resource link url")]
    public string? PricingURL { get; set; }

    [MaxLength(50)]
    [DisplayName("Service ID")]
    [Comment("Service id")]
    public string? ServiceId { get; set; }

    [MaxLength(100)]
    [DisplayName("Service")]
    [Comment("Service name")]
    public string? Service { get; set; }

    [MaxLength(100)]
    [DisplayName("Category")]
    [Comment("Service category")]
    public string? Category { get; set; }

    [MaxLength(50)]
    [DisplayName("Product ID")]
    [Comment("Product id")]
    public string? ProductId { get; set; }

    [MaxLength(100)]
    [DisplayName("Product")]
    [Comment("Product")]
    public string? Product { get; set; }

    [MaxLength(100)]
    [DisplayName("Size")]
    [Comment("Resource size")]
    public string? Size { get; set; }

    [MaxLength(1000)]
    [DisplayName("Remarks")]
    [Comment("Resource remarks")]
    public string? Remarks { get; set; }

    [NotMapped]
    [DisplayName("Select")]
    [Comment("Is resource selected in list?")]
    public bool IsSelected { get; set; } = false;

    public ICollection<ResourceRate>? ResourceRates { get; set; }

    public void UpdateFields(Resource resource)
    {
        this.Name = resource.Name;
        this.Description = resource.Description;
        this.CostDriver = resource.CostDriver;
        this.CostBasedOn = resource.CostBasedOn;
        this.ServiceId = resource.ServiceId;
        this.Service = resource.Service;
        this.Category = resource.Category;
        this.ProductId = resource.ProductId;
        this.Product = resource.Product;
        this.Size = resource.Size;
        this.Remarks = resource.Remarks;
    }
}
