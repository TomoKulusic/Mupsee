using Mupsee.Models;

namespace Mupsee.Interfaces
{
    public interface IMovieService
    {
        /// <summary>
        /// Searching for movies by criteria
        /// </summary>
        /// <param name="movieName"></param>
        /// <returns>List of movies</returns>
        Task<List<MovieViewModel>> SearchMoviesAsync(string movieName);

        /// <summary>
        /// Will search for a movie by provided id
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns>Movie</returns>
        Task<MovieViewModel> SearchMovieByIdAsync(string movieId);
    }
}
