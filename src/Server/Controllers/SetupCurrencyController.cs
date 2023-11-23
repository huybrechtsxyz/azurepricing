using AzureApp.Server.Data;
using AzureApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzureApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SetupCurrencyController : ControllerBase
    {
        private readonly ILogger<SetupCurrencyController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly DbSet<SetupCurrency>? _dbset;

        public SetupCurrencyController(ILogger<SetupCurrencyController> logger, ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            if (_context.SetupCurrencies is not null)
                _dbset = _context.SetupCurrencies;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<SetupCurrency>());

            var model = await _dbset.ToListAsync();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<SetupCurrency>());

            var model = await _dbset.FindAsync(id);
            if (model is null)
                return NotFound();

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SetupCurrency model)
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<SetupCurrency>());

            var item = await _dbset.FindAsync(model.Code);
            if (item is not null)
            {
                ModelState.AddModelError(nameof(item.Code), "Item already exists");
                return ValidationProblem();
            }

            await _dbset.AddAsync(model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(SetupCurrency model)
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<SetupCurrency>());

            var item = await _dbset.FindAsync(model.Code);
            if (item is null)
            {
                ModelState.AddModelError(nameof(item.Code), "Item does not exist");
                return ValidationProblem();
            }

            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<SetupCurrency>());

            var item = await _dbset.FindAsync(id);
            if (item is null)
                return NotFound();

            _dbset.Remove(item);
            _context.SaveChanges();
            return Ok();
        }
    }
}