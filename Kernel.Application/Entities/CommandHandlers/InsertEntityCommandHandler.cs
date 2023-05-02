using AutoMapper;
using FluentResults;
using Kernel.Application.Entities.Commands;
using Kernel.Persistence.Common.UnitOfWork;
using Microsoft.Extensions.Logging;

namespace Kernel.Application.Entities.CommandHandlers
{
    public class InsertEntityCommandHandler
        : Dnettec.Mediator.IRequestHandler<InsertEntityCommand, Guid>
    {
        public InsertEntityCommandHandler(
            ILogger<InsertEntityCommandHandler> logger,
            IMapper mapper,
            IUnitOfWork unitOfWork) : base()
        {
            Logger = logger;
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        protected IUnitOfWork UnitOfWork { get; }
        protected IMapper Mapper { get; }
        protected ILogger<InsertEntityCommandHandler> Logger { get; }

        public async Task<Result<Guid>> Handle(InsertEntityCommand request, CancellationToken cancellationToken)
        {
            Result<Guid> result = new Result<Guid>();
            try
            {

                if (await UnitOfWork.Entities.GetAnyAsync(p => p.EntityName == request.EntityName))
                {
                    result.WithError(string.Format(Resources.Messages.Errors.DuplicateData, Resources.DataDictionary.EntityName));
                    return result;
                }

                var model = Mapper.Map<Domain.Models.Entity>(request);

                await UnitOfWork.Entities.InsertAsync(model);

                await UnitOfWork.SaveAsync();

                result.WithSuccess(string.Format(Resources.Messages.Successes.InsertSuccess, Resources.DataDictionary.Entity));
                result.WithValue(model.Id);
            }
            catch (Exception ex)
            {
                result.WithError(string.Format(Resources.Messages.Successes.InsertSuccess, Resources.DataDictionary.Entity));
            }
            return result;
        }
    }
}
