using DSList.Data.Entities;
using DSList.Data.Interfaces;

namespace DSList.Data.Repositories
{
    public class GameReposiotry : IGameRepository
    {

        public GameReposiotry()
        {
        }

        public async Task<IEnumerable<Game>> FindAllAsync()
        {
            return new List<Game>();
        }
    }
}
