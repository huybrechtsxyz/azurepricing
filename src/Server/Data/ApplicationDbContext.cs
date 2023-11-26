using AzureApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace AzureApp.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
             : base(options)
        //IOptions<OperationalStoreOptions> operationalStoreOptions)
        {
        }

        public DbSet<Project>? Projects { get; set; }

        public DbSet<ProjectScenario>? ProjectScenarios { get; set; }

        public DbSet<ProjectDesign>? ProjectDesigns { get; set; }

        public DbSet<ProjectComponent>? ProjectComponents { get; set; }

        public DbSet<ProjectMeasure>? ProjectMeasures { get; set; }

        public DbSet<ProjectSimulation>? ProjectSimulations { get; set; }

        public DbSet<ProjectEstimate>? ProjectEstimates { get; set; }

        public DbSet<Resource>? Resources { get; set; }

        public DbSet<ResourceRate>? ResourceRates { get; set; }

        public DbSet<ResourceUnit>? ResourceUnits { get; set; }

        public DbSet<SearchRate>? SearchRates { get; set; }

        public DbSet<SetupCurrency>? SetupCurrencies { get; set; }

        public DbSet<SetupDefaultUnit>? SetupDefaultUnits { get; set; }

        public DbSet<SetupLocation>? SetupLocations { get; set; }

        public DbSet<SetupMeasureUnit>? SetupMeasureUnits { get; set; }

        public DbSet<SetupService>? SetupServices { get; set; }
    }
}