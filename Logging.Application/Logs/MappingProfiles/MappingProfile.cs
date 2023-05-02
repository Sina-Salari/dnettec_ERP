using AutoMapper;
using Dnettec.Logging;
using Logging.Application.Logs.Commands;

namespace Logging.Application.Logs.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() : base()
        {
            CreateMap<CreateLogCommand, Log>();
            CreateMap<Log, CreateLogCommand>();
        }
    }
}
