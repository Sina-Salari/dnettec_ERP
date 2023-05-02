using Dnettec.Persistence.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnettec.Domain
{
    public interface IBaseEntity
    {
        Guid Id { get; }
        RecordStatus Status { get; }
    }
}
