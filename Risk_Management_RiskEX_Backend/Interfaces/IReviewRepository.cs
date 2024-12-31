namespace Risk_Management_RiskEX_Backend.Interfaces
{
    public interface IReviewRepository
    {

        Task<Object> GetReviewStatusOfARisk(int id,bool isPreReview);
        
    }
}
