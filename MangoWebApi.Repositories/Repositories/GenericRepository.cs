using MangoWebApi.DAL.Interfaces;
using MangoWebApi.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoWebApi.Repositories.Repositories
{
    public class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId> where TEntity : class, IEntity<TId>
    {
        private readonly IMongoCollection<TEntity> _collection;
    
        public GenericRepository(IMongoClient client)
        {
            var database = client.GetDatabase("Shop");
            var collection = database.GetCollection<TEntity>(typeof(TEntity).Name);

            _collection = collection;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
            

            return entity;
        }

        

        public async Task<IEnumerable<TEntity>> Get()
        {
            var  collection = await _collection.Find(_ => true).ToListAsync();
            return collection;
        }

        public async Task<TEntity> GetById(TId id)
        {

            var filter = Builders<TEntity>.Filter.Eq(c => c.id, id);
            var collection = await _collection.Find(filter).FirstOrDefaultAsync();
            return collection;
        }

        public async Task<bool> Update(TId id, TEntity entity)
        {
            var filter = Builders<TEntity>.Filter.Eq(c => c.id, id);
            var update = Builders<TEntity>.Update
                .Set(c => c, entity);
            var result = await _collection.UpdateOneAsync(filter, update);

            return result.ModifiedCount == 1;
        }

        public async Task<bool> Delete(TId id)
        {
            var filter = Builders<TEntity>.Filter.Eq(c => c.id, id);
            var result = await _collection.DeleteOneAsync(filter);

            return result.DeletedCount == 1;
        }
    }
}
