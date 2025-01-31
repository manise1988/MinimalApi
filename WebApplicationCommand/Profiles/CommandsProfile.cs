
using AutoMapper;

using WebApplicationCommand.Dtos;
using WebApplicationCommand.Models;

namespace WebApplicationCommand.Profiles
{
    public class CommandsProfile: Profile
    {
        public CommandsProfile() { 
            CreateMap<Command,CommandReadDto>().ReverseMap();
            CreateMap<Command,CommandCreateDto>().ReverseMap();
            CreateMap<Command,CommandUpdateDto>().ReverseMap();
        
        }
    }
}
