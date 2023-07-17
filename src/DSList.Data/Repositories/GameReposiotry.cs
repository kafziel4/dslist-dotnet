using DSList.Data.DbContexts;
using DSList.Data.Entities;
using DSList.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DSList.Data.Repositories
{
    public class GameReposiotry : IGameRepository
    {
        private readonly GameDbContext _context;

        public GameReposiotry(GameDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Game>> FindAllAsync()
        {
            return await _context.Games.ToListAsync();
        }
    }
}
