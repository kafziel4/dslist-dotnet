using DSList.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSList.Data.Configuration
{
    internal class BelongingConfiguration : IEntityTypeConfiguration<Belonging>
    {
        public void Configure(EntityTypeBuilder<Belonging> builder)
        {
            builder.HasData(
                new Belonging
                {
                    GameListId = 1,
                    GameId = 1,
                    Position = 0
                },
                new Belonging
                {
                    GameListId = 1,
                    GameId = 2,
                    Position = 1
                },
                new Belonging
                {
                    GameListId = 1,
                    GameId = 3,
                    Position = 2
                },
                new Belonging
                {
                    GameListId = 1,
                    GameId = 4,
                    Position = 3
                },
                new Belonging
                {
                    GameListId = 1,
                    GameId = 5,
                    Position = 4
                },
                new Belonging
                {
                    GameListId = 2,
                    GameId = 6,
                    Position = 0
                },
                new Belonging
                {
                    GameListId = 2,
                    GameId = 7,
                    Position = 1
                },
                new Belonging
                {
                    GameListId = 2,
                    GameId = 8,
                    Position = 2
                },
                new Belonging
                {
                    GameListId = 2,
                    GameId = 9,
                    Position = 3
                },
                new Belonging
                {
                    GameListId = 2,
                    GameId = 10,
                    Position = 4
                });
        }
    }
}
