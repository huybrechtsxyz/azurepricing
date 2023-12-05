using AzureApp.Server.Data;
using AzureApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace AzureApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SetupMeasureUnitController : ControllerBase
    {
        private readonly ILogger<SetupMeasureUnitController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly DbSet<SetupMeasureUnit>? _dbset;

        public SetupMeasureUnitController(ILogger<SetupMeasureUnitController> logger, ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            if (_context.SetupMeasureUnits is not null)
                _dbset = _context.SetupMeasureUnits;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<SetupMeasureUnit>());

            var model = await _dbset.OrderBy(o => o.Name).ToListAsync();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<SetupMeasureUnit>());

            var model = await _dbset.FindAsync(id);
            if (model is null)
                return NotFound();

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SetupMeasureUnit model)
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<SetupMeasureUnit>());

            var item = await _dbset.FindAsync(model.Id);
            if (item is not null)
            {
                ModelState.AddModelError(nameof(item.Id), "Item already exists");
                return BadRequest(ModelState);
            }
            
            await _dbset.AddAsync(model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(SetupMeasureUnit model)
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<SetupMeasureUnit>());

            var item = await _dbset.FindAsync(model.Id);
            if (item is null)
            {
                ModelState.AddModelError(nameof(item.Id), "Item does not exist");
                return BadRequest(ModelState);
            }

            item.Name = model.Name;
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<SetupMeasureUnit>());

            var item = await _dbset.FindAsync(id);
            if (item is null)
                return NotFound();

            _dbset.Remove(item);
            _context.SaveChanges();
            return Ok();
        }
    }
}