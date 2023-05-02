using Microsoft.EntityFrameworkCore;

namespace Kernel.Persistence.ValidationSteps.Repositories
{
    public class ValidationStepsQueryRepository
        : Dnettec.Persistence.QueryRepositories.QueryRepository<Domain.Models.ValidationStep>, IValidationStepsQueryRepository
    {
        public ValidationStepsQueryRepository(DbContext databaseContext) : base(databaseContext)
        {
        }
    }
}
