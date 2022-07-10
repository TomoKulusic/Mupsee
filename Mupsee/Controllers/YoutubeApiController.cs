using Microsoft.AspNetCore.Mvc;
using Mupsee.Interfaces;
using Mupsee.Models;

namespace Mupsee.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class YoutubeApiController : ControllerBase
    {
        private readonly IYoutubeApiService _youtubeService;

        public YoutubeApiController(IYoutubeApiService youtubeService)
        {
            _youtubeService = youtubeService;
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
            return await _youtubeService.GetYoutubeVideosBySearchCriteriaAsync(videoName, results);
        }
    }
}
