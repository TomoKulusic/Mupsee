using Microsoft.AspNetCore.Mvc;
using Mupsee.Interfaces;

namespace Mupsee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideosController : ControllerBase
    {
        private readonly IYoutubeApiService _youtubeApiService;

        public VideosController(IYoutubeApiService youtubeApiService)
        {
            _youtubeApiService = youtubeApiService;
        }

        //[HttpGet("GetVideosAsync")]
        //public async Task<List<Movie>> GetVideosByMovieNameAsync(string? search)
        //{
        //    return await _mupseeService.SearchAsync(search);
        //}
    }
}
