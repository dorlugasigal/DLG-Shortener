using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DLG_Shortener.Models
{
    public class ShortUrl
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [Url]
        public string Url { get; set; }

        [RegularExpression("[a-z0-9]{0,5}")]
        [MaxLength(5)]
        public string Slug { get; set; }
    }
}