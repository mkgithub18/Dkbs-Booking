using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DKBS.Domain;
using DKBS.DTO;
using DKBS.Infrastructure.Sharepoint;
using DKBS.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DKBS.API.Controllers
{
    /// <summary>
    /// Partner controller
    /// </summary>
    [Route("partner")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private readonly IChoiceRepository _choiceRepoistory;
        private readonly IConfiguration _configuration;
        private readonly ISharepointService _sharePointService;
        private IMapper _mapper;
        /// <summary>
        /// Partner controller
        /// </summary>
        public PartnerController(IChoiceRepository choiceReposiroty, IMapper mapper, ISharepointService sharePointService, IConfiguration configuration)
        {
            _choiceRepoistory = choiceReposiroty;
            _mapper = mapper;
            _sharePointService = sharePointService;
            _configuration = configuration;
        }

        /// <summary>
        /// Get All partner details.
        /// </summary>
        /// <returns>List of partners.</returns>
        [HttpGet()]
        public ActionResult<CRMPartner> GetPartners()
        {
            return Ok(_choiceRepoistory.GetPartners());
        }
        /// <summary>
        /// Get Partner by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public ActionResult<CRMPartnerDTO> GetPartnerById(int id)
        {
            return _choiceRepoistory.GetPartners().Find(c => c.CRMPartnerId == id);
        }


        /// <summary>
        /// Creating Partner
        /// </summary>
        /// <param name="dto"></param>
        /// <response code="201">Returns the newly created partner</response>
        /// <response code="400">If the item is null</response>            
        /// <returns>newly created partner</returns>
        ///
        [Authorize]
        [HttpPost("")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreatePartner([FromBody] CRMPartnerDTO dto)
        {

            try
            {
                if (string.IsNullOrEmpty(dto.AccountId))
                {
                    ModelState.AddModelError("AccountId", "AccountId can't be null");
                    return BadRequest(ModelState);
                }

                if (dto == null)
                {
                    ModelState.AddModelError("Partner", "Partner object can't be null");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var partner = _choiceRepoistory.GetById<CRMPartner>(c => c.AccountId == dto.AccountId);

                if (partner != null)
                {
                    ModelState.AddModelError("Partner", $"Partner entry already exist for AccountId {dto.AccountId}.");
                    return BadRequest(ModelState);
                }

                CRMPartner newPartner = _mapper.Map<CRMPartnerDTO, CRMPartner>(dto);
                newPartner.CreatedBy = "CRM";
                newPartner.CreatedDate = DateTime.UtcNow;
                newPartner.LastModified = DateTime.UtcNow;
                newPartner.LastModifiedBy = "CRM";

                if (bool.Parse(_configuration["SharePointIntegrationEnabled"].ToString()))
                {
                    var sharePointId = await _sharePointService.InsertPartnerAsync(newPartner);
                    if (sharePointId <= 0)
                    {
                        return StatusCode(500, "An error occurred while creating sharepoint partner. Please try again or contact adminstrator");
                    }
                    newPartner.SharePointId = sharePointId;
                }

                _choiceRepoistory.Attach<CRMPartner>(newPartner);
                _choiceRepoistory.Complete();

                return CreatedAtRoute("GetPartnerByAccountId", new { newPartner.AccountId }, dto);
            }
            catch (Exception ex)
            {
                // TODO : Add logging and decide on showing ex.message
                return StatusCode(500, "An error occurred while creating partner. Please try again or contact adminstrator");
            }
        }

        /// <summary>
        /// Get partner details by account id
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [HttpGet("{accountId}", Name = "GetPartnerByAccountId")]
        public ActionResult<CRMPartnerDTO> GetPartnerByAccountId(string accountId)
        {
            var partner = _choiceRepoistory.GetById<CRMPartner>(c => c.AccountId == accountId);

            if (partner == null)
            {
                return NotFound(accountId);
            }

            var returnval = _mapper.Map<CRMPartner, CRMPartnerDTO>(partner);

            return Ok(returnval);
        }

        /// <summary>
        /// Update partner
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// 
        [Authorize]
        [HttpPut("{accountId}")]
        public async Task<IActionResult> UpdatePartner(string accountId, [FromBody] CRMPartnerDTO dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(accountId))
                {
                    ModelState.AddModelError("AccountId", "AccountId can't be null or empty.");
                    return BadRequest(ModelState);
                }

                if (dto == null)
                {
                    ModelState.AddModelError("Partner", "Partner object can't be null");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var partner = _choiceRepoistory.GetById<CRMPartner>(c => c.AccountId == accountId);

                if (partner == null)
                {
                    ModelState.AddModelError("Partner", $"No Partner found with AccountId {accountId}");
                    return NotFound(ModelState);
                }

                partner.Partnertype = dto.Partnertype;
                partner.MembershipType = dto.MembershipType;
                partner.PartnerName = dto.PartnerName;
                partner.CVR = dto.CVR;
                partner.Telefon = dto.Telefon;
                partner.Centertype = dto.Centertype;

                partner.Address1 = dto.Address1;
                partner.Address2 = dto.Address2;
                partner.Town = dto.Town;

                partner.PostNumber = dto.PostNumber;
                partner.Land = dto.Land;
                partner.StateAgreement = dto.StateAgreement;
                partner.Debitornummer = dto.Debitornummer;
                partner.Debitornummer2 = dto.Debitornummer2;
                partner.Regions = dto.Regions;
                partner.MembershipStartDate = dto.MembershipStartDate;
                partner.PublicURL = dto.PublicURL;
                partner.Email = dto.Email;
                partner.Website = dto.Website;
                partner.PanoramView = dto.PanoramView;
                partner.RecommandedNPGRT60 = dto.RecommandedNPGRT60;
                partner.QualityAssuredNPSGRD30 = dto.QualityAssuredNPSGRD30;
                partner.LastModified = DateTime.UtcNow;
                partner.LastModifiedBy = "CRM";  //later need to change
                _choiceRepoistory.Attach(partner);
                if (bool.Parse(_configuration["SharePointIntegrationEnabled"].ToString()))
                {
                    var status = await _sharePointService.UpdatePartnerAsync(partner);
                    if (!status)
                    {
                        return StatusCode(500, "An error occurred while creating sharepoint partner. Please try again or contact adminstrator");
                    }
                }
                _choiceRepoistory.Complete();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating Partner. Please try again or contact adminstrator");
            }
        }



    }
}
