﻿namespace Logging.Persistence.Logs.ViewModels
{
	public class GetLogsQueryResponseViewModel : object
	{
		public GetLogsQueryResponseViewModel() : base()
		{
		}

		// **********
		public Guid Id { get; set; }
		// **********

		// **********
		public Domain.Enums.LogLevel Level { get; set; }
		// **********

		// **********
		public DateTime TimeStamp { get; set; }
		// **********



		// **********
		public string ApplicationName { get; set; }
		// **********

		// **********
		public string Namespace { get; set; }
		// **********

		// **********
		public string ClassName { get; set; }
		// **********

		// **********
		public string MethodName { get; set; }
		// **********



		// **********
		public string RemoteIP { get; set; }
		// **********

		// **********
		public string Username { get; set; }
		// **********

		// **********
		public string RequestPath { get; set; }
		// **********



		// **********
		public string Message { get; set; }
		// **********
	}
}