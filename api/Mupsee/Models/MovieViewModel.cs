namespace Mupsee.Models
{
    public class MovieViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Runtime { get; set; }
        public string Release { get; set; }
        public string Genres { get; set; }
        public MovieRatingsViewModel MovieRatingsVm { get; set; } = new();
        public string Trailers  { get; set;}
    }
}
