using EMSTutorial.Data;
using Infinion_Campaign.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Infinion_Campaign.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CampaignStatusController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public CampaignStatusController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPut("{id}")]
        public IActionResult UpdateStates(int id, CampaignStatusDTO campaignDTO)
        {
            if (id != campaignDTO.Id)
            {
                return BadRequest($"ID in the URL ({id}) does not match the ID in the request body.");
            }

            var existingCampaign = _dbContext.campaigns.Find(id);
            if (existingCampaign == null)
            {
                return NotFound($"No campaign found with ID {id}");
            }

            existingCampaign.CampaignStatus = campaignDTO.CampaignStatus;
            // Update other properties as needed

            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
