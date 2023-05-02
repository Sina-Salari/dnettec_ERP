using Microsoft.EntityFrameworkCore;

namespace Kernel.Persistence.ValidationStepTrues.Repositories
{
    public class ValidationStepTruesQueryRepository
        : Dnettec.Persistence.QueryRepositories.QueryRepository<Domain.Models.ValidationStepTrue>, IValidationStepTruesQueryRepository
    {
        public ValidationStepTruesQueryRepository(DbContext databaseContext) : base(databaseContext)
        {
        }
    }
}
