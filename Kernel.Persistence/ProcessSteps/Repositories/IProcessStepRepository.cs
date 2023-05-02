using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Persistence.ProcessSteps.Repositories
{
    public interface IProcessStepRepository
        : Dnettec.Persistence.Repositories.IRepository<Domain.Models.ProcessStep>
    {
        Task<int> ExecuteAsync(string query,object parameter);
        Task<int> ExecuteAsync(string query);
        Task<dynamic> QueryAsync(string query, object parameter);
        Task<dynamic> QueryAsync(string query);
    }
}
