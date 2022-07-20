using Mupsee.Models;

namespace Mupsee.Interfaces
{
    /// <summary>
    /// Interface for favorite service
    /// </summary>
    public interface IFavoriteService
    {
        /// <summary>
        /// Will save movie as favorite
        /// </summary>
        Task SaveMovieAsFavoriteAsync(FavoriteMovieViewModel favoriteMovieViewModel);

        /// <summary>
        /// This method will check if the provided movie is marked as favorite
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns>Bool result</returns>
        bool CheckIsFavorite(string movieId);

        /// <summary>
        /// This method will get all movies that are marked as favorite
        /// </summary>
        /// <returns>List of movies</returns>
        List<MovieViewModel> GetFavoriteMovies();
    }
}
