using DSList.Data.DbContexts;
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
    }
}
