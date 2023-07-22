using DSList.Service.DTOs;

namespace DSList.Service.Interfaces
{
    public interface IGameListService
    {
        Task<IEnumerable<GameListDto>> FindAllAsync();
        Task MoveAsync(long listId, int sourceIndex, int destinationIndex);
    }
}
