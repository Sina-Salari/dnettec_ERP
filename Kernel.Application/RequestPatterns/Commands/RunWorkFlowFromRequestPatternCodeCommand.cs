using Kernel.ViewModel.RequestPatterns.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Application.RequestPatterns.Commands
{
    public class RunWorkFlowFromRequestPatternCodeCommand 
        : Dnettec.Mediator.IRequest<RunWorkFlowFromRequestPatternCodeCommandResponseViewModel>
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public dynamic JsonBody { get; set; }
    }
}
