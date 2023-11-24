using AzureApp.Server.Models;
using AzureApp.Shared;
using System.Text.Json;

namespace AzureApp.Server.Services;

public class AzurePricingService
{
	private readonly ILogger logger;
	private readonly IConfiguration configuration;

	public AzurePricingService(ILogger logger, IConfiguration configuration)
	{
		this.logger = logger;
		this.configuration = configuration;
	}

	public async Task<Dictionary<string,SetupService>> GetServicesAsync()
	{
        Dictionary<string, SetupService> rates = new();
		AzurePrices? results;
		bool loop;

		string url = configuration.GetSection("AzureServices").GetSection("ServicesUrl").Value.ToString();

		do
		{
			results = await GetAzurePricesAsync(url);
			if (results is null)
				return rates;

			foreach (var item in results.Items)
			{
				if (item is not null && !string.IsNullOrEmpty(item.ServiceId) && !rates.ContainsKey(item.ServiceId))
				{
					rates.Add(item.ServiceId, new SetupService()
					{
						ServiceId = item.ServiceId,
						Name = item.Service,
						Category = item.Category,
						Enabled = false
					});
				}
			}

			url = results.NextPageLink;
			loop = !string.IsNullOrEmpty(url);
		}
		while (loop);

		return rates;
    }

    private async Task<AzurePrices> GetAzurePricesAsync(string url)
    {
        Uri serviceUrl = new(url);
        HttpClient httpClient = new();
        var response = await httpClient.GetAsync(serviceUrl);
        response.EnsureSuccessStatusCode();
        AzurePrices results = JsonSerializer.Deserialize<AzurePrices>(await response.Content.ReadAsStringAsync()) ?? new();
        response.Dispose();
		return results;
    }
}
