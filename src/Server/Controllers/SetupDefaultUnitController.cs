﻿using AzureApp.Server.Data;
using AzureApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace AzureApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SetupDefaultUnitController : ControllerBase
    {
        private readonly ILogger<SetupDefaultUnitController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly DbSet<SetupDefaultUnit>? _dbset;

        public SetupDefaultUnitController(ILogger<SetupDefaultUnitController> logger, ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            if (_context.SetupDefaultUnits is not null)
                _dbset = _context.SetupDefaultUnits;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<SetupDefaultUnit>());

            var model = await _dbset
                .Include(i => i.SetupMeasureUnit)
                .OrderBy(o => o.AzureMeasure)
                .ThenBy(o => o.SetupMeasureUnit.Name)
                .ToListAsync();
            return Ok(model);
        }

        [HttpGet("units")]
        public async Task<IActionResult> GetUnits()
        {
            if (_context.SetupMeasureUnits is null)
                return StatusCode(500, Array.Empty<SetupDefaultUnit>());

            var model = await _context.SetupMeasureUnits.OrderBy(o => o.Name).ToListAsync();
            model.Insert(0, new SetupMeasureUnit()
            {
                Id = 0,
                Name = string.Empty
            });
            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<SetupDefaultUnit>());

            var model = await _dbset.FindAsync(id);
            if (model is null)
                return NotFound();

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SetupDefaultUnit model)
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<SetupDefaultUnit>());

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
        public async Task<IActionResult> Put(SetupDefaultUnit model)
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<SetupDefaultUnit>());

            var item = await _dbset.FindAsync(model.Id);
            if (item is null)
            {
                ModelState.AddModelError(nameof(item.Id), "Item does not exist");
                return BadRequest(ModelState);
            }

            item.AzureMeasure = model.AzureMeasure;
            item.SetupMeasureUnitId = model.SetupMeasureUnitId;
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_dbset is null)
                return StatusCode(500, Array.Empty<SetupDefaultUnit>());

            var item = await _dbset.FindAsync(id);
            if (item is null)
                return NotFound();

            _dbset.Remove(item);
            _context.SaveChanges();
            return Ok();
        }
    }
}