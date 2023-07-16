using DSList.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSList.Data.Configuration
{
    internal class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            var shortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Odit esse officiis corrupti unde repellat non quibusdam! Id nihil itaque ipsum!";
            var longDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Delectus dolorum illum placeat eligendi, quis maiores veniam. " +
                "Incidunt dolorum, nisi deleniti dicta odit voluptatem nam provident temporibus reprehenderit blanditiis consectetur tenetur. " +
                "Dignissimos blanditiis quod corporis iste, aliquid perspiciatis architecto quasi tempore ipsam voluptates ea ad distinctio, sapiente qui, amet quidem culpa.";

            builder.HasData(
                new Game
                {
                    Id = 1,
                    Title = "Mass Effect Trilogy",
                    Score = 4.8,
                    Year = 2012,
                    Genre = "Role-playing (RPG), Shooter",
                    Platforms = "XBox, Playstation, PC",
                    ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/1.png",
                    ShortDescription = shortDescription,
                    LongDescription = longDescription
                },
                new Game
                {
                    Id = 2,
                    Title = "Red Dead Redemption 2",
                    Score = 4.7,
                    Year = 2018,
                    Genre = "Role-playing (RPG), Adventure",
                    Platforms = "XBox, Playstation, PC",
                    ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/2.png",
                    ShortDescription = shortDescription,
                    LongDescription = longDescription
                },
                new Game
                {
                    Id = 3,
                    Title = "The Witcher 3: Wild Hunt",
                    Score = 4.7,
                    Year = 2015,
                    Genre = "Role-playing (RPG), Adventure",
                    Platforms = "XBox, Playstation, PC",
                    ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/3.png",
                    ShortDescription = shortDescription,
                    LongDescription = longDescription
                },
                new Game
                {
                    Id = 4,
                    Title = "Sekiro: Shadows Die Twice",
                    Score = 3.8,
                    Year = 2019,
                    Genre = "Role-playing (RPG), Adventure",
                    Platforms = "XBox, Playstation, PC",
                    ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/4.png",
                    ShortDescription = shortDescription,
                    LongDescription = longDescription
                },
                new Game
                {
                    Id = 5,
                    Title = "Ghost of Tsushima",
                    Score = 4.6,
                    Year = 2020,
                    Genre = "Role-playing (RPG), Adventure",
                    Platforms = "XBox, Playstation, PC",
                    ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/5.png",
                    ShortDescription = shortDescription,
                    LongDescription = longDescription
                },
                new Game
                {
                    Id = 6,
                    Title = "Super Mario World",
                    Score = 4.7,
                    Year = 1990,
                    Genre = "Platform",
                    Platforms = "Super Nes, PC",
                    ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/6.png",
                    ShortDescription = shortDescription,
                    LongDescription = longDescription
                },
                new Game
                {
                    Id = 7,
                    Title = "Hollow Knight",
                    Score = 4.6,
                    Year = 2017,
                    Genre = "Platform",
                    Platforms = "XBox, Playstation, PC",
                    ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/7.png",
                    ShortDescription = shortDescription,
                    LongDescription = longDescription
                }
                , new Game
                {
                    Id = 8,
                    Title = "Ori and the Blind Forest",
                    Score = 4,
                    Year = 2015,
                    Genre = "Platform",
                    Platforms = "XBox, Playstation, PC",
                    ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/8.png",
                    ShortDescription = shortDescription,
                    LongDescription = longDescription
                }
                , new Game
                {
                    Id = 9,
                    Title = "Cuphead",
                    Score = 4.6,
                    Year = 2017,
                    Genre = "Platform",
                    Platforms = "XBox, Playstation, PC",
                    ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/9.png",
                    ShortDescription = shortDescription,
                    LongDescription = longDescription
                }
                , new Game
                {
                    Id = 10,
                    Title = "Sonic CD",
                    Score = 4,
                    Year = 1993,
                    Genre = "Platform",
                    Platforms = "Sega CD, PC",
                    ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/10.png",
                    ShortDescription = shortDescription,
                    LongDescription = longDescription
                });
        }
    }
}
