using MongoDB.Bson.Serialization.Attributes;

namespace MangoWebApi.DAL.Entities
{
    public class AttributeCategory
    {
        [BsonId]
        Categories categoryId { get; set; }
        [BsonId]
        Attribute attributeId { get; set; }


    }
}
