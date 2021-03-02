using MangoWebApi.DAL.Interfaces;
using MongoDB.Bson.Serialization.Attributes;

namespace MangoWebApi.DAL.Entities
{
    public class Product:IEntity<int>
    {
        [BsonId]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public int category_id { get; set; }
    }
}
