using Microsoft.EntityFrameworkCore;

namespace Kernel.Persistence.ValidationStepFalses.Repositories
{
    public class ValidationStepFalsesQueryRepository
    : Dnettec.Persistence.QueryRepositories.QueryRepository<Domain.Models.ValidationStepFalse>, IValidationStepFalsesQueryRepository
    {
        public ValidationStepFalsesQueryRepository(DbContext databaseContext) : base(databaseContext)
        {
        }
    }
}
