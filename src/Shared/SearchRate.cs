
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AzureApp.Shared;

[Table("SearchRate")]
public class SearchRate
{
    public SearchRate()
    {
    }

    [Key]
    [Required]
    [DisplayName("Search Rate ID")]
    [Comment("Primary Key")]
    public int Id { get; set; }

    [DisplayName("Valid From")]
    [Comment("Rate is valid from")]
    [JsonPropertyName("effectiveStartDate")]
    public DateTime ValidFrom { get; set; }

    [MaxLength(50)]
    [DisplayName("Service ID")]
    [Comment("Service id")]
    [JsonPropertyName("serviceId")]
    public string? ServiceId { get; set; }

    [MaxLength(100)]
    [DisplayName("Service")]
    [Comment("Service name")]
    [JsonPropertyName("serviceName")]
    public string? Service { get; set; }

    [MaxLength(100)]
    [DisplayName("Category")]
    [Comment("Service category")]
    [JsonPropertyName("serviceFamily")]
    public string? Category { get; set; }

    [MaxLength(50)]
    [DisplayName("Region")]
    [Comment("Region")]
    [JsonPropertyName("armRegionName")]
    public string? Region { get; set; }

    [MaxLength(50)]
    [DisplayName("Location")]
    [Comment("Location name")]
    [JsonPropertyName("location")]
    public string? Location { get; set; }

    [MaxLength(10)]
    [DisplayName("Currency Code")]
    [Comment("Currency code")]
    [JsonPropertyName("currencyCode")]
    public string? CurrencyCode { get; set; }

    [Precision(12, 4)]
    [DisplayName("Retail Price")]
    [Comment("Retail price")]
    [JsonPropertyName("retailPrice")]
    public decimal RetailPrice { get; set; }

    [Precision(12, 4)]
    [DisplayName("Unit Price")]
    [Comment("Unit price")]
    [JsonPropertyName("unitPrice")]
    public decimal UnitPrice { get; set; }

    [Precision(12, 4)]
    [DisplayName("Miminum Units")]
    [Comment("Tier miminum units")]
    [JsonPropertyName("tierMinimumUnits")]
    public decimal MiminumUnits { get; set; } = 0;

    [MaxLength(30)]
    [DisplayName("Unit of Measure")]
    [Comment("Azure rate unit of measure")]
    [JsonPropertyName("unitOfMeasure")]
    public string? UnitOfMeasure { get; set; }

    [MaxLength(50)]
    [DisplayName("Product ID")]
    [Comment("Product id")]
    [JsonPropertyName("productId")]
    public string? ProductId { get; set; }

    [MaxLength(100)]
    [DisplayName("Product")]
    [Comment("Product")]
    [JsonPropertyName("productName")]
    public string? Product { get; set; }

    [MaxLength(50)]
    [DisplayName("Meter ID")]
    [Comment("Meter id")]
    [JsonPropertyName("meterId")]
    public string? MeterId { get; set; }

    [MaxLength(100)]
    [DisplayName("Meter Name")]
    [Comment("Meter name")]
    [JsonPropertyName("meterName")]
    public string? MeterName { get; set; }

    [MaxLength(50)]
    [DisplayName("Sku ID")]
    [Comment("Sku id")]
    [JsonPropertyName("skuId")]
    public string? SkuId { get; set; }

    [MaxLength(100)]
    [DisplayName("Sku")]
    [Comment("Sku name")]
    [JsonPropertyName("skuName")]
    public string? Sku { get; set; }

    [MaxLength(100)]
    [DisplayName("Rate Type")]
    [Comment("Rate type")]
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [DisplayName("Is Primary")]
    [Comment("Is primary meter region")]
    [JsonPropertyName("isPrimaryMeterRegion")]
    public bool? IsPrimaryRegion { get; set; }

    [NotMapped]
    [DisplayName("Select")]
    [Comment("Selected?")]
    public bool? IsSelected { get; set; }
}
