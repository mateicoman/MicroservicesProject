using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UserMicroservice.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? UserId { get; set; }
    [BsonElement("name")] 
    public string Name { get; set; } = string.Empty;
    [BsonElement("address")] 
    public string Address { get; set; } = string.Empty;
}