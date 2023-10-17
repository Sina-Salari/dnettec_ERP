using Kernel.Domain.Models.Base;

namespace Kernel.Domain.Models
{
    public class Application : BaseEntity
    {
        public string DomainName { get; set; }
        public string SubDomainName { get; set; }

        public string DatabaseSource { get; set; }
        public string DatabaseName { get; set; }
        public string DatabaseUserName { get; set; }
        public string DatabasePassword { get; set; }

        public string TokenKey { get; set; }
        public int TokenTimeOut { get; set; }

        public virtual List<Entity> Entities { get; set; }
        public virtual List<Language> Languages { get; set; }
        public virtual List<Message> Messages { get; set; }
        public virtual List<ValidationStep> ValidationSteps { get; set; }
        public virtual List<ProcessStep> ProcessSteps { get; set; }
        public virtual List<WorkFlow> WorkFlows { get; set; }
        public virtual List<Account> Accounts { get; set; }
    }
}