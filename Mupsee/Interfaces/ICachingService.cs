namespace Mupsee.Interfaces
{
    public interface ICachingService<T> where T : class
    {
        void CacheData(string name, T data);
        T CheckIfDataIsCached(string name);
    }
}
