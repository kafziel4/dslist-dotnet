namespace DSList.Data.Projections
{
    public class GameMinProjection
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Year { get; set; }
        public string ImgUrl { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
