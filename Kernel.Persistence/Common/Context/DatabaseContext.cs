using Kernel.Domain.Models;
using Kernel.Persistence.ComponetChildren.Configurations;
using Kernel.Persistence.EntityFieldRelations.Configurations;
using Kernel.Persistence.Pages.Configurations;
using Kernel.Persistence.WorkFlowStepMovments.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Kernel.Persistence.Common.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext
            (DbContextOptions<DatabaseContext> options) : base(options: options)
        {
            Database.EnsureCreated();
        }

        // **********
        public DbSet<Entity> Entities { get; set; }
        public DbSet<EntityField> EntityFields { get; set; }
        public DbSet<EntityFieldValidation> EntityFieldValidations { get; set; }
        public DbSet<EntityFieldRelation> EntityFieldRelations { get; set; }

        public DbSet<Language> Languages { get; set; }
        public DbSet<LangMessage> LangMessages { get; set; }
        public DbSet<Message> Messages { get; set; }

        public DbSet<Page> Pages { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<PageComponent> PageComponents { get; set; }
        public DbSet<ComponetChild> ComponetChildren { get; set; }
        public DbSet<ComponentItem> ComponentItems { get; set; }
        public DbSet<ComponentItemOption> ComponentItemOptions { get; set; }

        public DbSet<RequestPattern> RequestPatterns { get; set; }
        public DbSet<ProcessStep> ProcessSteps { get; set; }
        public DbSet<WorkFlow> WorkFlows { get; set; }
        public DbSet<WorkFlowInput> WorkFlowInputs { get; set; }
        public DbSet<WorkFlowResponse> WorkFlowResponses { get; set; }
        public DbSet<WorkFlowStep> WorkFlowSteps { get; set; }
        public DbSet<WorkFlowStepMovment> WorkFlowStepMovments { get; set; }
        public DbSet<MessageStep> MessageSteps { get; set; }

        public DbSet<ValidationStep> ValidationSteps { get; set; }
        public DbSet<ValidationStepTrue> ValidationStepTrues { get; set; }
        public DbSet<ValidationStepFalse> ValidationStepFalses { get; set; }

        // **********

        protected override void OnModelCreating
            (ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EntityFieldRelationConfigurations());
            modelBuilder.ApplyConfiguration(new WorkFlowStepMovmentConfigurations());
            modelBuilder.ApplyConfiguration(new ComponetChildConfigurations());
            modelBuilder.ApplyConfiguration(new PageConfigurations());
            base.OnModelCreating(modelBuilder);
        }
    }
}
