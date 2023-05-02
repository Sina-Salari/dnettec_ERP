using Dnettec.Domain;
using Dnettec.Persistence.Common;

namespace Logging.Domain.Models.Base
{
	public abstract class BaseEntity : IBaseEntity
	{
		protected BaseEntity() : base()
		{
			Id = Guid.NewGuid();
		}

		public Guid Id { get; set; }

        public RecordStatus Status { get; set; }
    }
}
