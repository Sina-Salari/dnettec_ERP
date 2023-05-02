using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.ViewModel.Common
{
    public class WorkFlowDataSource
    {
        public string Key { get; set; }
        public object Value { get; set; }
        public JTokenType Type { get; set; }
    }
}
