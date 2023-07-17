using DSList.Data.Entities;

namespace DSList.Data.Interfaces
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> FindAllAsync();
    }
}
