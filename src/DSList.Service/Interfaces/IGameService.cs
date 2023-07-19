using DSList.Service.Dtos;

namespace DSList.Service.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<GameMinDto>> FindAllAsync();
        Task<GameDto> FindByIdAsync(long id);
        Task<IEnumerable<GameMinDto>> FindByListAsync(long id);
    }
}
