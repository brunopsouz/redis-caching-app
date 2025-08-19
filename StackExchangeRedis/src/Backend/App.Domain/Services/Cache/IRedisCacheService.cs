namespace App.Domain.Services.Cache
{
    public interface IRedisCacheService
    {
        Task<T> GetAsync<T>(string key);
        Task SetData<T>(string key, T data);
    }
}
