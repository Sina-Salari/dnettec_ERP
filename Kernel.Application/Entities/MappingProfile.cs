namespace Kernel.Application.Entities
{
	public class MappingProfile : AutoMapper.Profile
	{
		public MappingProfile() : base()
		{
			CreateMap<Commands.InsertEntityCommand, Domain.Models.Entity>();
			CreateMap<Domain.Models.Entity, Commands.InsertEntityCommand>();
		}
	}
}
