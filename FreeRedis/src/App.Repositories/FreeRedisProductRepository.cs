using App.Model.Entities;
using App.Repositories.Interface;
using FreeRedis;
using System.Text.Json;

namespace App.Repositories
{
    public class FreeRedisProductRepository : IProductRepository
    {
        //simple connection just for example. 
        private readonly static RedisClient _client = new RedisClient("127.0.0.1:6379");

        public void AddProduct(Product product)
        {
            string json = JsonSerializer.Serialize(product);
            _client.Set(product.Code, json);
        }

        public void DeleteProduct(string code)
        {
            _client.Del(code);
        }

        public Product GetProduct(string code)
        {
            string json = _client.Get(code);
            if (string.IsNullOrEmpty(json))
                return null;
            
            var result = JsonSerializer.Deserialize<Product>(json)!;
            return result;
        }
    }
}
