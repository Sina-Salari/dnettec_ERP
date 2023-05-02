using Microsoft.EntityFrameworkCore;

namespace Kernel.Persistence.ValidationStepTrues.Repositories
{
    public class ValidationStepTruesRepository
    : Dnettec.Persistence.Repositories.Repository<Domain.Models.ValidationStepTrue>, IValidationStepTruesRepository
    {
        public ValidationStepTruesRepository(DbContext databaseContext) : base(databaseContext)
        {
        }
    }
}
