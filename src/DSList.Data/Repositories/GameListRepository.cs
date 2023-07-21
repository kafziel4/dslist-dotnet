using DSList.Data.DbContexts;
using DSList.Data.Entities;
using DSList.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            return await _context.GameLists.ToListAsync();
        }

        public async Task<IList<Belonging>> SearchBelongingsByListAsync(long listId)
        {
            return await _context.Belongings
                .Where(b => b.GameListId == listId)
                .OrderBy(b => b.Position)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
