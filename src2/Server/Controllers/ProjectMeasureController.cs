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
    public class ProjectMeasureController : ControllerBase
    {
        private readonly ILogger<ProjectMeasureController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        private readonly DbSet<ProjectMeasure>? _dbset;

        public ProjectMeasureController(
            ILogger<ProjectMeasureController> logger, 
            IConfiguration configuration,
            ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            if (_context.ProjectMeasures is not null)
                _dbset = _context.ProjectMeasures;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet("all/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (_dbset is null)
                return StatusCode(500);

            var model = await _dbset
                .Include(i => i.SetupMeasureUnit)
                .Where(q => q.ProjectComponentId == id)
                .OrderBy(o => o.Variable)
                .ThenBy(o => o.SetupMeasureUnit.Name)
                .ToListAsync();
            return Ok(model);
        }

        [HttpGet("item/{id}")]
        public async Task<IActionResult> GetChild(int id)
        {
            if (_dbset is null)
                return StatusCode(500);

            var model = await _dbset
                .Include(i => i.SetupMeasureUnit)
                .FirstAsync(q => q.Id == id);
            if (model is null)
                return NotFound();

            return Ok(model);
        }

        [HttpGet("create/{id}")]
        public async Task<IActionResult> CreateDefaults(int id)
        {
            if (_dbset is null ||
                _context.SetupDefaultUnits is null ||
                _context.ProjectComponents is null ||
                _context.Resources is null ||
                _context.ResourceUnits is null)
                return StatusCode(500);

            var projectComponent = await _context.ProjectComponents
                .Include(i => i.ProjectMeasures)
                .SingleAsync(q => q.Id == id);

            Resource resource = await _context.Resources
                .Include(i => i.ResourceRates!)
                .ThenInclude(i => i.ResourceUnits!)
                .ThenInclude(i => i.SetupMeasureUnit)
                .Where(q => q.Id == projectComponent.ResourceId)
                .FirstAsync();

            List<SetupDefaultUnit> defaults = await _context.SetupDefaultUnits
                .Include(i => i.SetupMeasureUnit)
                .OrderBy(o => o.UnitOfMeasure)
                .ThenBy(o => o.SetupMeasureUnit.Name)
                .ToListAsync();

            if (resource.ResourceRates is null)
                return Ok(new List<ProjectMeasure>());

            projectComponent.ProjectMeasures ??= new List<ProjectMeasure>();

            foreach (var resourceRate in resource.ResourceRates)
            {
                if (resourceRate.ResourceUnits is null)
                    continue;

                foreach (var resourceUnit in resourceRate.ResourceUnits)
                {
                    if (projectComponent.ProjectMeasures.Any(q => q.SetupMeasureUnitId == resourceUnit.SetupMeasureUnitId))
                        continue;

                    ProjectMeasure projectMeasure = new(projectComponent)
                    {
                        SetupMeasureUnitId = resourceUnit.SetupMeasureUnitId,
                        SetupMeasureUnit = resourceUnit.SetupMeasureUnit,
                        Variable = resourceUnit.SetupMeasureUnit.Name,
                        Expression = resourceUnit.DefaultValue.ToString(),
                        Description = resourceUnit.Description,
                        Remark = ""
                    };

                    _dbset.Add(projectMeasure);
                    projectComponent.ProjectMeasures.Add(projectMeasure);
                }
            }
            await _context.SaveChangesAsync();
            return Ok(projectComponent.ProjectMeasures.OrderBy(o => o.SetupMeasureUnit.Name));
        }

        [HttpPost]
        public async Task<IActionResult> PostNew(ProjectMeasure model)
        {
            if (_dbset is null)
                return StatusCode(500);

            var item = await _dbset.FindAsync(model.Id);
            if (item is not null)
            {
                ModelState.AddModelError(nameof(item.Id), "Item already exists");
                return BadRequest(ModelState);
            }

            var setupMeasureUnit = await _context.SetupMeasureUnits!.SingleAsync(q => q.Id == model.SetupMeasureUnitId);
            item = new ProjectMeasure(model);
            item.SetupMeasureUnit = setupMeasureUnit;
            item.SetupMeasureUnitId = setupMeasureUnit.Id;
            if (string.IsNullOrEmpty(item.Variable))
                item.Variable = item.SetupMeasureUnit.Name;
            await _dbset.AddAsync(item);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProjectMeasure model)
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