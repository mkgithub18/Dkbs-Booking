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

    /// <summary>
    /// PartnerInspirationCategoriesUKController
    /// </summary>
    /// 


    [Route("api/[controller]")]
    [ApiController]
    public class PartnerInspirationCategoriesUKController : Controller
    {
        private IChoiceRepository _choiceRepoistory;

        /// <summary>
        /// PartnerCenterRoomInfo
        /// </summary>
        /// <param name="choiceRepoistory"></param>
        public PartnerInspirationCategoriesUKController(IChoiceRepository choiceRepoistory)
        {
            _choiceRepoistory = choiceRepoistory;
        }

        /// <summary>
        /// Get All GetPartnerInspirationCategoriesUK
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public ActionResult<PartnerInspirationCategoriesUK> GetPartnerInspirationCategoriesUK()
        {
            return Ok(_choiceRepoistory.GetPartnerInspirationCategoriesUK());
        }

        /// <summary>
        /// Get PartnerInspirationCategoriesUK_Id by id
        /// </summary>
        /// <param name="PartnerInspirationCategoriesUK_Id"></param>
        /// <returns></returns>
        [HttpGet("{PartnerInspirationCategoriesUK_Id}")]
        public ActionResult<PartnerInspirationCategoriesUKDTO> GetPartnerInspirationCategoriesUK(int PartnerInspirationCategoriesUK_Id)
        {
            return _choiceRepoistory.GetPartnerInspirationCategoriesUK().FirstOrDefault(c => c.PartnerInspirationCategoriesUKId == PartnerInspirationCategoriesUK_Id);
        }

        /// <summary>
        /// Get PartnerInspirationCategoriesUK_Id by PartnerId
        /// </summary>
        /// <param name="PartnerId"></param>
        /// <returns></returns>
        [Route("GetByPartnerId")]
        [HttpGet()]
        public ActionResult<PartnerInspirationCategoriesUKDTO> GetById(int PartnerId)
        {
            return _choiceRepoistory.GetPartnerInspirationCategoriesUK().FirstOrDefault(c => c.PartnerId == PartnerId);
        }


        /// <summary>y
        /// Update UpdatePartnerCenterInfo
        /// </summary>
        /// <param name="PartnerInspirationCategoriesUK_Id"></param>
        /// <param name="PartnerInspirationCategoriesUKDTO"></param>
        /// <returns></returns>

        [HttpPut("{PartnerInspirationCategoriesUK_Id}")]
        public IActionResult UpdatepartnerCenterRoomInfo(int PartnerInspirationCategoriesUK_Id, [FromBody] PartnerInspirationCategoriesUKDTO PartnerInspirationCategoriesUKDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (PartnerInspirationCategoriesUKDTO == null)
            {
                return BadRequest();
            }

            var PartnerInspirationCategoriesUK = _choiceRepoistory.GetPartnerInspirationCategoriesUK().Find(c => c.PartnerInspirationCategoriesUKId == PartnerInspirationCategoriesUK_Id);

            if (PartnerInspirationCategoriesUK == null)
            {
                return BadRequest();
            }

            PartnerInspirationCategoriesUK = PartnerInspirationCategoriesUKDTO;

            _choiceRepoistory.Complete();
            UpdateCRMPartnerInfoModificationdate(PartnerInspirationCategoriesUKDTO.PartnerId);
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
        /// <param name="PartnerInspirationCategoriesUKDTO"></param>
        /// <returns></returns>
        // GET api/PartnerInspirationCategoriesUK/{PartnerInspirationCategoriesUK}
        [HttpPost]
        public ActionResult<IEnumerable<PartnerInspirationCategoriesUKDTO>> PartnerInspirationCategoriesUK([FromBody] PartnerInspirationCategoriesUKDTO PartnerInspirationCategoriesUKDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (PartnerInspirationCategoriesUKDTO == null)
            {
                return BadRequest();
            }

            var checkPartnerCenterRoomInfoIdinDb = _choiceRepoistory.GetPartnerInspirationCategoriesUK().Find(c => c.PartnerInspirationCategoriesUKId == PartnerInspirationCategoriesUKDTO.PartnerInspirationCategoriesUKId);

            if (checkPartnerCenterRoomInfoIdinDb != null)
            {
                return BadRequest();
            }

            PartnerInspirationCategoriesUK newlyPartnerInspirationCategoriesUKDTO = new PartnerInspirationCategoriesUK()
            {
                PartnerInspirationCategoriesUKId = PartnerInspirationCategoriesUKDTO.PartnerInspirationCategoriesUKId,
                PartnerId = PartnerInspirationCategoriesUKDTO.PartnerId,
                // Room_Name = PartnerInspirationCategoriesUKDTO.Room_Name,
                Heading = PartnerInspirationCategoriesUKDTO.Heading,
                Description = PartnerInspirationCategoriesUKDTO.Description,
                Price = PartnerInspirationCategoriesUKDTO.Price,
                ApprovalStatus = PartnerInspirationCategoriesUKDTO.ApprovalStatus,
                //LastModifiedBY = partnerCenterRoomInfoDTO.LastModifiedBY,
                //LastModified = partnerCenterRoomInfoDTO.LastModified
            };
            //  var destination = Mapper.Map<PartnerCenterRoomInfo, PartnerCenterRoomInfoDTO>(newlyCreatedPartnerCenterRoomInfo);


            //_choiceRepoistory.GetPartnerCenterRoomInfo().Add(destination);
            //_choiceRepoistory.Complete();

            _choiceRepoistory.SetpartnerInspirationCategoriesUK(newlyPartnerInspirationCategoriesUKDTO);
            _choiceRepoistory.Complete();
            UpdateCRMPartnerInfoModificationdate(PartnerInspirationCategoriesUKDTO.PartnerId);
            return CreatedAtRoute("GetPartnerInspirationCategoriesUK", new { name = newlyPartnerInspirationCategoriesUKDTO.Heading }, newlyPartnerInspirationCategoriesUKDTO);
        }

    }
}
