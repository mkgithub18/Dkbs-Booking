using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DKBS.Domain;
using DKBS.DTO;
using DKBS.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        private IMapper _mapper;
        /// <summary>
        /// Partner controller
        /// </summary>
        public PartnerController(IChoiceRepository choiceReposiroty, IMapper mapper)
        {
            _choiceRepoistory = choiceReposiroty;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All partner details.
        /// </summary>
        /// <returns>List of partners.</returns>
        [HttpGet()]
        public ActionResult<CRMPartnerDTO> GetPartners()
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
        /// Get  Website Partner List.
        /// </summary>
        /// <param name="LastModified"></param>
        /// <returns>Website Partner List</returns>
        ///

        [HttpGet("GetWebsitePartnerList")]
        public ActionResult<List<GetWebsitePartnerListDTO>> GetWebsitePartner()
        {
            var partnerList = _choiceRepoistory.GetWebsitePartners().FindAll(c => c.LastModified.Date == DateTime.Now.Date);
            return partnerList;
        }

        /// <summary>
        /// Get Partner Details .
        /// </summary>
        /// <param name="LastModified"></param>
        /// <returns> Partner Details</returns>
        ///

       
       // [Authorize]
        [HttpPost("")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult CreatePartner([FromBody] CRMPartnerDTO dto)
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
                newPartner.PartnerInfoModificationdate = DateTime.UtcNow;
                _choiceRepoistory.Attach<CRMPartner>(newPartner);
                _choiceRepoistory.Complete();

                AddNewServiceCatalog(newPartner.CRMPartnerId);
                AddNewPartnerCenterInfo(newPartner.CRMPartnerId);

                return CreatedAtRoute("GetPartnerByAccountId", new { newPartner.AccountId }, dto);
            }
            catch (Exception ex)
            {
                // TODO : Add logging and decide on showing ex.message
                return StatusCode(500, "An error occurred while creating partner. Please try again or contact adminstrator");
            }
        }

        private void AddNewPartnerCenterInfo(int PartnerId)
        {
            PartnerCenterInfo newPartnerCenterInfo = new PartnerCenterInfo
            {
                PartnerId = PartnerId,
                Total_Rooms = 0,
                Group_Rooms = 0,
                Max_space_at_row_of_chairs = string.Empty,
                Maxspace_at_tables = string.Empty,
                State_agreement = false,
                MaxAccommodation = string.Empty,
                PartnerCenfoInfoSPId = string.Empty,
                NumberOfSingleRooms = 0,
                NumberOfDoubleRooms = 0,
                Suite = 0,
                DistanceToAddtiionalAccommodation = 0,
                Chamber = 0,
                HandicapRooms = 0,
                MaximumNumberOfVisitors = 0,
                MaxDiningPlacesInRestaurant = 0,
                MaxDiningPlacesInRoom = 0,
                MaxSpaceInAuditorium = 0,
                MinParticipants = 0,
                AirportDistance = 0,
                StationDdistance = 0,
                DistanceToBus = 0,
                DistanceToMotorway = 0,
                NumberOfFreeParkingSpaces = 0,
                DistanceToFreeParking = 0,
                NumberOfParkingSpaces = 0,
                DistanceToPayParking = 0,
                EnvironmentalCertificate = false,
                AgreementForEmployees = true,
                Handicapfriendly = true,
                RegionsAgreement = false,
                Bar = true,
                Lounge = true,
                Spa = false,
                Pool = true,
                FitnessRoom = false,
                Casino = false,
                DiningArea = 0,
                GreenArea = false,
                Golf = false,
                AirCondition = true,
                CookingSchool = false,
                NoOfRooms = 0,
                Auditoriums = 0,
                ApprovalStatus = false,
                CreatedDate = DateTime.UtcNow,
                CreatedBy = "CRM",
                LastModified = DateTime.UtcNow,
                LastModifiedBY = "CRM"
                

            };

            _choiceRepoistory.Attach<PartnerCenterInfo>(newPartnerCenterInfo);
            _choiceRepoistory.Complete();

        }

        private void AddNewServiceCatalog(int PartnerId)
        {
            var serviceCatalogueList = _choiceRepoistory.GetServiceCatalog();

            foreach (var serviceCatalogue in serviceCatalogueList)
            {
                PartnerCoursePackages newPartnerCoursePackages = new PartnerCoursePackages
                {
                    ServiceCatalogueID = serviceCatalogue.ServiceCatalogueID,
                    PartnerID = PartnerId,
                    Offered = false,
                    Price = serviceCatalogue.Price.HasValue ? serviceCatalogue.Price.Value : 0,
                    ModifiedDate = DateTime.UtcNow,
                    CreatedDate = DateTime.UtcNow
                };
                _choiceRepoistory.Attach<PartnerCoursePackages>(newPartnerCoursePackages);
                _choiceRepoistory.Complete();
                AddNewPartnerCoursePackageMenue(serviceCatalogue.CoursePackageMenueList, PartnerId, serviceCatalogue.ServiceCatalogueID);
            }

        }

        private void AddNewPartnerCoursePackageMenue(List<CoursePackageMenueDTO> coursePackageMenueList, int PartnerId, int serviceCatalogueID)
        {
            foreach (var coursePackageMenue in coursePackageMenueList)
            {
                PartnerCoursePackageMenue newPartnerCoursePackageMenue = new PartnerCoursePackageMenue
                {
                    ServiceCatalogueID = serviceCatalogueID,
                    PartnerID = PartnerId,
                    CoursePackageMenueID = coursePackageMenue.CoursePackageMenueID,
                    ModifiedDate = DateTime.UtcNow,
                    CreatedDate = DateTime.UtcNow
                };
                _choiceRepoistory.Attach<PartnerCoursePackageMenue>(newPartnerCoursePackageMenue);
                _choiceRepoistory.Complete();
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
        //[Authorize]
        [HttpPut("{accountId}")]
        public IActionResult UpdatePartner(string accountId, [FromBody] CRMPartnerDTO dto)
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
                partner.LastModifiedBy = "CRM";  
                partner.PartnerInfoModificationdate = DateTime.UtcNow;
                _choiceRepoistory.Attach(partner);
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
