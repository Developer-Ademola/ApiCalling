using System.ComponentModel.DataAnnotations;

namespace Infinion_Campaign.DTO
{
    public class CampaignUpdateDTO
    {
        public int Id { get; set; }
        public string CampaignName { get; set; }
        [Required]
        public string CampaignDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool DigestCampaign { get; set; }
        public List<string> LinkedKeywords { get; set; }
        public string DailyDigest { get; set; }
        public string GetDigestStatus()
        {
            return DigestCampaign ? "True" : "False";
        }

    }
}
