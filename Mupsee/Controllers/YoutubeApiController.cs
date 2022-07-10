using Microsoft.AspNetCore.Mvc;
using Mupsee.Interfaces;
using Mupsee.Models;
using RottenTomatoes.Api;

namespace Mupsee.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class YoutubeApiController : ControllerBase
    {
        private readonly IYoutubeApiService _youtubeService;
        private readonly IRottenTomatoesApiService _rotten;


        public YoutubeApiController(IYoutubeApiService youtubeService, IRottenTomatoesApiService rotten)
        {
            _youtubeService = youtubeService;
            _rotten = rotten;
        }

        /// <summary>
        /// Will access GetYoutubeVideoByNameAsync method in IYoutubeApiService service and fetch movie data
        /// </summary>
        /// <param name="videoName">Search criteria</param>
        /// <param name="results">N of objects that will be returned</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<MovieTrailerResponseItem>> GetYoutubeVideosBySearchCriteriaAsync(string videoName, int results = 1)
        {
            await _rotten.GetMovieDataAsync(videoName);
            return await _youtubeService.GetYoutubeVideosBySearchCriteriaAsync(videoName, results);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        //[HttpGet]
        //public async Task<string> GetMovieDetails(string movie)
        //{
        //   await _rotten.GetMovieDataAsync(movie);
        //    return "dsaddas";
        //}
    }
}
