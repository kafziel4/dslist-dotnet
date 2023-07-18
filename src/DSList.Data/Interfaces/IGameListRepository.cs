using DSList.Data.Entities;

namespace DSList.Data.Interfaces
{
    public interface IGameListRepository
    {
        Task<IEnumerable<GameList>> FindAllAsync();
    }
}
