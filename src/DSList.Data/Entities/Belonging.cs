using Microsoft.EntityFrameworkCore;

namespace DSList.Data.Entities
{
    [PrimaryKey(nameof(GameId), nameof(GameListId))]
    public class Belonging
    {
        public long GameId { get; set; }
        public Game Game { get; set; } = null!;
        public long GameListId { get; set; }
        public GameList GameList { get; set; } = null!;
        public int Position { get; set; }

        public Belonging()
        {
        }

        public Belonging(long gameId,
            Game game,
            long gameListId,
            GameList gameList,
            int position)
        {
            GameId = gameId;
            Game = game;
            GameListId = gameListId;
            GameList = gameList;
            Position = position;
        }

        public override bool Equals(object? obj)
        {
            return obj is Belonging belonging &&
                   GameId == belonging.GameId &&
                   GameListId == belonging.GameListId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GameId, GameListId);
        }
    }
}
