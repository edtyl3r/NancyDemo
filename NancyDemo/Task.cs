using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NancyDemo
{
    public class Task
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Text { get; set; }
    }
}