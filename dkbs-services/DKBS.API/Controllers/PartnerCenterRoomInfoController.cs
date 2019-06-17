using AutoMapper;
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
    /// PartnerCenterRoomInfoController
    /// </summary>
    /// 


    [Route("api/[controller]")]
    [ApiController]
    public class PartnerCenterRoomInfoController : Controller
    {
        private IChoiceRepository _choiceRepoistory;
        private IMapper _mapper;

        /// <summary>
        /// PartnerCenterRoomInfo
        /// </summary>
        /// <param name="choiceRepoistory"></param>
        public PartnerCenterRoomInfoController(IChoiceRepository choiceRepoistory)
        {
            _choiceRepoistory = choiceRepoistory;
        }

        /// <summary>
        /// Get All GetPartnerCenterRoomInfo
        /// </summary>
        /// <returns></returns>
        //[HttpGet()]
        [HttpGet("[action]/{name}", Name = "GetPartnerCenterRoomInfo")]
        public ActionResult<PartnerCenterRoomInfoDTO> GetPartnerCenterRoomInfo()
        {
            return Ok(_choiceRepoistory.GetPartnerCenterRoomInfo());
        }

        /// <summary>
        /// Get PartnerCenterRoomInfo_Id by id
        /// </summary>
        /// <param name="PartnerCenterRoomInfo_Id"></param>
        /// <returns></returns>
        [HttpGet("{PartnerCenterRoomInfo_Id}")]
        public ActionResult<PartnerCenterRoomInfoDTO> GetPartnerCenterRoomInfo(int PartnerCenterRoomInfo_Id)
        {
            return _choiceRepoistory.GetPartnerCenterRoomInfo().FirstOrDefault(c => c.PartnerCenterRoomInfoId == PartnerCenterRoomInfo_Id);
        }

        /// <summary>
        /// Get PartnerCenterRoomInfoDTO by PartnerId
        /// </summary>
        /// <param name="PartnerId"></param>
        /// <returns></returns>
        [Route("GetByPartnerId")]
        [HttpGet()]
        public ActionResult<PartnerCenterRoomInfoDTO> GetById(int PartnerId)
        {
            return _choiceRepoistory.GetPartnerCenterRoomInfo().FirstOrDefault(c => c.PartnerId == PartnerId);
        }

        /// <summary>
        /// Update UpdatePartnerCenterInfo
        /// </summary>
        /// <param name="PartnerCenterRoomInfo_Id"></param>
        /// <param name="partnerCenterRoomInfoDTO"></param>
        /// <returns></returns>

        [HttpPut("{PartnerCenterInfo_Id}")]
        public IActionResult UpdatepartnerCenterRoomInfo(int PartnerCenterRoomInfo_Id, [FromBody] PartnerCenterRoomInfoDTO partnerCenterRoomInfoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (partnerCenterRoomInfoDTO == null)
            {
                return BadRequest();
            }

            var partnerCenterRoomInfo = _choiceRepoistory.GetPartnerCenterRoomInfo().Find(c => c.PartnerCenterRoomInfoId == PartnerCenterRoomInfo_Id);

            if (partnerCenterRoomInfo == null)
            {
                return BadRequest();
            }

            partnerCenterRoomInfo = partnerCenterRoomInfoDTO;

            _choiceRepoistory.Complete();
            UpdateCRMPartnerInfoModificationdate(partnerCenterRoomInfoDTO.PartnerId);
            return NoContent();
        }

        private void UpdateCRMPartnerInfoModificationdate(int? partnerID)
        {
            var partner = _choiceRepoistory.GetById<CRMPartner>(c => c.CRMPartnerId == partnerID);
            partner.PartnerInfoModificationdate = DateTime.UtcNow;
            _choiceRepoistory.Attach(partner);
            _choiceRepoistory.Complete();
        }


        /// <summary>
        /// Creating PartnerCenterRoomInfo
        /// </summary>
        /// <param name="partnerCenterRoomInfoDTO"></param>
        /// <returns></returns>
        // GET api/PartnerCenterRoomInfo/{PartnerCenterRoomInfos}
        [HttpPost]
        public ActionResult PartnerCenterRoomInfo([FromBody] PartnerCenterRoomInfoDTO partnerCenterRoomInfoDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (partnerCenterRoomInfoDTO == null)
            {
                return BadRequest();
            }

            var checkPartnerCenterRoomInfoIdinDb = _choiceRepoistory.GetPartnerCenterRoomInfo().Find(c => c.PartnerCenterRoomInfoId == partnerCenterRoomInfoDTO.PartnerCenterRoomInfoId);

            if (checkPartnerCenterRoomInfoIdinDb != null)
            {
                return BadRequest();
            }

            PartnerCenterRoomInfo newlyCreatedPartnerCenterRoomInfo = new PartnerCenterRoomInfo()
            {
                PartnerCenterRoomInfoId = partnerCenterRoomInfoDTO.PartnerCenterRoomInfoId,
                PartnerId = partnerCenterRoomInfoDTO.PartnerId,
                MaxPersonsAtMeetingTable = partnerCenterRoomInfoDTO.MaxPersonsAtMeetingTable,
                MaxPersonsAtSchoolTable = partnerCenterRoomInfoDTO.MaxPersonsAtSchoolTable,
                MaxPersonsAtRowOfChairs = partnerCenterRoomInfoDTO.MaxPersonsAtRowOfChairs,
                MaxPersonsAtIslands = partnerCenterRoomInfoDTO.MaxPersonsAtIslands,
                MaxPersonsAtUTable = partnerCenterRoomInfoDTO.MaxPersonsAtUTable,
                IsRoomdividetosmallroom = partnerCenterRoomInfoDTO.IsRoomdividetosmallroom,
                Remark = partnerCenterRoomInfoDTO.RoomName,

                //LastModifiedBY = partnerCenterRoomInfoDTO.LastModifiedBY,
                //LastModified = partnerCenterRoomInfoDTO.LastModified
            };
          //  var destination = Mapper.Map<PartnerCenterRoomInfo, PartnerCenterRoomInfoDTO>(newlyCreatedPartnerCenterRoomInfo);


            //_choiceRepoistory.GetPartnerCenterRoomInfo().Add(destination);
            //_choiceRepoistory.Complete();

            _choiceRepoistory.SetpartnerCenterRoomInfo(newlyCreatedPartnerCenterRoomInfo);
            _choiceRepoistory.Complete();
            UpdateCRMPartnerInfoModificationdate(partnerCenterRoomInfoDTO.PartnerId);

            return CreatedAtRoute("GetPartnerCenterRoomInfo", new { name = newlyCreatedPartnerCenterRoomInfo.RoomName }, newlyCreatedPartnerCenterRoomInfo);
        }


    }

}
