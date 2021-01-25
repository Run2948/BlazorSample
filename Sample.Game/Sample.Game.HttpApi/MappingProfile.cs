using System;
using AutoMapper;
using Sample.Game.Entities.Dtos;
using Sample.Game.Entities.Models;

namespace Sample.Game.HttpApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Player, PlayerDto>();
            CreateMap<Player, PlayerWithCharactersDto>();
            CreateMap<Character, CharacterDto>();

            CreateMap<PlayerForCreationDto, Player>();
            CreateMap<PlayerForUpdateDto, Player>();
        }
    }
}
