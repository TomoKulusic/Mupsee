using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Mupsee.Interfaces;
using Mupsee.Models;
using Repository.Context;
using Repository.Entities;

namespace Mupsee.Services
{
    public class YoutubeApiService : IYoutubeApiService
    {
        protected YouTubeService YouTubeService;
        public ApiSettings ApiSettings { get; set; }
        private readonly MupseeContext _context;
        private readonly ICachingService<string> _cachingService;

        public YoutubeApiService(IOptions<ApiSettings> settings, MupseeContext context, ICachingService<string> cachingService)
        {
            _context = context;
            _cachingService = cachingService;

            ApiSettings = settings.Value;

            YouTubeService = new YouTubeService(new BaseClientService.Initializer
            {
                ApplicationName = this.GetType().ToString(),
                ApiKey = ApiSettings.YoutubeApi,
            });
        }

        /// <inheritdoc/>
        public async Task<string> GetYoutubeVideosBySearchCriteriaAsync(string search, int results, string movieId)
        {
            var data = new MovieTrailers();

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


                    data = new MovieTrailers()
                    {
                        MovieId = movieId,
                        YoutubeVideoIDs = videos,
                        CachedAtUtc = DateTime.Now,
                    };

                    await SaveYoutubeVideosAsync(data);

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

        public async Task SaveYoutubeVideosAsync(MovieTrailers data)
        {
            try
            {
                await _context.MovieTrailers.AddAsync(data);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
