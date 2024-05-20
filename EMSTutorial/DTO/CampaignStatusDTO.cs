namespace Infinion_Campaign.DTO
{
    public class CampaignStatusDTO
    {
        public int Id { get; set; }
        public bool CampaignStatus { get; set; }

        public string GetCampaignStatus()
        {
            return CampaignStatus ? "Active" : "Inactive";
        }


    }
}
