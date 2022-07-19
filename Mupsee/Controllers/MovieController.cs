using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mupsee.Interfaces;
using Mupsee.Models;
using System.ComponentModel.DataAnnotations;

namespace Mupsee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        /// <summary>
        /// Will return number of movies that matches search criteria
        /// </summary>
        /// <param name="search"></param>
        /// <returns>List of movie objects</returns>
        [Authorize]

        [HttpGet("SearchAsync")]
        public async Task<List<MovieViewModel>> SearchAsync(string? search)
        {
            return await _movieService.SearchMoviesAsync(search);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [Authorize]

        [HttpGet("SearchMovieByIdAsync")]
        public async Task<MovieViewModel> SearchMovieByIdAsync([Required] string movieId)
        {
            return await _movieService.SearchMovieByIdAsync(movieId);
        }
    }
}
