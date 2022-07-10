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
        /// 
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        Task<Movie> SearchByIdAsync(string movieId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task SaveMovieAsync();

    }
}
