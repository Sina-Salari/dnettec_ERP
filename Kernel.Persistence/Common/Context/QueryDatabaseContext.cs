using Kernel.Domain.Models;
using Kernel.Persistence.EntityFieldRelations.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Kernel.Persistence.Common.Context
{
    public class QueryDatabaseContext : DbContext
    {
        public QueryDatabaseContext(DbContextOptions<QueryDatabaseContext> options) : base(options: options)
        {
            // TODO
            Database.EnsureCreated();
        }

        // **********
        public DbSet<Entity> Entities { get; set; }
        public DbSet<EntityField> EntityFields { get; set; }
        public DbSet<EntityFieldRelation> EntityFieldRelations { get; set; }
        public DbSet<LangMessage> LangMessages { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<RequestPattern> RequestPatterns { get; set; }
        public DbSet<WorkFlow> WorkFlows { get; set; }
        public DbSet<WorkFlowStep> WorkFlowSteps { get; set; }
        public DbSet<WorkFlowStepMovment> WorkFlowStepMovments { get; set; }
        public DbSet<ProcessStep> ProcessSteps { get; set; }
        // **********

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EntityFieldRelationConfigurations());
            base.OnModelCreating(modelBuilder);
        }
    }
}
