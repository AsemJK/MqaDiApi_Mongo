using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MqaDiApi.Data.Models;
using MqaDiApi.Data.Settings;

namespace MqaDiApi.Services
{
    public class MqadiService : IMqadiService
    {
        private readonly IMongoCollection<Mqadi> _mqadiesCollection;
        public MqadiService(IOptions<MongoDbConfig> dbOptions)
        {
            var mongoClient = new MongoClient(
            dbOptions.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                dbOptions.Value.DatabaseName);

            _mqadiesCollection = mongoDatabase.GetCollection<Mqadi>(
                dbOptions.Value.MqadiCollectionName);
        }
        public async Task<List<Mqadi>> GetAsync() =>
        await _mqadiesCollection.Find(_ => true).ToListAsync();

        public async Task<Mqadi> GetAsync(int id) => await _mqadiesCollection.Find(x => x.Id.Equals(id)).FirstOrDefaultAsync();
    }
}
