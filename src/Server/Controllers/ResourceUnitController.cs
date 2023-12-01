using AzureApp.Server.Data;
using AzureApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace AzureApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResourceUnitController : ControllerBase
    {
        private readonly ILogger<ResourceUnitController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly DbSet<ResourceUnit>? _dbset;

        public ResourceUnitController(ILogger<ResourceUnitController> logger, ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            if (_context.ResourceUnits is not null)
                _dbset = _context.ResourceUnits;
            _logger = logger;
        }

        [HttpGet("measures")]
        public async Task<IActionResult> GetMeasures()
        {
            if (_context.SetupMeasureUnits is null)
                return StatusCode(500, Array.Empty<SetupMeasureUnit>());
            var model = await _context.SetupMeasureUnits.OrderBy(o => o.Name).ToListAsync();
            return Ok(model);
        }

        [HttpGet("parent/{id}")]
        public async Task<IActionResult> GetParent(int id)
        {
            if (_context.ResourceRates is null)
                return StatusCode(500);

            var model = await _context.ResourceRates
                .Where(q => q.Id == id)
                .SingleAsync();
            return Ok(model);
        }

        [HttpGet("list/{id}")]
        public async Task<IActionResult> GetList(int id)
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<ResourceUnit>());

            var model = await _dbset
                .Include(i => i.SetupMeasureUnit)
                .Where(q => q.ResourceRateId == id)
                .OrderBy(o => o.UnitOfMeasure)
                .ThenBy(o => o.SetupMeasureUnit.Name)
                .ToListAsync();
            return Ok(model);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<ResourceUnit>());

            var model = await _dbset.Include(i => i.SetupMeasureUnit).SingleAsync(q => q.Id == id);
            if (model is null)
                return NotFound();

            return Ok(model);
        }

        [HttpGet("create/{id}")]
        public async Task<IActionResult> PostDefaults(int id)
        {
            if (_dbset is null ||
                _context.ResourceRates is null ||
                _context.ResourceUnits is null ||
                _context.SetupDefaultUnits is null)
                return StatusCode(500);

            List<SetupDefaultUnit> defaults = await _context.SetupDefaultUnits.Include(i => i.SetupMeasureUnit).OrderBy(o => o.UnitOfMeasure).ThenBy(o => o.SetupMeasureUnit.Name).ToListAsync();

            ResourceRate resourceRate = await _context.ResourceRates.SingleAsync(q => q.Id == id);
            if (resourceRate is null)
                return StatusCode(500);

            List<ResourceUnit> resourceUnits = await _dbset.Where(q => q.ResourceRateId == id).ToListAsync();

            foreach (var dft in defaults.Where(q => q.UnitOfMeasure == resourceRate.UnitOfMeasure))
            {
                if (resourceUnits.Any(q => q.UnitOfMeasure == dft.UnitOfMeasure && q.SetupMeasureUnitId == dft.SetupMeasureUnitId))
                    continue;

                ResourceUnit newUnit = new(dft)
                {
                    ResourceId = resourceRate.ResourceId,
                    ResourceRateId = resourceRate.Id,
                    SetupMeasureUnit = null!
                };
                _context.ResourceUnits.Add(newUnit);
                await _context.SaveChangesAsync();
                resourceUnits.Add(newUnit);
            }

            return Ok(resourceUnits);
        }

        [HttpPost]
        public async Task<IActionResult> PostNew(ResourceUnit model)
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<ResourceUnit>());

            var item = await _dbset.FindAsync(model.Id);
            if (item is not null)
            {
                ModelState.AddModelError(nameof(item.Id), "Item already exists");
                return BadRequest(ModelState);
            }

            item = new(model);
            item.Id = 0;
            item.SetupMeasureUnit = null!;
            await _dbset.AddAsync(item);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(ResourceUnit model)
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<ResourceUnit>());

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
                return StatusCode(500, Array.Empty<ResourceUnit>());

            var item = await _dbset.FindAsync(id);
            if (item is null)
                return NotFound();

            _dbset.Remove(item);
            _context.SaveChanges();
            return Ok();
        }
    }
}