using stickwebapi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace stickwebapi.Services
{
    public class AlertsService
    {
        private readonly IMongoCollection<Alert> _alertsCollection;

        public AlertsService(
            IOptions<AlertsDatabaseSettings> alertsDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                alertsDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                alertsDatabaseSettings.Value.DatabaseName);

            _alertsCollection = mongoDatabase.GetCollection<Alert>(
                alertsDatabaseSettings.Value.CollectionName);
        }

        public async Task<List<Alert>> GetAsync() =>
            await _alertsCollection.Find(_ => true).ToListAsync();

        public async Task<Alert?> GetAsync(string id) =>
            await _alertsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Alert newBook) =>
            await _alertsCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, Alert updatedBook) =>
            await _alertsCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _alertsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
