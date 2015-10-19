using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using LaboratoryApp.Models.Mapping;

namespace LaboratoryApp.Models
{
    public partial class LaboratoryEntities : DbContext
    {
        static LaboratoryEntities()
        {
            Database.SetInitializer<LaboratoryEntities>(new CreateDatabaseIfNotExists<LaboratoryEntities>());
        }

        public LaboratoryEntities()
            : base("name=LaboratoryEntities")
        {
        }

        public DbSet<calibrator> calibrators { get; set; }
        public DbSet<calibrators_model_of_gauges> calibrators_model_of_gauges { get; set; }
        public DbSet<certificate> certificates { get; set; }
        public DbSet<client> clients { get; set; }
        public DbSet<function> functions { get; set; }
        public DbSet<gauge> gauges { get; set; }
        public DbSet<model_of_gauges> model_of_gauges { get; set; }
        public DbSet<office> offices { get; set; }
        public DbSet<type> types { get; set; }
        public DbSet<usage> usages { get; set; }
        public DbSet<calibrators_functions> calibrators_functions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new calibratorMap());
            modelBuilder.Configurations.Add(new calibrators_model_of_gaugesMap());
            modelBuilder.Configurations.Add(new certificateMap());
            modelBuilder.Configurations.Add(new clientMap());
            modelBuilder.Configurations.Add(new functionMap());
            modelBuilder.Configurations.Add(new gaugeMap());
            modelBuilder.Configurations.Add(new model_of_gaugesMap());
            modelBuilder.Configurations.Add(new officeMap());
            modelBuilder.Configurations.Add(new typeMap());
            modelBuilder.Configurations.Add(new usageMap());
            modelBuilder.Configurations.Add(new calibrators_functionsMap());
            modelBuilder.Ignore<ViewModel.MenuItem>();
            modelBuilder.Entity<ViewModel.MenuItem>().Ignore(x=> x.Id);
            modelBuilder.Entity<ViewModel.MenuItem>().Ignore(x => x.IsExpanded);
            modelBuilder.Entity<ViewModel.MenuItem>().Ignore(x => x.IsSelected);
            modelBuilder.Entity<ViewModel.MenuItem>().Ignore(x => x.NameOfItem);
            modelBuilder.Entity<ViewModel.MenuItem>().Ignore(x => x.DisplayImagePath);
        }
    }
}

