
using EMSTutorial.Data;
using EMSTutorial.DTO;
using EMSTutorial.Models;

namespace EMSTutorial.Repository
{
    public class CampaignService:ICampaignService
    {
        private readonly ApplicationDbContext _dbContext;

        public CampaignService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Campaign> CreateRequest(Campaign campaign)
        {
            _dbContext.campaigns.Add(campaign);
            await _dbContext.SaveChangesAsync();
            return campaign;
        }

        public async Task<CampaignDTO> GetAll(CampaignDTO campaign)
        {
            throw new NotImplementedException();
        }
    }
}
