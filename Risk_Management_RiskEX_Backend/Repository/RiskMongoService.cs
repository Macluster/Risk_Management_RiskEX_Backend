using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend.Repository
{
    public class RiskMongoService:IRiskMongoService
    {

        private readonly IUserRepository _userRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMongoCollection<RiskDraftDTO> _booksCollection;

        public RiskMongoService(
            IOptions<RiskDatabaseSettingscs> riskSettings,IUserRepository userRepository, IDepartmentRepository departmentRepository)
        {
            var mongoClient = new MongoClient(
               riskSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                riskSettings.Value.DatabaseName);

            _booksCollection = mongoDatabase.GetCollection<RiskDraftDTO>(
                riskSettings.Value.CollectionName);

            _userRepository = userRepository;
            _departmentRepository = departmentRepository;
        }

        //public async Task<List<Risk>> GetAsync() =>
        //    await _booksCollection.Find(_ => true).ToListAsync();

        //public async Task<dynamic?> GetAsync(string id) =>
        //    await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(RiskDraftDTO newBook)
        {

     
            await _booksCollection.InsertOneAsync(newBook);
        }


        public async Task<List<Object>> GetAllDraftsAsync()
        {
            var draftList=  await _booksCollection.Find(_ => true).ToListAsync();

            var result = new List<dynamic>();

            foreach (var draft in draftList)
            {

                if (draft == null)
                    return null;

                var responsibleUser = draft.ResponsibleUserId.HasValue
                    ? await _userRepository.GetNameAndEmailOfAUser(draft.ResponsibleUserId.Value)
                    : null;

                var department = draft.DepartmentId.HasValue
                    ? await _departmentRepository.GetDepartmentById(draft.DepartmentId.ToString())
                    : null;

                var createdByUser = draft.CreatedBy.HasValue
                    ? await _userRepository.GetNameAndEmailOfAUser(draft.CreatedBy.Value)
                    : null;

                var tempdraft = new
                {
                    draft.Id,
                    draft.RiskName,
                    draft.Description,
                    draft.RiskType,
                    riskTypeName = draft.RiskType?.ToString(),
                    draft.Impact,
                    draft.Mitigation,
                    draft.Contingency,
                    draft.OverallRiskRatingBefore,
                    draft.ResponsibleUserId,
                    ResponsibleUserName = responsibleUser?.FullName,
                    draft.PlannedActionDate,
                    draft.DepartmentId,
                    DepartmentName = department?.DepartmentName ?? "",
                    draft.ProjectId,
                    draft.CreatedBy,
                    CreatedByName = createdByUser?.FullName ?? "",
                    RiskAssessments = new List<RiskAssessmentDraftDTO>()
                };


                result.Add(tempdraft);
            }
            return result;
        }


        public async Task<bool> DeleteDraftByIdAsync(string riskId)
        {
            var result = await _booksCollection.DeleteOneAsync(x => x.Id == riskId);
            return result.DeletedCount > 0;
        }

        public async Task<RiskDraftDTO>GetDraftByIdAsync(string riskId)
        {
            var result = await _booksCollection.Find(x => x.Id == riskId).FirstOrDefaultAsync();
            return result;
        }





        //public async Task<List<RiskDraftDTO>> GetAllDraftsByDepartmentIdAsync(int departmentId)

        public async Task<List<Object>> GetAllDraftsByDepartmentIdAsync(int departmentId)

        {
      


            var draftList = await _booksCollection.Find(x => x.DepartmentId == departmentId).ToListAsync();

            var result = new List<dynamic>();

            foreach (var draft in draftList)
            {

                Console.WriteLine("haiiiiiiiiiiiiiiiiiii"+await _departmentRepository.GetDepartmentById(draft.DepartmentId.ToString()));

                if (draft == null)
                    return null;

                var responsibleUser = draft.ResponsibleUserId.HasValue
                    ? await _userRepository.GetNameAndEmailOfAUser(draft.ResponsibleUserId.Value)
                    : null;

                var department = draft.DepartmentId.HasValue
                    ? await _departmentRepository.GetDepartmentById(draft.DepartmentId.ToString())
                    : null;

                var createdByUser = draft.CreatedBy.HasValue
                    ? await _userRepository.GetNameAndEmailOfAUser(draft.CreatedBy.Value)
                    : null;

                var tempdraft = new
                {
                    draft.Id,
                    draft.RiskName,
                    draft.Description,
                    draft.RiskType,
                    riskTypeName = draft.RiskType?.ToString(),
                    draft.Impact,
                    draft.Mitigation,
                    draft.Contingency,
                    draft.OverallRiskRatingBefore,
                    draft.ResponsibleUserId,
                    ResponsibleUserName = responsibleUser?.FullName,
                    draft.PlannedActionDate,
                    draft.DepartmentId,
                    DepartmentName = department?.DepartmentName ?? "",
                    draft.ProjectId,
                    draft.CreatedBy,
                    CreatedByName = createdByUser?.FullName ?? "",
                    RiskAssessments = new List<RiskAssessmentDraftDTO>()
                };


                result.Add(tempdraft);
            }
            return result;
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



        public async Task UpdateAsync(string id, RiskDraftDTO updatedDraft)
        {
            var objectId = new ObjectId(id);
            var filter = Builders<RiskDraftDTO>.Filter.Eq("_id", objectId);

            updatedDraft.Id = id; // Ensure the Id is set, or MongoDB will treat it as a new document

            var result = await _booksCollection.ReplaceOneAsync(filter, updatedDraft);

            Console.WriteLine($"Matched: {result.MatchedCount}, Modified: {result.ModifiedCount}");

            if (result.MatchedCount == 0)
            {
                throw new Exception("Draft not found.");
            }
        }




    }
}
