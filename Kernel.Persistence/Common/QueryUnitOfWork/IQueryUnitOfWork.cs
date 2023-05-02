namespace Kernel.Persistence.Common.QueryUnitOfWork
{
    public interface IQueryUnitOfWork : Dnettec.Persistence.QueryUnitOfWork.IQueryUnitOfWork
    {
        public Entities.Repositories.IEntityQueryRepository Entities { get; }
        public RequestPatterns.Repositories.IRequestPatternQueryRepository RequestPatterns { get; }
        public WorkFlowSteps.Repositories.IWorkFlowStepQueryRepository WorkFlowSteps { get; }
        public WorkFlowStepMovments.Repositories.IWorkFlowStepMovmentQueryRepository WorkFlowStepMovments { get; }
        public ProcessSteps.Repositories.IProcessStepQueryRepository ProcessSteps { get; }
    }
}
