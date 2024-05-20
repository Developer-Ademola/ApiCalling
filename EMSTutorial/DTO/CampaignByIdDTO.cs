using Newtonsoft.Json;

namespace Infinion_Campaign.DTO
{
    public class CampaignByIdDTO
    {
        public string CampaignName { get; set; }
        public string CampaignDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DigestCampaign { get; set; }
        public List<string> LinkedKeywords { get; set; }
        public string DailyDigest { get; set; }
        public string CampaignStatus { get; set; }
    }
}
