using AzureApp.Server.Data;
using AzureApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace AzureApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SetupLocationController : ControllerBase
    {
        private readonly ILogger<SetupLocationController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly DbSet<SetupLocation>? _dbset;

        public SetupLocationController(ILogger<SetupLocationController> logger, ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            if (_context.SetupCurrencies is not null)
                _dbset = _context.SetupLocations;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<SetupLocation>());

            var model = await _dbset.ToListAsync();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<SetupLocation>());

            var model = await _dbset.FindAsync(id);
            if (model is null)
                return NotFound();

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SetupLocation model)
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<SetupLocation>());

            var item = await _dbset.FindAsync(model.Name);
            if (item is not null)
            {
                ModelState.AddModelError(nameof(item.Name), "Item already exists");
                return BadRequest(ModelState);
            }
            
            await _dbset.AddAsync(model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(SetupLocation model)
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<SetupLocation>());

            var item = await _dbset.FindAsync(model.Name);
            if (item is null)
            {
                ModelState.AddModelError(nameof(item.Name), "Item does not exist");
                return BadRequest(ModelState);
            }

            item.ShortName = model.ShortName;
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<SetupLocation>());

            var item = await _dbset.FindAsync(id);
            if (item is null)
                return NotFound();

            _dbset.Remove(item);
            _context.SaveChanges();
            return Ok();
        }
    }
}