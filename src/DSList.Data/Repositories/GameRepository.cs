using DSList.Data.DbContexts;
using DSList.Data.Entities;
using DSList.Data.Interfaces;
using DSList.Data.Projections;
using Microsoft.EntityFrameworkCore;

namespace DSList.Data.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly GameDbContext _context;

        public GameRepository(GameDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Game>> FindAllAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Game?> FindByIdAsync(long id)
        {
            return await _context.Games.FindAsync(id);
        }

        public async Task<IEnumerable<GameMinProjection>> SearchByListAsync(long id)
        {
            return new List<GameMinProjection>();
        }
    }
}
