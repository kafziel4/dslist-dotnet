using DSList.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSList.Data.Configuration
{
    internal class GameListConfiguration : IEntityTypeConfiguration<GameList>
    {
        public void Configure(EntityTypeBuilder<GameList> builder)
        {
            builder.HasData(
                new GameList
                {
                    Id = 1,
                    Name = "Aventura e RPG"
                },
                new GameList
                {
                    Id = 2,
                    Name = "Jogos de plataforma"
                });
        }
    }
}
