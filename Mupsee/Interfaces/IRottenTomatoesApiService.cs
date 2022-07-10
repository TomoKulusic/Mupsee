
using RottenTomatoes.Api;

namespace Mupsee.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRottenTomatoesApiService
    {
        public Task<MoviesResponse> GetMovieDataAsync(string movie);
    }
}
