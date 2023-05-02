namespace Kernel.Application.Entities.Commands
{
    public class InsertEntityCommand
        : Dnettec.Mediator.IRequest<Guid>
    {
        public string EntityName { get; set; }
        public bool IsBase { get; set; }
    }
}
