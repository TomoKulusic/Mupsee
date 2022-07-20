using IMDbApiLib;
using IMDbApiLib.Models;
using Microsoft.Extensions.Options;
using Mupsee.Interfaces;
using Mupsee.Models;
using Mupsee.Models.SettingsModels;

namespace Mupsee.Services
{
    public class ImdbApiService : IImdbApiService
    {
        private ApiLib ApiLib;
        private ApiConfiguration _apiConfiguration { get; set; }
        public ImdbApiService(IOptions<ApiConfiguration> apiConfiguration)
        {
            _apiConfiguration = apiConfiguration.Value;
            ApiLib = new ApiLib(_apiConfiguration.ImdbApi);
        }

        /// <inheritdoc/>
        public async Task<List<MovieViewModel>> GetMovieListByFilterAsync(FilterModel filter)
        {
            try
            {
                var moviesVm = new List<MovieViewModel>();

                var searchInput = new AdvancedSearchInput() { TitleType = AdvancedSearchTitleType.Feature_Film, Count=AdvancedSearchCount.Fifty };     

                if (filter is null)
                {
                    searchInput.Sort = AdvancedSearchSort.Release_Date_Descending;
                }

                searchInput.Title = !string.IsNullOrWhiteSpace(filter.Title) ? filter.Title : "";

                if(!string.IsNullOrWhiteSpace(filter.Genre))
                    searchInput.Genres = (AdvancedSearchGenre)Enum.Parse(typeof(AdvancedSearchGenre), filter.Genre);

                if (!string.IsNullOrWhiteSpace(filter.Language))
                    searchInput.Languages = (AdvancedSearchLanguage)Enum.Parse(typeof(AdvancedSearchLanguage), filter.Language);

                if (filter.Rating > 0)
                    searchInput.UserRatingFrom = filter.Rating;

                var response = await ApiLib.AdvancedSearchAsync(searchInput);

                foreach (var movie in response.Results)
                {
                    moviesVm.Add(new MovieViewModel
                    {
                        Id = movie.Id,
                        Image = movie.Image,
                    });
                }

                return moviesVm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc/>
        public async Task<MovieRatingsViewModel> GetMovieRatingsByIdAsync(string id)
        {
            try
            {
                var response = await ApiLib.RatingsAsync(id);

                var movieRatingsVm = new MovieRatingsViewModel
                {
                    ImdbRating = response.IMDb,
                    RottenTomatoesRating = response.RottenTomatoes
                };

                return movieRatingsVm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc/>
        public async Task<MovieViewModel> GetMovieDataByIdAsync(string movieId)
        {
            try
            {
                var response = await ApiLib.TitleAsync(movieId);
                var movieVm = new MovieViewModel()
                {
                    Title = response.Title,
                    Genres = response.Genres,
                    Runtime = response.RuntimeStr,
                    Description = response.Plot,
                    Release = response.ReleaseDate,
                    Id = response.Id,
                    Image = response.Image,
                    MovieRatingsVm = await GetMovieRatingsByIdAsync(movieId),
                };

                return movieVm;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
}
