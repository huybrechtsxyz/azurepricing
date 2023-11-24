using AzureApp.Shared;
using System.Text.Json.Serialization;

namespace AzureApp.Server.Models
{
    public class AzurePrices
    {
        [JsonPropertyName("BillingCurrency")]
        public string BillingCurrency { get; set; } = string.Empty;

        [JsonPropertyName("CustomerEntityId")]
        public string CustomerEntityId { get; set; } = string.Empty;

        [JsonPropertyName("CustomerEntityType")]
        public string CustomerEntityType { get; set; } = string.Empty;

        [JsonPropertyName("Items")]
        public List<SearchRate> Items { get; set; } = new();

        [JsonPropertyName("NextPageLink")]
        public string NextPageLink { get; set; } = string.Empty;

        [JsonPropertyName("Count")]
        public int Count { get; set; } = 0;
    }
}
