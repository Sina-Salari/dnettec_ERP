using Microsoft.EntityFrameworkCore;

namespace Kernel.Persistence.MessageSteps.Repositories
{
    public class MessageStepRespository
        : Dnettec.Persistence.Repositories.Repository<Domain.Models.MessageStep>, IMessageStepRespository
    {
        public MessageStepRespository(DbContext databaseContext) : base(databaseContext)
        {
        }
    }
}
