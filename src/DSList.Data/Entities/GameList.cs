using System.ComponentModel.DataAnnotations;

namespace DSList.Data.Entities
{
    public class GameList
    {
        public long Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; } = string.Empty;

        public GameList()
        {
        }

        public GameList(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public override bool Equals(object? obj)
        {
            return obj is GameList list &&
                   Id == list.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
