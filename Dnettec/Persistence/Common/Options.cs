using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnettec.Persistence.Common
{
	public class Options : object
	{
		public Options() : base()
		{
		}

		// **********
		public Provider Provider { get; set; }
		// **********

		// **********
		public string ConnectionString { get; set; }

		// **********

		// **********
		public string InMemoryDatabaseName { get; set; }
		// **********
	}
}
