using DSList.Service.Dtos;
using DSList.Service.Interfaces;

namespace DSList.Service.Services
{
    public class GameService : IGameService
    {
        public Task<IEnumerable<GameMinDto>> FindAllAsync()
        {
            IEnumerable<GameMinDto> list = new List<GameMinDto>();
            return Task.FromResult(list);
        }
    }
}
