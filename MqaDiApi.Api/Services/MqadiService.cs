using Microsoft.EntityFrameworkCore;
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
        await _mqadiesCollection.Find(_ => _.Done.Equals(false)).ToListAsync();

        public async Task<Mqadi> GetAsync(int id) => await _mqadiesCollection.Find(x => x.Id.Equals(id)).FirstOrDefaultAsync();

        public async Task<Mqadi> CreateAsync(Mqadi newMqadi)
        {
            await _mqadiesCollection.InsertOneAsync(newMqadi);
            return newMqadi;
        }
        public async Task UpdateAsync(string id, Mqadi mqadi) => await _mqadiesCollection.ReplaceOneAsync(x => x.Id == id, mqadi);
        public async Task RemoveAsync(string id) => await _mqadiesCollection.DeleteOneAsync(x => x.Id == id);

        public async Task MakeDoneAsync(string id)
        {
            var mqadi = _mqadiesCollection.Find(x => x.Id.Equals(id)).FirstOrDefaultAsync().Result;
            mqadi.Done = true;
            await _mqadiesCollection.ReplaceOneAsync(x => x.Id == id, mqadi);
        }
    }
}
