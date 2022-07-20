namespace Repository.Entities
{
    public class MovieTrailers : BaseEntity
    {
        public string MovieId { get; set; }
        public string YoutubeVideoIDs { get; set; }
        public DateTime CachedAtUtc { get; set; }
        public int CachedTimes { get; set; }
    }
}
