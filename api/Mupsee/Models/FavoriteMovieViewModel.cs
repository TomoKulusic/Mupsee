using System.ComponentModel.DataAnnotations;

namespace Mupsee.Models
{
    public class FavoriteMovieViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public bool IsFavorite { get; set; }
        [Required]
        public string Image { get; set; }
    }
}
