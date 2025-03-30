using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend.Repository
{
    public class RiskMongoService
    {

        private readonly IMongoCollection<RiskDTO> _booksCollection;

        public RiskMongoService(
            IOptions<RiskDatabaseSettingscs> riskSettings)
        {
            var mongoClient = new MongoClient(
               riskSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                riskSettings.Value.DatabaseName);

            _booksCollection = mongoDatabase.GetCollection<RiskDTO>(
                riskSettings.Value.CollectionName);
        }

        //public async Task<List<Risk>> GetAsync() =>
        //    await _booksCollection.Find(_ => true).ToListAsync();

        //public async Task<dynamic?> GetAsync(string id) =>
        //    await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(RiskDTO newBook)
        {

     
            await _booksCollection.InsertOneAsync(newBook);
        }
         

        //public async Task UpdateAsync(string id, Risk updatedBook) =>
        //    await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        //public async Task RemoveAsync(string id) =>
        //    await _booksCollection.DeleteOneAsync(x => x.Id == id);
    
}
}
