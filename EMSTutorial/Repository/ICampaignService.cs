using EMSTutorial.DTO;
using EMSTutorial.Models;

namespace EMSTutorial.Repository
{
    public interface ICampaignService
    {
        Task<Campaign> CreateRequest(Campaign campaign);
        Task<CampaignDTO> GetAll(CampaignDTO campaign);
    }
}
