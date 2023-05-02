using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Persistence.WorkFlowSteps.Repositories
{
    public interface IWorkFlowStepRepository
        : Dnettec.Persistence.Repositories.IRepository<Domain.Models.WorkFlowStep>
    {
    }
}
