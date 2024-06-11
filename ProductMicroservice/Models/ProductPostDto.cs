using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductMicroservice.Models
{
	public class ProductPostDto
	{
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;
        [BsonElement("description")]
        public string Description { get; set; } = string.Empty;
        [BsonElement("price")]
        public int Price { get; set; }
        [BsonElement("stock")]
        public int Stock { get; set; }
        [BsonElement("available")]
        public bool IsAvailable { get; set; }
    }
}

