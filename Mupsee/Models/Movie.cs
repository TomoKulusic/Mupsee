namespace Mupsee.Models
{
    public class Movie
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public MovieRatings MovieRatings { get; set; } = new();
        public List<MovieTrailer> MovieTrailerResponseItems  { get; set;} = new();
    }
}
