using MongoDB.Bson.Serialization.Attributes;

namespace MangoWebApi.DAL.Entities
{
    public class AttributeCategory
    {
        [BsonId]
        Categories CategoryId { get; set; }
        [BsonId]
        Attribute AttributeId { get; set; }


    }
}
