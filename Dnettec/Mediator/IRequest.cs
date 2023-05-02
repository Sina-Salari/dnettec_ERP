using FluentResults;

namespace Dnettec.Mediator
{
    public interface IRequest : MediatR.IRequest<Result>
    {

    }

    public interface IRequest<TReturnValue> : MediatR.IRequest<Result<TReturnValue>>
    {

    }
}
