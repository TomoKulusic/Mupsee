using Mupsee.Interfaces;
using Mupsee.Models;
using Repository.Context;
using Repository.Entities;

namespace Mupsee.Services
{
    public class MovieService : IMovieService
    {
        private readonly IYoutubeApiService _youtubeApiService;
        private readonly IImdbApiService _imdbApiService;

        public MovieService(IYoutubeApiService youtubeApiService, IImdbApiService imdbApiService)
        {
            _youtubeApiService = youtubeApiService;
            _imdbApiService = imdbApiService;
        }

        /// <inheritdoc/>
        public async Task<List<MovieViewModel>> SearchMoviesAsync(string movieName)
        {
            try
            {
                return await _imdbApiService.GetMovieListByFilterAsync(movieName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc/>
        public async Task<MovieViewModel> SearchMovieByIdAsync(string movieId)
        {
            if (string.IsNullOrWhiteSpace(movieId))
                throw new ArgumentNullException($"Parameter {movieId} cannot be null");

            try
            {
                var movieViewModel = await _imdbApiService.GetMovieDataByIdAsync(movieId);
                movieViewModel.Trailers = await _youtubeApiService.GetYoutubeVideosBySearchCriteriaAsync(movieViewModel.Title, 20, movieId);

                return movieViewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }  
    }
}
