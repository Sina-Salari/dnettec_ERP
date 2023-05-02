using Microsoft.EntityFrameworkCore;

namespace Kernel.Persistence.MessageSteps.Repositories
{
    public class MessageStepQueryRespository
        : Dnettec.Persistence.QueryRepositories.QueryRepository<Domain.Models.MessageStep>, IMessageStepQueryRespository
    {
        public MessageStepQueryRespository(DbContext databaseContext) : base(databaseContext)
        {
        }
    }
}
