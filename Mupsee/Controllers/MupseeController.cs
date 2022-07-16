using Microsoft.AspNetCore.Mvc;
using Mupsee.Interfaces;
using Mupsee.Models;

namespace Mupsee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MupseeController : ControllerBase
    {
        private readonly IMupseeService _mupseeService;

        public MupseeController(IMupseeService mupseeService)
        {
            _mupseeService = mupseeService;
        }

        /// <summary>
        /// Will return number of movies that matches search criteria
        /// </summary>
        /// <param name="search"></param>
        /// <returns>List of movie objects</returns>
        [HttpGet("SearchAsync")]
        public async Task<List<Movie>> SearchAsync(string? search)
        {
            return await _mupseeService.SearchAsync(search);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("SearchByIdAsync")]
        public async Task<Movie> SearchByIdAsync(string movieId)
        {
            if (string.IsNullOrWhiteSpace(movieId))
                throw new ArgumentNullException($"Parameter {movieId} cannot be null");

            return await _mupseeService.SearchByIdAsync(movieId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("SaveMovieAsFavorite")]
        public async Task SaveMovieAsFavorite([FromBody] FavoriteMovie movie)
        {
            if (movie is null)
                throw new ArgumentNullException($"Parameter {movie} cannot be null");

            await _mupseeService.SaveMovieAsFavoriteAsync(movie);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        [HttpGet("CheckIsFavorite")]
        public async Task<bool> CheckIsFavorite(string movieId)
        {
            if (string.IsNullOrWhiteSpace(movieId))
                throw new ArgumentNullException($"Parameter {movieId} cannot be null");

            return await _mupseeService.CheckIsFavorite(movieId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetFavoriteMovies")]
        public async Task<List<Movie>> GetFavoriteMoviesAsync()
        {
            return await _mupseeService.GetFavoriteMoviesAsync();
        }
    }
}
