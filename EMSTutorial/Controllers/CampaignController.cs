using EMSTutorial.Data;
using EMSTutorial.DTO;
using EMSTutorial.Models;
using Infinion_Campaign.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Infinion_Campaign.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CampaignController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
      
        public CampaignController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
       

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CampaignDTO>>> GetCampaigns()
        {
            var campaigns = await _dbContext.campaigns.ToListAsync();
            var campaignDTOs = campaigns.Select(c => new CampaignDTO
            {
                Id = c.Id,
                CampaignName = c.CampaignName,
                CampaignDescription = c.CampaignDescription,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                DigestCampaign = c.DigestCampaign ? "Yes" : "No", // Assuming DigestCampaign is a boolean
                LinkedKeywords = c.LinkedKeywords,
                DailyDigest = c.DailyDigest,
                CampaignStatus = c.CampaignStatus ? "Active" : "Inactive" // Assuming Status is a property of the Campaign entity
            }).ToList();

            return Ok(campaignDTOs);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Campaign campaign)
        {
            var CreateCampaign = new Campaign
            {
                CampaignName = campaign.CampaignName,
                CampaignDescription = campaign.CampaignDescription,
                StartDate = campaign.StartDate,
                EndDate = campaign.EndDate,
                LinkedKeywords = campaign.LinkedKeywords,
                DigestCampaign = campaign.DigestCampaign,
                DailyDigest = campaign.DailyDigest,
                CampaignStatus = campaign.CampaignStatus
            };
            _dbContext.campaigns.Add(CreateCampaign);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = CreateCampaign.Id }, CreateCampaign);
        }

        [HttpGet("{id}")]
        public ActionResult<CampaignByIdDTO> GetById(int id)
        {
            var campaign = _dbContext.campaigns.Find(id);
            if (campaign == null)
            {
                return NotFound($"No Campaign Found with ID {id}");
            }

            var campaignDTO = new CampaignByIdDTO
            {
                CampaignName = campaign.CampaignName,
                CampaignDescription = campaign.CampaignDescription,
                StartDate = campaign.StartDate,
                EndDate = campaign.EndDate,
                DigestCampaign = campaign.DigestCampaign ? "Yes" : "No", // Assuming DigestCampaign is a boolean
                LinkedKeywords = campaign.LinkedKeywords,
                DailyDigest = campaign.DailyDigest,
                CampaignStatus = campaign.CampaignStatus ? "Active" : "Inactive" // Assuming Status is a property of the Campaign entity
            };

            return Ok(campaignDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CampaignUpdateDTO campaignDTO)
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

            existingCampaign.CampaignName = campaignDTO.CampaignName;
            existingCampaign.CampaignDescription = campaignDTO.CampaignDescription;
            existingCampaign.StartDate = campaignDTO.StartDate;
            existingCampaign.EndDate = campaignDTO.EndDate;
            existingCampaign.DigestCampaign = campaignDTO.DigestCampaign;
            existingCampaign.LinkedKeywords = campaignDTO.LinkedKeywords;
            existingCampaign.DailyDigest = campaignDTO.DailyDigest;
        // Update other properties as needed

        _dbContext.SaveChanges();

            return NoContent();
        }
       
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _dbContext.campaigns.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            _dbContext.campaigns.Remove(product);
            _dbContext.SaveChanges();

            return NoContent();
        }

       
    }

}

    
