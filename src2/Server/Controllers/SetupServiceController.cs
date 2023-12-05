using AzureApp.Server.Data;
using AzureApp.Server.Services;
using AzureApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace AzureApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SetupServiceController : ControllerBase
    {
        private readonly ILogger<SetupServiceController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        private readonly DbSet<SetupService>? _dbset;

        public SetupServiceController(
            ILogger<SetupServiceController> logger, 
            IConfiguration configuration,
            ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            if (_context.SetupServices is not null)
                _dbset = _context.SetupServices;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<SetupService>());

            var model = await _dbset.OrderBy(o => o.Name).ToListAsync();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<SetupService>());

            var model = await _dbset.FindAsync(id);
            if (model is null)
                return NotFound();

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SetupService model)
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<SetupService>());

            var item = await _dbset.FindAsync(model.ServiceId);
            if (item is not null)
            {
                ModelState.AddModelError(nameof(item.ServiceId), "Item already exists");
                return BadRequest(ModelState);
            }
            
            await _dbset.AddAsync(model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(SetupService model)
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<SetupService>());

            var item = await _dbset.FindAsync(model.ServiceId);
            if (item is null)
            {
                ModelState.AddModelError(nameof(item.Name), "Item does not exist");
                return BadRequest(ModelState);
            }

            item.UpdateFields(model);
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<SetupService>());

            var item = await _dbset.FindAsync(id);
            if (item is null)
                return NotFound();

            _dbset.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("refresh")]
        public async Task<IActionResult> Refresh()
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<SetupService>());

            AzurePricingService azurePricingService = new(_logger, _configuration);
            Dictionary<string, SetupService> azRates =  await azurePricingService.GetServicesAsync();
            List<SetupService> dbRates = await _dbset.ToListAsync();
            List<SetupService> newRates = new();

            foreach (var keyValuePair in azRates)
            {
                if (!dbRates.Any(q => q.ServiceId == keyValuePair.Key))
                {
                    newRates.Add(keyValuePair.Value);
                }
            }

            if(newRates.Any())
            {
                foreach(var value in newRates)
                {
                    _context.Add(value);
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Get));
        }
    }
}