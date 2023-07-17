namespace DSList.Service.Dtos
{
    public class GameDto
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Genre { get; set; } = string.Empty;
        public string Platforms { get; set; } = string.Empty;
        public double Score { get; set; }
        public string ImgUrl { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string LongDescription { get; set; } = string.Empty;
    }
}
