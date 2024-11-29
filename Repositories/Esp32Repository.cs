using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using stickwebapi.Models;

namespace stickwebapi.Repositories
{
    public class Esp32Repository
    {
        private readonly IMongoCollection<BsonDocument> _collection;

        public Esp32Repository(IMongoClient mongoClient, IOptions<DatabaseSettings> dbSettings)
        {
            var database = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            //_collection = database.GetCollection<BsonDocument>();
        }

        public async Task InsertDataAsync(BsonDocument data)
        {
            await _collection.InsertOneAsync(data);
        }

        public async Task<List<BsonDocument>> GetDataAsync()
        {
            return await _collection.Find(new BsonDocument()).ToListAsync();
        }
    }
}
