using DSList.Data.DbContexts;
using DSList.Data.Entities;
using DSList.Data.Interfaces;

namespace DSList.Data.Repositories
{
    public class GameListRepository : IGameListRepository
    {
        private readonly GameDbContext _context;

        public GameListRepository(GameDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GameList>> FindAllAsync()
        {
            return new List<GameList>();
        }
    }
}
