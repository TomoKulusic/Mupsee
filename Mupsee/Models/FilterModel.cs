using Microsoft.AspNetCore.Mvc;

namespace Mupsee.Models
{
    [BindProperties]
    public class FilterModel
    {
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public int? Rating { get; set; }
        public string? Language { get; set; }
        public string? Country { get; set; }
    }
}
