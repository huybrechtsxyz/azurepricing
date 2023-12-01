using AzureApp.Client.Pages.Resources.Resource;
using AzureApp.Server.Data;
using AzureApp.Server.Services;
using AzureApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Resources;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace AzureApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchRateController : ControllerBase
    {
        private readonly ILogger<SearchRateController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        private readonly DbSet<SearchRate>? _dbset;

        public SearchRateController(
            ILogger<SearchRateController> logger,
            IConfiguration configuration,
            ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            if (_context.SearchRates is not null)
                _dbset = _context.SearchRates;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet("currencies")]
        public async Task<IActionResult> GetCurrencies()
        {
            if (_context.SetupCurrencies is null)
                return StatusCode(500, Array.Empty<SetupCurrency>());
            var model = await _context.SetupCurrencies.OrderBy(o => o.Code).ToListAsync();
            return Ok(model);
        }

        [HttpGet("locations")]
        public async Task<IActionResult> GetLocations()
        {
            if (_context.SetupLocations is null)
                return StatusCode(500, Array.Empty<SetupLocation>());
            var model = await _context.SetupLocations.OrderBy(o => o.Name).ToListAsync();
            return Ok(model);
        }

        [HttpGet("services")]
        public async Task<IActionResult> GetServices()
        {
            if (_context.SetupServices is null)
                return StatusCode(500, Array.Empty<SetupService>());
            var model = await _context.SetupServices.Where(q => q.Enabled == true).OrderBy(o => o.Name).ToListAsync();
            return Ok(model);
        }

        [HttpGet("resources")]
        public async Task<IActionResult> GetResources()
        {
            if (_context.Resources is null)
                return StatusCode(500, Array.Empty<AzureApp.Shared.Resource>());
            var model = await _context.Resources.OrderBy(o => o.Name).ToListAsync();
            if (model is null)
                model = new();
            model.Insert(0, new AzureApp.Shared.Resource()
            {
                Name = "<New Resource>"
            });
            return Ok(model);
        }

        [HttpPost("search")]
        public async Task<IActionResult> PostSearch(SearchParameters searchParameters)
        {
            AzurePricingService azurePricingService = new(_logger, _configuration);
            var services = await azurePricingService.GetRatesAsync(
                searchParameters.Service ?? string.Empty,
                searchParameters.Location ?? string.Empty,
                searchParameters.CurrencyCode ?? string.Empty
               );
            if (services is null)
                services = new();
            services = services
                .OrderBy(o => o.Service)
                .ThenBy(o => o.Product)
                .ThenBy(o => o.Type)
                .ThenBy(o => o.Sku)
                .ThenBy(o => o.MeterName)
                .ThenBy(o => o.Location)
                .ThenBy(o => o.CurrencyCode)
                .ThenBy(o => o.MiminumUnits)
                .ToList();
            return Ok(services);
        }

        [HttpPost("import")]
        public async Task<IActionResult> PostImport(List<SearchRate>? searchRates)
        {
            if (searchRates is null ||
                _context.Resources is null ||
                _context.ResourceRates is null ||
                _context.ResourceUnits is null ||
                _context.SetupDefaultUnits is null ||
                _context.SetupMeasureUnits is null)
                return StatusCode(500, Array.Empty<SearchRate>());

            List<SetupDefaultUnit> defaults = await _context.SetupDefaultUnits.OrderBy(o => o.UnitOfMeasure).ThenBy(o => o.SetupMeasureUnit.Name).ToListAsync();
            
            AzureApp.Shared.Resource? newResx;
            AzureApp.Shared.SearchRate? newRate = searchRates.FirstOrDefault(f => f.ResourceId == 0);
            if (newRate is not null)
            {
                newResx = new AzureApp.Shared.Resource(newRate);
                _context.Resources.Add(newResx);
                await _context.SaveChangesAsync();
                foreach(var item in searchRates.Where(q => q.ResourceId == 0))
                    item.ResourceId = newResx.Id;
            }

            foreach (var item in searchRates)
            {
                ResourceRate rate = new(item);
                _context.ResourceRates.Add(rate);
                await _context.SaveChangesAsync();

                foreach (var dft in defaults.Where(q => q.UnitOfMeasure == item.UnitOfMeasure))
                {
                    if (dft.SetupMeasureUnitId == 0 || dft.SetupMeasureUnit is null || string.IsNullOrEmpty(dft.SetupMeasureUnit.Name))
                        continue;

                    ResourceUnit unit = new(dft)
                    {
                        ResourceId = rate.ResourceId,
                        ResourceRateId = rate.Id
                    };
                    _context.ResourceUnits.Add(unit);
                    await _context.SaveChangesAsync();
                }
            }

            return Ok();
        }
    }
}
