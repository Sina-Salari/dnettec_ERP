﻿using Logging.Domain.Enums;

namespace Logging.Application.Logs.Commands
{
	public class CreateLogCommand : Dnettec.Mediator.IRequest<Guid>
	{
		public CreateLogCommand() : base()
		{
		}

		// **********
		public LogLevel Level { get; set; }
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
		public string HttpReferrer { get; set; }
		// **********

		// **********
		public string Message { get; set; }
		// **********

		// **********
		public string Parameters { get; set; }
		// **********

		// **********
		public string Exceptions { get; set; }
		// **********
	}
}
