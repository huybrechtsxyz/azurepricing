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
    public class ProjectDesignController : ControllerBase
    {
        private readonly ILogger<ProjectDesignController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        private readonly DbSet<ProjectDesign>? _dbset;

        public ProjectDesignController(
            ILogger<ProjectDesignController> logger, 
            IConfiguration configuration,
            ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            if (_context.ProjectDesigns is not null)
                _dbset = _context.ProjectDesigns;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet("all/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (_dbset is null)
                return StatusCode(500);

            var model = await _dbset
                .Where(q => q.ProjectId == id)
                .OrderBy(o => o.Name)
                .ToListAsync();
            return Ok(model);
        }

        [HttpGet("item/{id}")]
        public async Task<IActionResult> GetChild(int id)
        {
            if (_dbset is null)
                return StatusCode(500);

            var model = await _dbset.FirstAsync(q => q.Id == id);
            if (model is null)
                return NotFound();

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProjectDesign model)
        {
            if (_dbset is null)
                return StatusCode(500);

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
        public async Task<IActionResult> Put(ProjectDesign model)
        {
            if (_dbset is null)
                return StatusCode(500);

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
                return StatusCode(500);

            var item = await _dbset.FindAsync(id);
            if (item is null)
                return NotFound();

            _dbset.Remove(item);
            _context.SaveChanges();
            return Ok();
        }
    }
}