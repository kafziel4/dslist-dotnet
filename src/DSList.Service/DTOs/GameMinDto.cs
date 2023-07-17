namespace DSList.Service.Dtos
{
    public class GameMinDto
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Year { get; set; }
        public string ImgUrl { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
    }
}
