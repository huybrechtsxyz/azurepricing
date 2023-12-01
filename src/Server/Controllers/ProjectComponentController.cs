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
    public class ProjectComponentController : ControllerBase
    {
        private readonly ILogger<ProjectComponentController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        private readonly DbSet<ProjectComponent>? _dbset;

        public ProjectComponentController(
            ILogger<ProjectComponentController> logger, 
            IConfiguration configuration,
            ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            if (_context.ProjectComponents is not null)
                _dbset = _context.ProjectComponents;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet("all/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (_dbset is null)
                return StatusCode(500);

            var model = await _dbset.Include(i => i.Resource).Where(q => q.ProjectDesignId == id).OrderBy(o => o.Name).ToListAsync();
            return Ok(model);
        }

        [HttpGet("item/{id}")]
        public async Task<IActionResult> GetChild(int id)
        {
            if (_dbset is null)
                return StatusCode(500);

            var model = await _dbset
                .Include(i => i.Resource)
                .FirstAsync(q => q.Id == id);
            if (model is null)
                return NotFound();

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProjectComponent model)
        {
            if (_dbset is null)
                return StatusCode(500);

            var item = await _dbset.FindAsync(model.Id);
            if (item is not null)
            {
                ModelState.AddModelError(nameof(item.Id), "Item already exists");
                return BadRequest(ModelState);
            }

            var resource = await _context.Resources!.SingleAsync(q => q.Id == model.ResourceId);
            item = new ProjectComponent(model);
            item.Resource = resource;
            item.ResourceId = resource.Id;
            await _dbset.AddAsync(item);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProjectComponent model)
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