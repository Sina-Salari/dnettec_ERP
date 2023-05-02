using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Persistence.WorkFlowResponses.Repositories
{
    public interface IWorkFlowResponsesRepository
        : Dnettec.Persistence.Repositories.IRepository<Domain.Models.WorkFlowResponse>
    {
    }
}
