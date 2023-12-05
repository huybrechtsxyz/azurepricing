
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AzureApp.Shared;

[Table("ResourceRate")]
public class ResourceRate
{
    public ResourceRate()
    {
    }

    public ResourceRate(Resource resource)
    {
        this.ResourceId = resource.Id;
        this.ServiceId = resource.ServiceId;
        this.Service = resource.Service;
        this.Category = resource.Category;
        this.ProductId = resource.ProductId;
        this.Product = resource.Product;
    }

    public ResourceRate(ResourceRate resourceRate)
    {
        UpdateFields(resourceRate);
    }

    public ResourceRate(SearchRate searchRate)
    {
        this.ResourceId = searchRate.ResourceId; 
        this.Name = searchRate.MeterName;
        if (this.Name.Length > 100)
            this.Name = this.Name[..100];
        this.ValidFrom = searchRate.ValidFrom;
        this.ServiceId = searchRate.ServiceId;
        this.Service = searchRate.Service;
        this.Category = searchRate.Category;
        this.Region = searchRate.Region;
        this.Location = searchRate.Location;
        this.CurrencyCode = searchRate.CurrencyCode;
        this.RetailPrice = searchRate.RetailPrice;
        this.UnitPrice = searchRate.UnitPrice;
        this.MiminumUnits = searchRate.MiminumUnits;
        this.UnitOfMeasure = searchRate.UnitOfMeasure;
        this.ProductId = searchRate.ProductId;
        this.Product = searchRate.Product;
        this.MeterId = searchRate.MeterId;
        this.MeterName = searchRate.MeterName;
        this.SkuId = searchRate.SkuId;
        this.Sku = searchRate.Sku;
        this.Type = searchRate.Type;
        this.IsPrimaryRegion = searchRate.IsPrimaryRegion;
    }

    [Key]
    [Required]
    [DisplayName("Resource Rate ID")]
    [Comment("Primary Key")]
    public int Id { get; set; }

    public int ResourceId { get; set; }

    [Required]
    [MaxLength(100)]
    [DisplayName("Name")]
    [Comment("Resource rate name")]
    public string Name { get; set; } = string.Empty;

    [DisplayName("Valid From")]
    [Comment("Rate is valid from")]
    public DateTime ValidFrom { get; set; }

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
    [DisplayName("Region")]
    [Comment("Region")]
    public string? Region { get; set; }

    [MaxLength(50)]
    [DisplayName("Location")]
    [Comment("Location name")]
    public string? Location { get; set; }

    [MaxLength(10)]
    [DisplayName("Currency Code")]
    [Comment("Currency code")]
    public string? CurrencyCode { get; set; }

    [Precision(12, 4)]
    [DisplayName("Retail Price")]
    [Comment("Retail price")]
    public decimal RetailPrice { get; set; }

    [Precision(12, 4)]
    [DisplayName("Unit Price")]
    [Comment("Unit price")]
    public decimal UnitPrice { get; set; }

    [Precision(12, 4)]
    [DisplayName("Miminum Units")]
    [Comment("Tier miminum units")]
    public decimal MiminumUnits { get; set; } = 0;

    [MaxLength(30)]
    [DisplayName("Unit of Measure")]
    [Comment("Azure rate unit of measure")]
    public string? UnitOfMeasure { get; set; }

    [MaxLength(50)]
    [DisplayName("Product ID")]
    [Comment("Product id")]
    public string? ProductId { get; set; }

    [MaxLength(100)]
    [DisplayName("Product")]
    [Comment("Product")]
    public string? Product { get; set; }

    [MaxLength(50)]
    [DisplayName("Meter ID")]
    [Comment("Meter id")]
    public string? MeterId { get; set; }

    [MaxLength(100)]
    [DisplayName("Meter Name")]
    [Comment("Meter name")]
    public string? MeterName { get; set; }

    [MaxLength(50)]
    [DisplayName("Sku ID")]
    [Comment("Sku id")]
    public string? SkuId { get; set; }

    [MaxLength(100)]
    [DisplayName("Sku")]
    [Comment("Sku name")]
    public string? Sku { get; set; }

    [MaxLength(100)]
    [DisplayName("Rate Type")]
    [Comment("Rate type")]
    public string? Type { get; set; }

    [DisplayName("Is Primary")]
    [Comment("Is primary meter region")]
    public bool? IsPrimaryRegion { get; set; }

    [NotMapped]
    public bool IsPrimaryRegionNN { get { return IsPrimaryRegion ?? false; } set { IsPrimaryRegion = value; } }

    public ICollection<ResourceUnit>? ResourceUnits { get; set; }

    public void UpdateFields(ResourceRate resourceRate)
    {
        this.ResourceId = resourceRate.ResourceId;
        this.Name = resourceRate.Name;
        this.ValidFrom = resourceRate.ValidFrom;
        this.ServiceId = resourceRate.ServiceId;
        this.Service = resourceRate.Service;
        this.Category = resourceRate.Category;
        this.Region = resourceRate.Region;
        this.Location = resourceRate.Location;
        this.CurrencyCode = resourceRate.CurrencyCode;
        this.RetailPrice = resourceRate.RetailPrice;
        this.UnitPrice = resourceRate.UnitPrice;
        this.MiminumUnits = resourceRate.MiminumUnits;
        this.UnitOfMeasure = resourceRate.UnitOfMeasure;
        this.ProductId = resourceRate.ProductId;
        this.Product = resourceRate.Product;
        this.MeterId = resourceRate.MeterId;
        this.MeterName = resourceRate.MeterName;
        this.SkuId = resourceRate.SkuId;
        this.Sku = resourceRate.Sku;
        this.Type = resourceRate.Type;
        this.IsPrimaryRegion = resourceRate.IsPrimaryRegion;
    }
}
