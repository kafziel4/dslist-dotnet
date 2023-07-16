using DSList.Service.Dtos;

namespace DSList.Service.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<GameMinDto>> FindAllAsync();
    }
}
