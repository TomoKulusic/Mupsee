using Mupsee.Models;
using Repository.Entities;

namespace Mupsee.Interfaces
{
    /// <summary>
    /// Youtube api service interface - container needed methods
    /// </summary>
    public interface IYoutubeApiService
    {
        /// <summary>
        /// Will return n of objects that contain video id and video title
        /// </summary>
        /// <param name="name">Search criteria</param>
        /// <param name="results">Number of objects returned</param>
        /// <returns></returns>
        Task<string> GetYoutubeVideosBySearchCriteriaAsync(string search, int results, string movieId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task SaveYoutubeVideosAsync(MovieTrailers data);
    }
}
