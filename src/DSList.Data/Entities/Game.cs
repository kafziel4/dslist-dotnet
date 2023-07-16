using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSList.Data.Entities
{
    public class Game
    {
        public long Id { get; set; }

        [StringLength(255)]
        public string Title { get; set; } = string.Empty;

        [Column("game_year")]
        public int Year { get; set; }

        [StringLength(255)]
        public string Genre { get; set; } = string.Empty;

        [StringLength(255)]
        public string Platforms { get; set; } = string.Empty;

        public double Score { get; set; }

        [StringLength(255)]
        public string ImgUrl { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string LongDescription { get; set; } = string.Empty;

        public Game()
        {
        }

        public Game(long id,
            string title,
            int year,
            string genre,
            string platforms,
            double score,
            string imgUrl,
            string shortDescription,
            string longDescription)
        {
            Id = id;
            Title = title;
            Year = year;
            Genre = genre;
            Platforms = platforms;
            Score = score;
            ImgUrl = imgUrl;
            ShortDescription = shortDescription;
            LongDescription = longDescription;
        }

        public override bool Equals(object? obj)
        {
            return obj is Game game &&
                   Id == game.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
