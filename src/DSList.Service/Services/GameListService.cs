using DSList.Data.Interfaces;
using DSList.Service.Interfaces;

namespace DSList.Service.Services
{
    public class GameListService : IGameListService
    {
        private readonly IGameListRepository _repository;

        public GameListService(IGameListRepository repository)
        {
            _repository = repository;
        }
    }
}
