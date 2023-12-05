using AzureApp.Server.Data;
using AzureApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace AzureApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectEstimateController : ControllerBase
    {
        private readonly ILogger<ProjectEstimateController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        private readonly DbSet<ProjectEstimate>? _dbset;

        public ProjectEstimateController(
            ILogger<ProjectEstimateController> logger, 
            IConfiguration configuration,
            ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            if (_context.ProjectEstimates is not null)
                _dbset = _context.ProjectEstimates;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet("all/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            if (_dbset is null)
                return StatusCode(500);

            var model = await _dbset
                .Where(q => q.ProjectSimulationId == id).ToListAsync();

            return Ok(model);
        }

        [HttpDelete("all/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_dbset is null)
                return StatusCode(500);

            var items = await _dbset.Where(q => q.ProjectSimulationId == id).ToListAsync();
            if (items is null)
                return NotFound();

            _dbset.RemoveRange(items);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("export/{id}")]
        public async Task<IActionResult> GetExport(int id)
        {
            if (_dbset is null)
                return StatusCode(500);

            var model = await _dbset
                .Where(q => q.ProjectSimulationId == id).ToListAsync();

            ClosedXML.Excel.XLWorkbook xlBook = new();
            xlBook.Properties.Author = "Vincent Huybrechts";
            xlBook.Properties.Title = "Azure Pricing - Estimates";
            xlBook.Properties.Subject = "Azure Pricing for Selected Components";
            xlBook.Properties.Category = "Azure;Pricing";
            xlBook.Properties.Comments = "Azure pricing";
            xlBook.Properties.Company = "OMP";
            xlBook.Properties.Manager = "Dirk De Bast";

            var wsData = xlBook.AddWorksheet("data");

            int idex = 1;
            wsData.Cell(idex, 01).Value = "Project";
            wsData.Cell(idex, 02).Value = "Design";
            wsData.Cell(idex, 03).Value = "Component";
            wsData.Cell(idex, 04).Value = "Scenario";
            wsData.Cell(idex, 05).Value = "Quantity";
            wsData.Cell(idex, 06).Value = "Price";
            wsData.Cell(idex, 07).Value = "Cost";
            wsData.Cell(idex, 08).Value = "Owned";
            wsData.Cell(idex, 09).Value = "OwnCost";
            wsData.Cell(idex, 10).Value = "Subscription";
            wsData.Cell(idex, 11).Value = "ResourceGroup";
            wsData.Cell(idex, 12).Value = "Location";
            wsData.Cell(idex, 13).Value = "Service";
            wsData.Cell(idex, 14).Value = "Resource";
            wsData.Cell(idex, 15).Value = "Product";
            wsData.Cell(idex, 16).Value = "ProductSku";
            wsData.Cell(idex, 17).Value = "Size";
            wsData.Cell(idex, 18).Value = "MiminumUnits";
            wsData.Cell(idex, 19).Value = "UnitOfMeasure";
            wsData.Cell(idex, 20).Value = "ComponentOwner";
            wsData.Cell(idex, 21).Value = "Rate";
            wsData.Cell(idex, 22).Value = "MeterName";
            wsData.Cell(idex, 23).Value = "RateType";

            if (model is not null && model.Count > 0)
            {
                foreach (var item in model)
                {
                    ++idex;
                    wsData.Cell(idex, 01).Value = item.ProjectName;
                    wsData.Cell(idex, 02).Value = item.ProjectDesignName;
                    wsData.Cell(idex, 03).Value = item.ProjectComponentName;
                    wsData.Cell(idex, 04).Value = item.ProjectScenarioName;
                    wsData.Cell(idex, 05).Value = item.Quantity;
                    wsData.Cell(idex, 06).Value = item.RetailPrice;
                    wsData.Cell(idex, 07).Value = item.Cost;
                    wsData.Cell(idex, 08).Value = item.Owned;
                    wsData.Cell(idex, 09).Value = item.OwnCost;
                    wsData.Cell(idex, 10).Value = item.Subscription;
                    wsData.Cell(idex, 11).Value = item.ResourceGroup;
                    wsData.Cell(idex, 12).Value = item.Location;
                    wsData.Cell(idex, 13).Value = item.Service;
                    wsData.Cell(idex, 14).Value = item.ResourceName;
                    wsData.Cell(idex, 15).Value = item.Product;
                    wsData.Cell(idex, 16).Value = item.ProductSku;
                    wsData.Cell(idex, 17).Value = item.Size;
                    wsData.Cell(idex, 18).Value = item.MiminumUnits;
                    wsData.Cell(idex, 19).Value = item.UnitOfMeasure;
                    wsData.Cell(idex, 20).Value = item.ComponentOwner;
                    wsData.Cell(idex, 21).Value = item.ResourceRateName;
                    wsData.Cell(idex, 22).Value = item.MeterName;
                    wsData.Cell(idex, 23).Value = item.RateType;
                    
                }
            }

            var wsPivot = xlBook.AddWorksheet("pivot");

            var pivottable = wsPivot.PivotTables.Add("PivotEstimates", wsPivot.Cell(2, 2), wsData.Range(1, 1, idex, 23));
            pivottable.ColumnLabels.Add("Scenario");
            pivottable.RowLabels.Add("Component");
            pivottable.Values.Add("Cost");

            //would be short version but would include id fields of object
            //var wsList = xlBook.AddWorksheet("list");
            //var table = wsList.Cell(1, 1).InsertTable(model, "MODEL", true);
            //var pivottable = wsPivot.PivotTables.Add("PivotEstimates", wsPivot.Cell(2, 2), table.AsRange());

            System.IO.MemoryStream stream = new();
            xlBook.SaveAs(stream);
            stream.Position = 0;
            return new FileStreamResult(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [HttpGet("calculate/{id}")]
        public async Task<IActionResult> GetCosts(int id)
        {
            if (_dbset is null ||
                _context.Projects is null ||
                _context.ProjectSimulations is null ||
                _context.ProjectDesigns is null ||
                _context.Resources is null)
                return StatusCode(500);

            var simulation = await _context.ProjectSimulations.Include(i => i.Estimates).SingleAsync(q => q.Id == id);
            if (simulation.Estimates is not null)
                _dbset.RemoveRange(simulation.Estimates);
            simulation.Estimates ??= new List<ProjectEstimate>();

            var design = await _context.ProjectDesigns!
                .Include(i => i.ProjectComponents!)
                .ThenInclude(i => i.ProjectMeasures!)
                .ThenInclude(i => i.SetupMeasureUnit)
                .SingleAsync(q => q.Id == simulation.ProjectDesignId);

            if (design is null || design.ProjectComponents is null)
                return Ok();

            var project = await _context.Projects
                .Include(i => i.ProjectScenarios)
                .Where(q => q.Id == design.ProjectId).SingleAsync();

            if (project.ProjectScenarios is null || !project.ProjectScenarios.Any())
                return Ok();

            simulation.CreatedOn = DateTime.Today;
            simulation.CurrencyCode = project.CurrencyCode;
            simulation.Environment = design.Environment;
            simulation.Location = (design.ProjectComponents.FirstOrDefault(q => q.Location != String.Empty) ?? new ProjectComponent()).Location;
            _context.Entry(simulation).State = EntityState.Modified;

            Jace.CalculationEngine calculationEngine = new();
            calculationEngine.AddFunction("roundup", ( (Func<double, double>)( (a) => (double)decimal.Ceiling((decimal)a) ) ) );
            calculationEngine.AddFunction("rounddown", ((Func<double, double>)((a) => (double)decimal.Floor((decimal)a))));

            foreach (var scenario in project.ProjectScenarios)
            {
                foreach (var component in design.ProjectComponents)
                {
                    if (!string.IsNullOrEmpty(simulation.Proposal))
                        if (simulation.Proposal != component.Proposal)
                            continue;

                    Dictionary<string, double> variables = scenario.GetAsVariables();

                    if (component.ProjectMeasures is not null)
                    {
                        foreach (var measure in component.ProjectMeasures.OrderBy(o => o.Variable).ThenBy(o => o.SetupMeasureUnit.Name))
                        {
                            if (string.IsNullOrEmpty(measure.Variable))
                                measure.Variable = measure.SetupMeasureUnit.Name;
                            measure.CalcQuantity = calculationEngine.Calculate((measure.Expression??string.Empty).ToLower(), variables);
                            if (!variables.ContainsKey(measure.Variable.ToLower()))
                                variables.Add(measure.Variable.ToLower(), measure.CalcQuantity);
                        }
                    }

                    var resource = await _context.Resources
                        .Include(i => i.ResourceRates!)
                        .ThenInclude(i => i.ResourceUnits!)
                        .ThenInclude(i => i.SetupMeasureUnit)
                        .Where(q => q.Id == component.ResourceId)
                        .SingleAsync();
                    if (resource is null || resource.ResourceRates is null)
                        break;

                    for(int idex = 0; idex < resource.ResourceRates.Count; ++idex)
                    {
                        ResourceRate rate = resource.ResourceRates.ElementAt(idex);
                        if (rate.Location != component.Location || rate.CurrencyCode != project.CurrencyCode)
                            continue;

                        ResourceRate? peek = null;
                        if (idex + 1 < resource.ResourceRates.Count)
                            peek = resource.ResourceRates.ElementAt(idex + 1);

                        ProjectEstimate estimate = new ProjectEstimate(simulation);
                        estimate.SetProjectFields(project);
                        estimate.SetProjectScenarioFields(scenario);
                        estimate.SetProjectDesignFields(design);
                        estimate.SetProjectComponentFields(component);
                        estimate.SetResourceFields(resource);
                        estimate.SetResourceRateFields(rate);
                        estimate.Quantity = 1;

                        if (rate.ResourceUnits is not null) { 
                            foreach(var unit in rate.ResourceUnits)
                            {
                                if (unit.UnitFactor != 0)
                                    estimate.Quantity *= unit.UnitFactor;

                                var applied = component.ProjectMeasures!.Where(q => q.SetupMeasureUnitId == unit.SetupMeasureUnitId).ToList();
                                if (applied is not null && applied.Count > 0)
                                {
                                    foreach(var measureunit in applied)
                                    {
                                        estimate.Quantity *= (decimal)measureunit.CalcQuantity;
                                    }
                                }
                                else
                                    estimate.Quantity *= unit.DefaultValue;
                            }
                        }

                        if (rate.MiminumUnits > 0)
                            estimate.Quantity -= rate.MiminumUnits;

                        if (estimate.Quantity < 0)
                            estimate.Quantity = 0;

                        if (peek is not null)
                            if (peek.MiminumUnits != 0 && estimate.Quantity > peek.MiminumUnits)
                                estimate.Quantity = peek.MiminumUnits;

                        estimate.CalculateCost();
                        _dbset.Add(estimate);
                    }
                }
            }

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}