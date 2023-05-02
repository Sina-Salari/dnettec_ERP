using Microsoft.EntityFrameworkCore;

namespace Kernel.Persistence.ValidationStepFalses.Repositories
{
    public class ValidationStepFalsesRepository
        : Dnettec.Persistence.Repositories.Repository<Domain.Models.ValidationStepFalse>, IValidationStepFalsesRepository
    {
        public ValidationStepFalsesRepository(DbContext databaseContext) : base(databaseContext)
        {
        }
    }
}
