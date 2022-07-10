using Microsoft.AspNetCore.Mvc;
using Mupsee.Interfaces;
using Mupsee.Models;

namespace Mupsee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MupseeController : ControllerBase
    {
        private readonly IMupseeService _movieService;

        public MupseeController(IMupseeService movieService)
        {
            _movieService = movieService;
        }

        /// <summary>
        /// Will return number of movies that matches search criteria
        /// </summary>
        /// <param name="search"></param>
        /// <returns>List of movie objects</returns>
        [HttpGet("SearchAsync")]
        public async Task<List<Movie>> SearchAsync(string search)
        {
            return await _movieService.SearchAsync(search);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        public async Task<Movie> SearchByIdAsync(string movieId)
        {
            //return _movieService.SearchByIdAsync(movieId);
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPut]
        public async Task SaveMovieAsync()
        {
            //return _movieService.SaveMovieAsync();
            throw new NotImplementedException();
        }
    }
}
