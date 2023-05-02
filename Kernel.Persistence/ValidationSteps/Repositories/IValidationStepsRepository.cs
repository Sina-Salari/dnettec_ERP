namespace Kernel.Persistence.ValidationSteps.Repositories
{
    public interface IValidationStepsRepository
        : Dnettec.Persistence.Repositories.IRepository<Domain.Models.ValidationStep>
    {
        Task<bool> CheckAsync(string query);
    }
}
