using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Persistence.MessageSteps.Repositories
{
    public interface IMessageStepRespository
        : Dnettec.Persistence.Repositories.IRepository<Domain.Models.MessageStep>
    {

    }
}
