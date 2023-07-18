using AutoMapper;
using DSList.Data.Interfaces;
using DSList.Service.Interfaces;

namespace DSList.Service.Services
{
    public class GameListService : IGameListService
    {
        private readonly IGameListRepository _repository;
        private readonly IMapper _mapper;

        public GameListService(IGameListRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
