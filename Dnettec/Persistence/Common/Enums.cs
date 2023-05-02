using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnettec.Persistence.Common
{
	public enum Provider : int
	{
		SqlServer = 0,
		MySql = 1,
		PostgreSQL = 2,
		Oracle = 3,
		InMemory = 4,
	}

	public enum RecordStatus : int
	{
		IsActive = 1,
		DeActive = 2,
		Deleted = 3
	}
}
