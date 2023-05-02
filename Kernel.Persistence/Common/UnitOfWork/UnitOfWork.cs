using Kernel.Persistence.Common.Context;
using Microsoft.Data.SqlClient;

namespace Kernel.Persistence.Common.UnitOfWork
{
    public class UnitOfWork :
        Dnettec.Persistence.UnitOfWork.UnitOfWork<DatabaseContext>, IUnitOfWork
    {
        protected SqlConnection DapperContext { get; }
        public UnitOfWork
            (Dnettec.Persistence.Common.Options options) : base(options: options)
        {
            DapperContext = new SqlConnection(Options.ConnectionString);
        }

        // **************************************************
        private Entities.Repositories.IEntityRepository _entities;

        public Entities.Repositories.IEntityRepository Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities =
                        new Entities.Repositories.EntityRepository(DatabaseContext,DapperContext);
                }

                return _entities;
            }
        }
        // **************************************************

        // **************************************************
        private RequestPatterns.Repositories.IRequestPatternRepository _requestPatterns;

        public RequestPatterns.Repositories.IRequestPatternRepository RequestPatterns
        {
            get
            {
                if (_requestPatterns == null)
                {
                    _requestPatterns =
                        new RequestPatterns.Repositories.RequestPatternRepository(DatabaseContext);
                }

                return _requestPatterns;
            }
        }
        // **************************************************

        // **************************************************
        private WorkFlowSteps.Repositories.IWorkFlowStepRepository _workFlowSteps;

        public WorkFlowSteps.Repositories.IWorkFlowStepRepository WorkFlowSteps
        {
            get
            {
                if (_workFlowSteps == null)
                {
                    _workFlowSteps =
                        new WorkFlowSteps.Repositories.WorkFlowStepRepository(DatabaseContext);
                }

                return _workFlowSteps;
            }
        }
        // **************************************************

        // **************************************************
        private WorkFlowStepMovments.Repositories.IWorkFlowStepMovmentRepository _workFlowStepMovments;

        public WorkFlowStepMovments.Repositories.IWorkFlowStepMovmentRepository WorkFlowStepMovments
        {
            get
            {
                if (_workFlowStepMovments == null)
                {
                    _workFlowStepMovments =
                        new WorkFlowStepMovments.Repositories.WorkFlowStepMovmentRepository(DatabaseContext);
                }

                return _workFlowStepMovments;
            }
        }
        // **************************************************

        // **************************************************
        private ProcessSteps.Repositories.IProcessStepRepository _processSteps;

        public ProcessSteps.Repositories.IProcessStepRepository ProcessSteps
        {
            get
            {
                if (_processSteps == null)
                {
                    _processSteps =
                        new ProcessSteps.Repositories.ProcessStepRepository(DatabaseContext,DapperContext);
                }

                return _processSteps;
            }
        }
        // **************************************************   

        // **************************************************
        private WorkFlowInputs.Repositories.IWorkFlowInputRepository _workFlowInputs;

        public WorkFlowInputs.Repositories.IWorkFlowInputRepository WorkFlowInputs
        {
            get
            {
                if (_workFlowInputs == null)
                {
                    _workFlowInputs =
                        new WorkFlowInputs.Repositories.WorkFlowInputRepository(DatabaseContext);
                }

                return _workFlowInputs;
            }
        }
        // ************************************************** 
        
        // **************************************************
        private WorkFlowResponses.Repositories.IWorkFlowResponsesRepository _workFlowResponses;

        public WorkFlowResponses.Repositories.IWorkFlowResponsesRepository WorkFlowResponses
        {
            get
            {
                if (_workFlowResponses == null)
                {
                    _workFlowResponses =
                        new WorkFlowResponses.Repositories.WorkFlowResponsesRepository(DatabaseContext);
                }

                return _workFlowResponses;
            }
        }
        // **************************************************

        // **************************************************
        private ValidationSteps.Repositories.IValidationStepsRepository _validationSteps;

        public ValidationSteps.Repositories.IValidationStepsRepository ValidationSteps
        {
            get
            {
                if (_validationSteps == null)
                {
                    _validationSteps =
                        new ValidationSteps.Repositories.ValidationStepsRepository(DatabaseContext,DapperContext);
                }

                return _validationSteps;
            }
        }
        // **************************************************

        // **************************************************
        private ValidationStepTrues.Repositories.IValidationStepTruesRepository _validationStepTrues;

        public ValidationStepTrues.Repositories.IValidationStepTruesRepository ValidationStepTrues
        {
            get
            {
                if (_validationStepTrues == null)
                {
                    _validationStepTrues =
                        new ValidationStepTrues.Repositories.ValidationStepTruesRepository(DatabaseContext);
                }

                return _validationStepTrues;
            }
        }
        // **************************************************

        // **************************************************
        private ValidationStepFalses.Repositories.IValidationStepFalsesRepository _validationStepFalses;

        public ValidationStepFalses.Repositories.IValidationStepFalsesRepository ValidationStepFalses
        {
            get
            {
                if (_validationStepTrues == null)
                {
                    _validationStepFalses =
                        new ValidationStepFalses.Repositories.ValidationStepFalsesRepository(DatabaseContext);
                }

                return _validationStepFalses;
            }
        }
        // **************************************************

        // **************************************************
        private MessageSteps.Repositories.IMessageStepRespository _messageSteps;

        public MessageSteps.Repositories.IMessageStepRespository MessageSteps
        {
            get
            {
                if (_messageSteps == null)
                {
                    _messageSteps =
                        new MessageSteps.Repositories.MessageStepRespository(DatabaseContext);
                }

                return _messageSteps;
            }
        }
        // **************************************************    
        
        // **************************************************
        private Languages.Repositories.ILanguageRepository _languages;

        public Languages.Repositories.ILanguageRepository Languages
        {
            get
            {
                if (_languages == null)
                {
                    _languages =
                        new Languages.Repositories.LanguageRepository(DatabaseContext);
                }

                return _languages;
            }
        }
        // ************************************************** 

        // **************************************************
        private LangMessages.Repositories.ILangMessageRepository _langMessages;

        public LangMessages.Repositories.ILangMessageRepository LangMessages
        {
            get
            {
                if (_langMessages == null)
                {
                    _langMessages =
                        new LangMessages.Repositories.LangMessageRepository(DatabaseContext,DapperContext);
                }

                return _langMessages;
            }
        }
        // **************************************************
    }
}
