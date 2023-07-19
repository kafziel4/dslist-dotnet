using AutoMapper;
using DSList.Data.Entities;
using DSList.Data.Projections;
using DSList.Service.Dtos;

namespace DSList.Service.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameMinDto>();
            CreateMap<Game, GameDto>();
            CreateMap<GameMinProjection, GameMinDto>();
        }
    }
}
