using Kernel.ViewModel.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.ViewModel.RequestPatterns.ViewModels
{
    public class RunWorkFlowFromRequestPatternCodeCommandResponseViewModel
    {
        public Guid WorkFlowId { get; set; }
        public List<WorkFlowDataSource> DataSource { get; set; }
    }
}
