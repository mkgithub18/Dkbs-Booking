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
    /// EmailConversationController
    /// </summary>
    /// 

    [Route("api/[controller]")]
    [ApiController]
    public class EmailConversationController : Controller
    {
        private IChoiceRepository _choiceRepoistory;

        /// <summary>
        /// PartnerCenterInfo_Id
        /// </summary>
        /// <param name="choiceRepoistory"></param>
        public EmailConversationController(IChoiceRepository choiceRepoistory)
        {
            _choiceRepoistory = choiceRepoistory;
        }

        /// <summary>
        /// Get All PartnerCenterInfo
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public ActionResult<EmailConversationDTO> GetEmailConversation()
        {
            return Ok(_choiceRepoistory.GetEmailConversation());
        }


        /// <summary>
        /// Get PartnerCenterInfo_Id by CRMPartnerId
        /// </summary>
        /// <param name="BookingID"></param>
        /// <returns></returns> 
        [Route("BookingID")]
        [HttpGet()]
        public ActionResult<EmailConversationDTO> GetById(string BookingID)
        {
            return _choiceRepoistory.GetEmailConversation().FirstOrDefault(c => c.Booking_ID == BookingID);
        }

        /// <summary>
        /// Update UpdatePartnerCenterInfo
        /// </summary>
        /// <param name="EmailConversationID"></param>
        /// <param name="emailConversationDTO"></param>
        /// <returns></returns>


        [HttpPut()]
        [Route("UpdateEmailConversation/{EmailConversationID:int}")]
        public IActionResult UpdateEmailConversation(int EmailConversationID, [FromBody] EmailConversationDTO emailConversationDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (emailConversationDTO == null)
            {
                return BadRequest();
            }

            var EmailConversation = _choiceRepoistory.GetEmailConversation().Find(c => c.EmailConversationID == EmailConversationID);

            if (EmailConversation == null)
            {
                return BadRequest();
            }

            EmailConversation = emailConversationDTO;

            _choiceRepoistory.Complete();
            return NoContent();
        }

        /// <summary>
        /// Creating emailConversationDTO
        /// </summary>
        /// <param name="emailConversationDTO"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult EmailConversation([FromBody] EmailConversationDTO emailConversationDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (emailConversationDTO == null)
            {
                return BadRequest();
            }

            var checkEmailConversationIdinDb = _choiceRepoistory.GetEmailConversation().Find(c => c.EmailConversationID == emailConversationDTO.EmailConversationID);

            if (checkEmailConversationIdinDb != null)
            {
                return BadRequest();
            }

            EmailConversation newlyEmailConversation = new EmailConversation()
            {
                CRMPartnerId = emailConversationDTO.CRMPartnerId,
                EmailTitle = emailConversationDTO.EmailTitle,
                Message = emailConversationDTO.Message,
                Sender = emailConversationDTO.Sender,
                CC_adresses = emailConversationDTO.CC_adresses,
                Booking_ID = emailConversationDTO.Booking_ID,
                Message_id = emailConversationDTO.Message_id,
                to_Message = emailConversationDTO.to_Message,
                CreatedDate = emailConversationDTO.CreatedDate,
                CreatedBy = emailConversationDTO.CreatedBy,
                LastModified = emailConversationDTO.LastModified,
                LastModifiedBY = emailConversationDTO.LastModifiedBY,
                Sharepoint_ID = emailConversationDTO.Sharepoint_ID,                
            };
            //  var destination = Mapper.Map<PartnerCenterRoomInfo, PartnerCenterRoomInfoDTO>(newlyCreatedPartnerCenterRoomInfo);


            //_choiceRepoistory.GetPartnerCenterRoomInfo().Add(destination);
            //_choiceRepoistory.Complete();

            _choiceRepoistory.SetEmailConversation(newlyEmailConversation);
            _choiceRepoistory.Complete();

            return CreatedAtRoute("GetEmailConversation", new { name = newlyEmailConversation.EmailTitle }, newlyEmailConversation);
        }

    }
}
