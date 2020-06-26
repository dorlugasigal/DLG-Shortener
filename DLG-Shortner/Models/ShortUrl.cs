using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DLG_Shortner.Models
{
    public class ShortUrl
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Url { get; set; }

        public string Slug { get; set; }
    }
}