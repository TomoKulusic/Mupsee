using IMDbApiLib.Models;
using Microsoft.AspNetCore.Mvc;
using Mupsee.Interfaces;
using Mupsee.Models;

namespace Mupsee.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TestingController : ControllerBase
    {
        private readonly IYoutubeApiService _youtubeService;
        private readonly IImdbApiService _imdbApiService;

        public TestingController(IYoutubeApiService youtubeService, IImdbApiService imdbApiService)
        {
            _youtubeService = youtubeService;
            _imdbApiService = imdbApiService;
        }

        /// <summary>
        /// Will access GetYoutubeVideoByNameAsync method in IYoutubeApiService service and fetch movie data
        /// </summary>
        /// <param name="videoName">Search criteria</param>
        /// <param name="results">N of objects that will be returned</param>
        /// <returns></returns>
        //[HttpGet("GetYoutubeVideosBySearchCriteriaAsync")]
        //public async Task<List<MovieTrailer>> GetYoutubeVideosBySearchCriteriaAsync(string videoName, int results = 1)
        //{
        //    return await _youtubeService.GetYoutubeVideosBySearchCriteriaAsync(videoName, results);
        //}

        [HttpGet("GetMovieDataByMovieNameAsync")]
        public async Task<List<Movie>> GetMovieDataByMovieNameAsync(string movieName)
        {
            return await _imdbApiService.GetMovieListByFilterAsync(movieName);
        }

        [HttpGet("GetMovieRatingsById")]
        public async Task<MovieRatings> GetMovieRatingsById(string movieImdbId)
        {
            return await _imdbApiService.GetMovieRatingsByIdAsync(movieImdbId);
        }
    }
}
