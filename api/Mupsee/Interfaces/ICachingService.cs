namespace Mupsee.Interfaces
{
    public interface ICachingService<T> where T : class
    {
        /// <summary>
        /// Method for caching data
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        void CacheData(string name, T data);

        /// <summary>
        /// Method for checking if the data is already cached
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        T CheckIfDataIsCached(string name);
    }
}
