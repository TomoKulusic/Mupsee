using Mupsee.Models;

namespace Mupsee.Interfaces
{
    public interface IImdbApiService
    {
        /// <summary>
        /// Gets movie data
        /// </summary>
        /// <param name="movieName"></param>
        /// <returns>List of movie objects</returns>
        Task<List<Movie>> GetMovieListByFilterAsync(string filter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        Task<Movie> GetMovieDataByIdAsync(string movieId);

        /// <summary>
        /// Returns the ratings of the movie found by imdb ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Movie ratings object</returns>
        Task<MovieRatings> GetMovieRatingsByIdAsync(string id);
    }
}
