using System.Collections.Generic;
using MongoDB.Driver;
using BalloonInventory.Models;

namespace BalloonInventory.Services
{
    public class InventoryServices
    {
        private readonly IMongoCollection<InventoryItem> _inventoryItem;

        public InventoryServices(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _inventoryItem = database.GetCollection<InventoryItem>("InventoryItems");
        }

        public InventoryItem Create(InventoryItem item)
        {
            _inventoryItem.InsertOne(item);
            return item;
        }

        public IList<InventoryItem> Read() =>
           _inventoryItem.Find(ite => true).ToList();

        public InventoryItem Find(string id) =>
            _inventoryItem.Find(ite => ite.Id == id).SingleOrDefault();

        public void Update(InventoryItem item) =>
          _inventoryItem.ReplaceOne(ite => ite.Id == item.Id, item);

        public void Delete(string id) =>
            _inventoryItem.DeleteOne(ite => ite.Id == id);
    }
}
