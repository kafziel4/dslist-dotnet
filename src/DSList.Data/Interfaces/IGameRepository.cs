using DSList.Data.Entities;
using DSList.Data.Projections;

namespace DSList.Data.Interfaces
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> FindAllAsync();
        Task<Game?> FindByIdAsync(long id);
        Task<IEnumerable<GameMinProjection>> SearchByListAsync(long id);
    }
}
