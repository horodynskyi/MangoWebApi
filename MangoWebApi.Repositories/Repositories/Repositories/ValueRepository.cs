using MangoWebApi.DAL.Entities;
using MangoWebApi.Repositories.Interfaces.Repositories;
using MongoDB.Driver;

namespace MangoWebApi.Repositories.Repositories.Repositories
{
    public class ValueRepository:GenericRepository<Values,int>,IValueRepository
    {
        public ValueRepository(IMongoClient client) : base(client)
        {

        }
    }
}
