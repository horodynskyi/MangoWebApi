using MangoWebApi.DAL.Interfaces;
using MongoDB.Bson.Serialization.Attributes;

namespace MangoWebApi.DAL.Entities
{
    public class Categories : IEntity<int>
    {
        [BsonId]
        public int id { get; set; }
        public string name { get; set; }


    }
}
