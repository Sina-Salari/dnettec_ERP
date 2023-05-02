using FluentValidation;

namespace Kernel.Application.RequestPatterns.Commands
{
    public class RunWorkFlowFromRequestPatternCodeCommandValidation
        : AbstractValidator<RunWorkFlowFromRequestPatternCodeCommand>
    {
        public RunWorkFlowFromRequestPatternCodeCommandValidation() : base()
        {

        }
    }
}
