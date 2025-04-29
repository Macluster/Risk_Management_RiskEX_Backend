using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend.Repository
{
    public class RiskMongoService
    {

        private readonly IMongoCollection<RiskDraftDTO> _booksCollection;

        public RiskMongoService(
            IOptions<RiskDatabaseSettingscs> riskSettings)
        {
            var mongoClient = new MongoClient(
               riskSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                riskSettings.Value.DatabaseName);

            _booksCollection = mongoDatabase.GetCollection<RiskDraftDTO>(
                riskSettings.Value.CollectionName);
        }

        //public async Task<List<Risk>> GetAsync() =>
        //    await _booksCollection.Find(_ => true).ToListAsync();

        //public async Task<dynamic?> GetAsync(string id) =>
        //    await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(RiskDraftDTO newBook)
        {

     
            await _booksCollection.InsertOneAsync(newBook);
        }


        public async Task<List<RiskDraftDTO>> GetAllDraftsAsync()
        {
            return await _booksCollection.Find(_ => true).ToListAsync();
        }


        public async Task<bool> DeleteDraftByIdAsync(string riskId)
        {
            var result = await _booksCollection.DeleteOneAsync(x => x.Id == riskId);
            return result.DeletedCount > 0;
        }


        public async Task<RiskDraftDTO> GetDraftByIdAsync(string riskId)
        {
            var result= await _booksCollection.Find(x => x.Id == riskId).FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<RiskDraftDTO>> GetAllDraftsByDepartmentIdAsync(int departmentId)
        {
            return await _booksCollection.Find(x => x.DepartmentId == departmentId).ToListAsync();
        }

        public async Task<List<RiskDraftDTO>> GetAllDraftsByCreatedUserAsync(int createdBy)
        {
            return await _booksCollection
                .Find(r => r.CreatedBy == createdBy)
                .ToListAsync();
        }





        //public async Task UpdateAsync(string id, Risk updatedBook) =>
        //    await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        //public async Task RemoveAsync(string id) =>
        //    await _booksCollection.DeleteOneAsync(x => x.Id == id);

    }
}
