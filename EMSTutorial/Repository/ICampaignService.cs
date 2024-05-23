using EMSTutorial.DTO;
using EMSTutorial.Models;

namespace Infinion_Campaign.Repository
{
    public interface ICampaignService
    {
        Task<Campaign> CreateRequest(Campaign campaign);
        Task<CampaignDTO> GetAll(CampaignDTO campaign);
    }
}
