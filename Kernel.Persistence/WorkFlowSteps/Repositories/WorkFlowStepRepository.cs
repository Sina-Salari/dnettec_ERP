using Kernel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Kernel.Persistence.WorkFlowSteps.Repositories
{
    public class WorkFlowStepRepository
        : Dnettec.Persistence.Repositories.Repository<Domain.Models.WorkFlowStep>, IWorkFlowStepRepository
    {
        public WorkFlowStepRepository(DbContext databaseContext) : base(databaseContext)
        {

        }
    }
}
