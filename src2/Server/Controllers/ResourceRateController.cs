using AzureApp.Server.Data;
using AzureApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace AzureApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResourceRateController : ControllerBase
    {
        private readonly ILogger<ResourceRateController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly DbSet<ResourceRate>? _dbset;

        public ResourceRateController(ILogger<ResourceRateController> logger, ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            if (_context.ResourceRates is not null)
                _dbset = _context.ResourceRates;
            _logger = logger;
        }

        [HttpGet("parent/{id}")]
        public async Task<IActionResult> GetResource(int id)
        {
            if (_context.Resources is null)
                return StatusCode(500, Array.Empty<SetupService>());
            var model = await _context.Resources.SingleAsync(q => q.Id == id);
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

        [HttpGet("locations")]
        public async Task<IActionResult> GetLocations()
        {
            if (_context.SetupLocations is null)
                return StatusCode(500, Array.Empty<SetupLocation>());
            var model = await _context.SetupLocations.OrderBy(o => o.Name).ToListAsync();
            return Ok(model);
        }

        [HttpGet("currencies")]
        public async Task<IActionResult> GetCurrencies()
        {
            if (_context.SetupCurrencies is null)
                return StatusCode(500, Array.Empty<SetupCurrency>());
            var model = await _context.SetupCurrencies.OrderBy(o => o.Code).ToListAsync();
            return Ok(model);
        }

        [HttpGet("list/{id}")]
        public async Task<IActionResult> GetList(int id)
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<ResourceRate>());

            var model = await _dbset.Where(q => q.ResourceId == id).ToListAsync();
            if (model is null)
                return NotFound();

            return Ok(model);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            if (_dbset is null)
                return StatusCode(500, new ResourceRate());

            var model = await _dbset.SingleAsync(q => q.Id == id);
            if (model is null)
                return NotFound();

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ResourceRate model)
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<ResourceRate>());

            var item = await _dbset.FindAsync(model.Id);
            if (item is not null)
            {
                ModelState.AddModelError(nameof(item.Id), "Item already exists");
                return BadRequest(ModelState);
            }

            item = new(model)
            {
                Id = 0
            };
            await _dbset.AddAsync(item);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(ResourceRate model)
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<ResourceRate>());

            var item = await _dbset.FindAsync(model.Id);
            if (item is null)
            {
                ModelState.AddModelError(nameof(item.Id), "Item does not exist");
                return BadRequest(ModelState);
            }

            item.UpdateFields(model);
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<ResourceRate>());

            var item = await _dbset.FindAsync(id);
            if (item is null)
                return NotFound();

            _dbset.Remove(item);
            _context.SaveChanges();
            return Ok();
        }
    }
}