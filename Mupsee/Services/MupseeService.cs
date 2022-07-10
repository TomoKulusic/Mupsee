using Mupsee.Interfaces;
using Mupsee.Models;

namespace Mupsee.Services
{
    public class MupseeService : IMupseeService
    {
        private readonly IYoutubeApiService _youtubeApiService;
        private readonly IImdbApiService _imdbApiService;

        public MupseeService(IYoutubeApiService youtubeApiService, IImdbApiService imdbApiService)
        {
            _youtubeApiService = youtubeApiService;
            _imdbApiService = imdbApiService;
        }

        /// <inheritdoc/>
        public async Task<List<Movie>> SearchAsync(string movieName)
        {
            try
            {
                var movies = await _imdbApiService.GetMovieDataByNameAsync(movieName);

                foreach (var movie in movies)
                {
                    movie.MovieTrailerResponseItems = await _youtubeApiService.GetYoutubeVideosBySearchCriteriaAsync(movie.Title, 1);
                };

                return movies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc/>
        public Task<Movie> SearchByIdAsync(string movieId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task SaveMovieAsync()
        {
            throw new NotImplementedException();
        }
    }
}
