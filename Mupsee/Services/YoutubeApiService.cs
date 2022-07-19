using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Mupsee.Interfaces;
using Mupsee.Models;
using Mupsee.Models.SettingsModels;
using Repository.Context;
using Repository.Entities;

namespace Mupsee.Services
{
    public class YoutubeApiService : IYoutubeApiService
    {
        protected YouTubeService YouTubeService;
        private ApiConfiguration _apiConfiguration { get; set; }
        private readonly MupseeContext _context;
        private readonly ICachingService<string> _cachingService;

        public YoutubeApiService(IOptions<ApiConfiguration> apiConfiguration, MupseeContext context, ICachingService<string> cachingService)
        {
            _context = context;
            _cachingService = cachingService;

            _apiConfiguration = apiConfiguration.Value;

            YouTubeService = new YouTubeService(new BaseClientService.Initializer
            {
                ApplicationName = this.GetType().ToString(),
                ApiKey = _apiConfiguration.YoutubeApi,
            });
        }

        /// <inheritdoc/>
        public async Task<string> GetYoutubeVideosBySearchCriteriaAsync(string search, int results, string movieId)
        {
            try
            {
                var cachedData = _cachingService.CheckIfDataIsCached(movieId);
                if (cachedData is null)
                {
                    var videos = "";

                    var searchRequest = YouTubeService.Search.List("snippet");
                    searchRequest.Q = search;
                    searchRequest.MaxResults = results;
                    searchRequest.Type = "video";

                    var response = await searchRequest.ExecuteAsync();
                    videos = string.Join(",", response.Items.Select(x => x.Id.VideoId));

                    var movieTrailers = new MovieTrailers()
                    {
                        MovieId = movieId,
                        YoutubeVideoIDs = videos,
                        CachedAtUtc = DateTime.Now,
                    };

                    await _context.MovieTrailers.AddAsync(movieTrailers);
                    await _context.SaveChangesAsync();

                    _cachingService.CacheData(movieId, videos);

                    return videos;
                }
                else {
                    return cachedData;
                }
            }
            catch (Exception ex)
            {
                throw;
            }       
        }
    }
}
