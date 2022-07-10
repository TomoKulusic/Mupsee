using IMDbApiLib.Models;
using Mupsee.Models;

namespace Mupsee.Interfaces
{
    public interface IImdbApiService
    {
        Task<List<Movie>> GetMovieDataByNameAsync(string movieName);
        Task<MovieRatings> GetMovieRatingsById(string id);
    }
}
