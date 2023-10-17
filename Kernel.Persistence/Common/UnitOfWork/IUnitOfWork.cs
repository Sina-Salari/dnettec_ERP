namespace Kernel.Persistence.Common.UnitOfWork
{
    public interface IUnitOfWork : Dnettec.Persistence.UnitOfWork.IUnitOfWork
    {
        public Entities.Repositories.IEntityRepository Entities { get; }
        public RequestPatterns.Repositories.IRequestPatternRepository RequestPatterns { get; }
        public WorkFlowSteps.Repositories.IWorkFlowStepRepository WorkFlowSteps { get; }
        public WorkFlowStepMovments.Repositories.IWorkFlowStepMovmentRepository WorkFlowStepMovments { get; }
        public ProcessSteps.Repositories.IProcessStepRepository ProcessSteps { get; }
        public WorkFlowInputs.Repositories.IWorkFlowInputRepository WorkFlowInputs { get; }
        public WorkFlowResponses.Repositories.IWorkFlowResponsesRepository WorkFlowResponses { get; }
        public ValidationSteps.Repositories.IValidationStepsRepository ValidationSteps { get; }
        public ValidationStepTrues.Repositories.IValidationStepTruesRepository ValidationStepTrues { get; }
        public ValidationStepFalses.Repositories.IValidationStepFalsesRepository ValidationStepFalses { get; }
        public MessageSteps.Repositories.IMessageStepRespository MessageSteps { get; }
        public Languages.Repositories.ILanguageRepository Languages { get; }
        public LangMessages.Repositories.ILangMessageRepository LangMessages { get; }
        public Accounts.Repositories.IAccountRepository Accounts { get; }
        public Applications.Repositories.IApplicationRepository Applications { get; }
    }
}
