
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

    public Resource(SearchRate searchRate)
    {
        this.Name = searchRate.Product + " - " + searchRate.Sku;
        if (this.Name.Length > 100)
            this.Name = this.Name[..100];
        this.Description = string.Empty;
        this.CostDriver = string.Empty;
        this.CostBasedOn = string.Empty;
        this.ServiceId = searchRate.ServiceId;
        this.Service = searchRate.Service;
        this.Category = searchRate.Category;
        this.ProductId = searchRate.ProductId;
        this.Product = searchRate.Product;
        this.Size = searchRate.Sku;
        this.Remarks = string.Empty;
        this.AboutURL = string.Empty;
        this.PricingURL = string.Empty;
        this.Limitations = string.Empty;
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
    public string Name { get; set; } = string.Empty;

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
        this.PricingURL = resource.PricingURL;
        this.AboutURL = resource.AboutURL;
        this.Limitations = resource.Limitations;
        this.Remarks = resource.Remarks;
    }
}
