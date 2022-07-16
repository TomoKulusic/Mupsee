using Mupsee.Models;

namespace Mupsee.Interfaces
{
    public interface IMupseeService
    {
        /// <summary>
        /// Searching for movies by criteria
        /// </summary>
        /// <param name="movieName"></param>
        /// <returns>List of movies</returns>
        Task<List<Movie>> SearchAsync(string movieName);

        /// <summary>
        /// Will search for a movie by provided id
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        Task<Movie> SearchByIdAsync(string movieId);

        /// <summary>
        /// Will save movie as favorite
        /// </summary>
        /// <returns></returns>
        Task SaveMovieAsFavoriteAsync(FavoriteMovie movie);

        /// <summary>
        /// This method will check if the provided movie is marked as favorite
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        Task<bool> CheckIsFavorite(string movieId);

        /// <summary>
        /// This method will get all movies that are marked as favorite
        /// </summary>
        /// <returns></returns>
        Task<List<Movie>> GetFavoriteMoviesAsync();

    }
}
