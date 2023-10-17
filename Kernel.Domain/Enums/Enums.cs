using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Domain.Enums
{
    public class Enums
    {
        public enum FieldType
        {
            Int = 1,
            String = 2,
            DateTime = 3,
            Boolean = 4,
            Guid = 5,
            FK = 6,
            Enum = 7,
        }

        public enum ProcessType
        {
            Query = 1,
            QueryCommand = 2,
            ExecuteCommand = 3,
            ExecuteProvider = 4,
            QueryCommandTop1 = 5,
        }

        public enum WorkFlowStepType
        {
            Process = 1,
            Validation = 2,
            Method = 3,
            WorkFlow = 4,
            ErrorMessage = 5,
            SuccessMessage = 6,
        }

        public enum ComponentItemType
        {
            Btn = 1,
            Input = 2,
            SelectList = 3,
            List = 4,
            Checkbox = 5,
            Chart = 6,
            Calendar = 7,
            Map = 8
        }

        public enum ComponentDirectionType
        {
            Horizontal = 1,
            Vertical = 2,
        }

        public enum PageEventType
        {
            CallApi = 1,
            ClearForm = 2,
            Onload = 3,
            RedirectPage = 3,
            Link = 4
        }
    }
}
