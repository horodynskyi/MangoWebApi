using MangoWebApi.DAL.Entities;
using MangoWebApi.Repositories.Interfaces.Repositories;
using MongoDB.Driver;

namespace MangoWebApi.Repositories.Repositories.Repositories
{
    public class CategoryRepository:GenericRepository<Categories,int>, Interfaces.Repositories.ICategoryRepository
    {
        public CategoryRepository(IMongoClient client) : base(client)
        {

        }
    }
}
