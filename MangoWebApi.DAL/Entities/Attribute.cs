using MangoWebApi.DAL.Interfaces;
using MongoDB.Bson.Serialization.Attributes;

namespace MangoWebApi.DAL.Entities
{
    public class Attribute : IEntity<int>
    {
        [BsonId]
        public int Id { get; set; }
        public string title { get; set; }
        public string slug { get; set; }
        public string type { get; set; }

    }
}
