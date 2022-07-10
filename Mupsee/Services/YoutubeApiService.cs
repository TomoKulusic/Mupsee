using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.Extensions.Options;
using Mupsee.Interfaces;
using Mupsee.Models;

namespace Mupsee.Services
{
    public class YoutubeApiService : IYoutubeApiService
    {
        protected YouTubeService YouTubeService;
        public ApiSettings ApiSettings { get; set; }

        public YoutubeApiService(IOptions<ApiSettings> settings)
        {
            ApiSettings = settings.Value;

            YouTubeService = new YouTubeService(new BaseClientService.Initializer
            {
                ApplicationName = this.GetType().ToString(),
                ApiKey = ApiSettings.YoutubeApi,
            });
        }

        /// <inheritdoc/>
        public async Task<List<MovieTrailer>> GetYoutubeVideosBySearchCriteriaAsync(string search, int results)
        {
            var returnList = new List<MovieTrailer>();

            try
            {
                var searchRequest = YouTubeService.Search.List("snippet");
                searchRequest.Q = search;
                searchRequest.MaxResults = results;
                searchRequest.Type = "video";

                var response = await searchRequest.ExecuteAsync();

                foreach (var item in response.Items)
                {
                    returnList.Add(new MovieTrailer
                    {
                        Title = item.Snippet.Title,
                        TrailerId = item.Id.VideoId
                    });
                }

                return returnList;

            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
