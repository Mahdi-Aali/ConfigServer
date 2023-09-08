using AutoMapper;
using ConfigServer.Application.Command.ApplicationCommands;
using ConfigServer.Application.DTOs;

namespace ConfigServer.API;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap(typeof(CreateApplicationDTO), typeof(CreateNewApplicationCommand));
    }
}
