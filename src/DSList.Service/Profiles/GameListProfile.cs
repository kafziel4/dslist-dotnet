using AutoMapper;
using DSList.Data.Entities;
using DSList.Service.DTOs;

namespace DSList.Service.Profiles
{
    public class GameListProfile : Profile
    {
        public GameListProfile()
        {
            CreateMap<GameList, GameListDto>();
        }
    }
}
