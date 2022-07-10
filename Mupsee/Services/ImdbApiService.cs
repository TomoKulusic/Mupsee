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

        public async Task<List<Movie>> GetMovieDataByNameAsync(string movieName)
        {
            try
            {
                var response = new List<Movie>();
                var data = await ApiLib.SearchMovieAsync(movieName);

                foreach (var item in data.Results)
                {
                    response.Add(new Movie
                    {
                        Title = item.Title,
                        Description = item.Description,
                        Id = item.Id,
                        Image = item.Image,
                        MovieRatings = await GetMovieRatingsById(item.Id),
                    });
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MovieRatings> GetMovieRatingsById(string id)
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
    }
}
