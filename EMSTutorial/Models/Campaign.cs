using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EMSTutorial.Models
{
    public class Campaign
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string CampaignName { get; set; }
        [Required]
        public string CampaignDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool DigestCampaign { get; set; }
        public List<string> LinkedKeywords { get; set; }
        public string DailyDigest { get; set; }

        [JsonIgnore]
        public bool CampaignStatus { get; set; }
        public string GetDigestStatus()
        {
            return DigestCampaign ? "True" : "False";
        }

        public string GetCampaignStatus()
        {
            return CampaignStatus ? "Inactive" : "Active";
        }

    }
}
