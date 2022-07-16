using IMDbApiLib;
using IMDbApiLib.Models;
using Microsoft.Extensions.Options;
using Mupsee.Interfaces;
using Mupsee.Models;

namespace Mupsee.Services
{
    public class ImdbApiService : IImdbApiService
    {
        protected ApiLib ApiLib;
        public ApiSettings ApiSettings { get; set; }
        public ImdbApiService(IOptions<ApiSettings> settings)
        {
            ApiSettings = settings.Value;
            ApiLib = new ApiLib(ApiSettings.ImdbApi);
        }

        /// <inheritdoc/>
        public async Task<List<Movie>> GetMovieListByFilterAsync(string filter)
        {
            try
            {
                var response = new List<Movie>();
                var searchInput = new AdvancedSearchInput() { TitleType = AdvancedSearchTitleType.Feature_Film, Count=AdvancedSearchCount.Fifty };

                if (string.IsNullOrWhiteSpace(filter))
                {
                    searchInput.ReleaseDateFrom = "2022-07-01";
                    searchInput.Sort = AdvancedSearchSort.Release_Date_Descending;
                }
                else {
                    searchInput.Title = filter;

                }

                //var data = await ApiLib.AdvancedSearchAsync(new AdvancedSearchInput {Title=filter, TitleType=AdvancedSearchTitleType.Feature_Film });\
                var data = await ApiLib.AdvancedSearchAsync(searchInput);


                foreach (var item in data.Results.Take(25))
                {
                    response.Add(new Movie
                    {
                        Id = item.Id,
                        Image = item.Image,
                    });
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc/>
        public async Task<MovieRatings> GetMovieRatingsByIdAsync(string id)
        {
            try
            {
                var data = await ApiLib.RatingsAsync(id);

                var response = new MovieRatings
                {
                    ImdbRating = data.IMDb,
                    RottenTomatoesRating = data.RottenTomatoes
                };

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc/>
        public async Task<Movie> GetMovieDataByIdAsync(string movieId)
        {
            try
            {
                var data = await ApiLib.TitleAsync(movieId);
                var movie = new Movie()
                {
                    Title = data.Title,
                    Genres = data.Genres,
                    Runtime = data.RuntimeStr,
                    Description = data.Plot,
                    Release = data.ReleaseDate,
                    Id = data.Id,
                    Image = data.Image,
                    MovieRatings = await GetMovieRatingsByIdAsync(movieId),
                };

                return movie;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
}
