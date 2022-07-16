using Mupsee.Interfaces;
using Mupsee.Models;
using Repository.Context;
using Repository.Entities;

namespace Mupsee.Services
{
    public class MupseeService : IMupseeService
    {
        private readonly IYoutubeApiService _youtubeApiService;
        private readonly IImdbApiService _imdbApiService;
        private readonly MupseeContext _context;


        public MupseeService(IYoutubeApiService youtubeApiService, IImdbApiService imdbApiService, MupseeContext context)
        {
            _youtubeApiService = youtubeApiService;
            _imdbApiService = imdbApiService;
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<List<Movie>> SearchAsync(string movieName)
        {
            try
            {
                var movies = await _imdbApiService.GetMovieListByFilterAsync(movieName);

                //foreach (var movie in movies)
                //{
                //    movie.MovieTrailerResponseItems = await _youtubeApiService.GetYoutubeVideosBySearchCriteriaAsync(movie.Title, 1);
                //};

                return movies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc/>
        public async Task<Movie> SearchByIdAsync(string movieId)
        {
            try
            {
                var movie = await _imdbApiService.GetMovieDataByIdAsync(movieId);
                //movie.MovieTrailerResponseItems = await _youtubeApiService.GetYoutubeVideosBySearchCriteriaAsync(movie.Title, 1);

                return movie;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc/>
        public async Task SaveMovieAsFavoriteAsync(FavoriteMovie movie)
        {

            try
            {
                var isMovieAlreadyExist = _context.Favorites.FirstOrDefault(x => x.MovieId == movie.Id);

                if (isMovieAlreadyExist is not null)
                {
                    isMovieAlreadyExist.IsFavorite = movie.IsFavorite;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var data = new Favorite()
                    {
                        MovieId = movie.Id,
                        IsFavorite = movie.IsFavorite,
                        Image = movie.Image
                    };

                    await _context.Favorites.AddAsync(data);
                    await _context.SaveChangesAsync();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> CheckIsFavorite(string movieId)
        {
            try
            {
                var data =  _context.Favorites.FirstOrDefault(x => x.MovieId == movieId);

                if (data is null)
                    return false;

                return data.IsFavorite;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
