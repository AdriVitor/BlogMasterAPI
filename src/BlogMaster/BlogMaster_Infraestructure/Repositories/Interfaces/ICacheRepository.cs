namespace BlogMaster_Infraestructure.Repositories.Interfaces
{
    public interface ICacheRepository
    {
        T Get<T>(string key);
        void Set<T>(string key, T value);
        List<T> GetList<T>(string key);
        void SetList<T>(string key, List<T> value);
    }
}
