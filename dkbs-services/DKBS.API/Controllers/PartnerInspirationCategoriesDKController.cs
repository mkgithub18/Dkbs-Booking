using DKBS.Domain;
using DKBS.DTO;
using DKBS.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DKBS.API.Controllers
{
    //public class PartnerInspirationCategoriesDKController
    //{
    //}


    /// <summary>
    /// PartnerInspirationCategoriesController
    /// </summary>
    /// 


    [Route("api/[controller]")]
    [ApiController]
    public class PartnerInspirationCategoriesDKController : Controller
    {
        private IChoiceRepository _choiceRepoistory;

        /// <summary>
        /// PartnerCenterRoomInfo
        /// </summary>
        /// <param name="choiceRepoistory"></param>
        public PartnerInspirationCategoriesDKController(IChoiceRepository choiceRepoistory)
        {
            _choiceRepoistory = choiceRepoistory;
        }

        /// <summary>
        /// Get All GetPartnerCenterRoomInfo
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public ActionResult<PartnerInspirationCategoriesDK> GetPartnerInspirationCategoriesDK()
        {
            return Ok(_choiceRepoistory.GetPartnerInspirationCategoriesDK());
        }

        /// <summary>
        /// Get PartnerInspirationCategories_Id by id
        /// </summary>
        /// <param name="PartnerInspirationCategoriesDK_Id"></param>
        /// <returns></returns>
        [HttpGet("{PartnerInspirationCategoriesDK_Id}")]
        public ActionResult<PartnerInspirationCategoriesDKDTO> GetPartnerInspirationCategoriesDK(int PartnerInspirationCategoriesDK_Id)
        {
            return _choiceRepoistory.GetPartnerInspirationCategoriesDK().FirstOrDefault(c => c.PartnerInspirationCategoriesDKId == PartnerInspirationCategoriesDK_Id);
        }

        /// <summary>
        /// Get PartnerInspirationCategoriesDK_Id by PartnerId
        /// </summary>
        /// <param name="PartnerId"></param>
        /// <returns></returns>
        [Route("GetByPartnerId")]
        [HttpGet()]
        public ActionResult<PartnerInspirationCategoriesDKDTO> GetById(int PartnerId)
        {
            return _choiceRepoistory.GetPartnerInspirationCategoriesDK().FirstOrDefault(c => c.PartnerId == PartnerId);
        }


        /// <summary>y
        /// Update UpdatePartnerCenterInfo
        /// </summary>
        /// <param name="PartnerInspirationCategoriesDK_Id"></param>
        /// <param name="PartnerInspirationCategoriesDKDTO"></param>
        /// <returns></returns>

        [HttpPut("{PartnerInspirationCategoriesDK_Id}")]
        public IActionResult UpdatePartnerInspirationCategoriesDK(int PartnerInspirationCategoriesDK_Id, [FromBody] PartnerInspirationCategoriesDKDTO PartnerInspirationCategoriesDKDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (PartnerInspirationCategoriesDKDTO == null)
            {
                return BadRequest();
            }

            var partnerInspirationCategoriesDK = _choiceRepoistory.GetPartnerInspirationCategoriesDK().Find(c => c.PartnerInspirationCategoriesDKId == PartnerInspirationCategoriesDK_Id);

            if (partnerInspirationCategoriesDK == null)
            {
                return BadRequest();
            }

            partnerInspirationCategoriesDK = PartnerInspirationCategoriesDKDTO;

            _choiceRepoistory.Complete();
            UpdateCRMPartnerInfoModificationdate(PartnerInspirationCategoriesDKDTO.PartnerId);
            return NoContent();
        }

        private void UpdateCRMPartnerInfoModificationdate(int partnerID)
        {
            var partner = _choiceRepoistory.GetById<CRMPartner>(c => c.CRMPartnerId == partnerID);
            partner.PartnerInfoModificationdate = DateTime.UtcNow;
            _choiceRepoistory.Attach(partner);
            _choiceRepoistory.Complete();
        }


        /// <summary>
        /// Creating PartnerCenterRoomInfo
        /// </summary>
        /// <param name="PartnerInspirationCategoriesDKDTO"></param>
        /// <returns></returns>
        // GET api/PartnerInspirationCategories/{PartnerInspirationCategories}
        [HttpPost]
        public ActionResult<IEnumerable<PartnerInspirationCategoriesDKDTO>> PartnerInspirationCategoriesDK([FromBody] PartnerInspirationCategoriesDKDTO PartnerInspirationCategoriesDKDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (PartnerInspirationCategoriesDKDTO == null)
            {
                return BadRequest();
            }

            var checkPartnerInspirationCategoriesDK_Id = _choiceRepoistory.GetPartnerInspirationCategoriesDK().Find(c => c.PartnerInspirationCategoriesDKId == PartnerInspirationCategoriesDKDTO.PartnerInspirationCategoriesDKId);

            if (checkPartnerInspirationCategoriesDK_Id != null)
            {
                return BadRequest();
            }

            PartnerInspirationCategoriesDK newlypartnerInspirationCategoriesDKDTO = new PartnerInspirationCategoriesDK()
            {
                PartnerInspirationCategoriesDKId = checkPartnerInspirationCategoriesDK_Id.PartnerInspirationCategoriesDKId,
                PartnerId = checkPartnerInspirationCategoriesDK_Id.PartnerId,
                // Room_Name = partnerInspirationCategoriesDTO.Room_Name,
                Heading = checkPartnerInspirationCategoriesDK_Id.Heading,
                Description = checkPartnerInspirationCategoriesDK_Id.Description,
                Price = checkPartnerInspirationCategoriesDK_Id.Price,
                ApprovalStatus = checkPartnerInspirationCategoriesDK_Id.ApprovalStatus,
                //LastModifiedBY = partnerCenterRoomInfoDTO.LastModifiedBY,
                //LastModified = partnerCenterRoomInfoDTO.LastModified
            };
            //  var destination = Mapper.Map<PartnerCenterRoomInfo, PartnerCenterRoomInfoDTO>(newlyCreatedPartnerCenterRoomInfo);


            //_choiceRepoistory.GetPartnerCenterRoomInfo().Add(destination);
            //_choiceRepoistory.Complete();

            _choiceRepoistory.SetpartnerInspirationCategoriesDK(newlypartnerInspirationCategoriesDKDTO);
            _choiceRepoistory.Complete();
            UpdateCRMPartnerInfoModificationdate(PartnerInspirationCategoriesDKDTO.PartnerId);
            return CreatedAtRoute("GetPartnerCenterRoomInfo", new { name = newlypartnerInspirationCategoriesDKDTO.Heading }, newlypartnerInspirationCategoriesDKDTO);
        }

    }
}
