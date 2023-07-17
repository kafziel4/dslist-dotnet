using AutoMapper;
using DSList.Data.Entities;
using DSList.Service.Dtos;

namespace DSList.Service.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameMinDto>();
        }
    }
}
