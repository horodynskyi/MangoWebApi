using MangoWebApi.DAL.Entities;
using MangoWebApi.Repositories.Interfaces;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace MangoWebApi.Repositories.Repositories
{
    public class ProductRepositories : GenericRepository<Product, int>, IProductRepository
    {
        
        private readonly IMongoCollection<Product> _collection;
        public ProductRepositories(IMongoClient client):base(client)
        {
            var database = client.GetDatabase("Shop");
            var collection = database.GetCollection<Product>(typeof(Product).Name);

            _collection = collection;
        }
   
        


    }
}
