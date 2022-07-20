using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mupsee.Interfaces;
using Mupsee.Models;
using System.ComponentModel.DataAnnotations;

namespace Mupsee.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;

        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        /// <summary>
        /// Action for setting movie as favorite
        /// </summary>
        /// <param name="favoriteMovieViewModel"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("SaveMovieAsFavoriteAsync")]
        public async Task SaveMovieAsFavoriteAsync([FromBody] FavoriteMovieViewModel favoriteMovieViewModel)
        {
            await _favoriteService.SaveMovieAsFavoriteAsync(favoriteMovieViewModel);
        }

        /// <summary>
        /// Checks if the movie is set as favorite
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        [Authorize]

        [HttpGet("CheckIsFavorite")]
        public bool CheckIsFavorite([Required] string movieId)
        {
            return _favoriteService.CheckIsFavorite(movieId);
        }

        /// <summary>
        /// Gets all movies that are set as favorite
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("GetFavoriteMovies")]
        public List<MovieViewModel> GetFavoriteMovies()
        {
            return _favoriteService.GetFavoriteMovies();
        }
    }
}
