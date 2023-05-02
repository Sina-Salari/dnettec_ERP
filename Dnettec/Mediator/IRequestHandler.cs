using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnettec.Mediator
{
	public interface IRequestHandler<in TCommand> : MediatR.IRequestHandler<TCommand, Result> where TCommand : MediatR.IRequest<Result>
	{

	}

	public interface IRequestHandler<in TCommand, TReturnValue> : MediatR.IRequestHandler<TCommand, Result<TReturnValue>> where TCommand : MediatR.IRequest<Result<TReturnValue>>
	{

	}
}
