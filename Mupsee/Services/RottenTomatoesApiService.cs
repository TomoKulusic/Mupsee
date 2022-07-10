using Microsoft.Extensions.Options;
using Mupsee.Interfaces;
using Mupsee.Models;
using RottenTomatoes.Api;

namespace Mupsee.Services
{
    public class RottenTomatoesApiService : IRottenTomatoesApiService
    {
        protected RottenTomatoesRestClient RottenTomatoesRestClient;
        public ApiSettings ApiSettings { get; set; }


        public RottenTomatoesApiService(IOptions<ApiSettings> settings)
        { 
            ApiSettings = settings.Value;

            RottenTomatoesRestClient = new RottenTomatoesRestClient(ApiSettings.RottenApi);
        }

        public async Task<MoviesResponse> GetMovieDataAsync(string movie)
        {
            try
            {
                var moviesList = RottenTomatoesRestClient.MoviesSearch(movie);
                return moviesList;
            }
            catch {
                throw;
            }
        }
    }
}
