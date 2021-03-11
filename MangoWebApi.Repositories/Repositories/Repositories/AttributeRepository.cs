using MangoWebApi.DAL.Entities;
using MangoWebApi.Repositories.Interfaces.Repositories;
using MongoDB.Driver;

namespace MangoWebApi.Repositories.Repositories.Repositories
{
    public class AttributeRepository :GenericRepository<Attribute,int>,IAttributeRepository
    {
        public AttributeRepository(IMongoClient client) : base(client)
        {

        }

    }
}
