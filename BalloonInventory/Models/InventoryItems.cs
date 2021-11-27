using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BalloonInventory.Models
{
    public class InventoryItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Brand { get; set; }

        public string Size { get; set; }

        public string Color { get; set; }

        public int QTY { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

    }
}