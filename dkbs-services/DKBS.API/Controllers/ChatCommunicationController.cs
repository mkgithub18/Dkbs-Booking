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
    /// ChatCommunicationController
    /// </summary>
    /// 

    [Route("api/[controller]")]
    [ApiController]
    public class ChatCommunicationController : Controller
    {
        private IChoiceRepository _choiceRepoistory;

        /// <summary>
        /// PartnerCenterInfo_Id
        /// </summary>
        /// <param name="choiceRepoistory"></param>
        public ChatCommunicationController(IChoiceRepository choiceRepoistory)
        {
            _choiceRepoistory = choiceRepoistory;
        }

        /// <summary>
        /// Get All ChatCommunication
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public ActionResult<ChatCommunicationDTO> GetChatCommunication()
        {
            return Ok(_choiceRepoistory.GetChatCommunication());
        }


        /// <summary>
        /// Get GetById by PartnerId
        /// </summary>
        /// <param name="BookingID"></param>
        /// <returns></returns> 
        [Route("BookingID")]
        [HttpGet()]
        public ActionResult<ChatCommunicationDTO> GetById(string BookingID)
        {
            return _choiceRepoistory.GetChatCommunication().FirstOrDefault(c => c.Booking_ID == BookingID);
        }


        /// <summary>
        /// Get GetById by PartnerId
        /// </summary>
        /// <param name="Procedure_ID"></param>
        /// <returns></returns> 
        [Route("GetByProvisionID")]
        [HttpGet()]
        public ActionResult<ChatCommunicationDTO> GetByProvisionID(string Procedure_ID)
        {
            return _choiceRepoistory.GetChatCommunication().FirstOrDefault(c => c.Procedure_ID == Procedure_ID);
        }

        /// <summary>
        /// Update UpdatesRInternalNotes
        /// </summary>
        /// <param name="Chat_ID"></param>
        /// <param name="chatCommunicationDTO"></param>
        /// <returns></returns>


        [HttpPut()]
        [Route("UpdatesRInternalNotes/{EmailConversationID:int}")]
        public IActionResult UpdateschatCommunication(int Chat_ID, [FromBody] ChatCommunicationDTO chatCommunicationDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (chatCommunicationDTO == null)
                return BadRequest();

            var ChatCommunication = _choiceRepoistory.GetChatCommunication().Find(c => c.Chat_ID == Chat_ID);

            if (ChatCommunication == null)
            {
                return BadRequest();
            }

            ChatCommunication = chatCommunicationDTO;

            _choiceRepoistory.Complete();
            return NoContent();
        }


        /// <summary>
        /// Creating SRInternalNotes
        /// </summary>
        /// <param name="chatCommunicationDTO"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult ChatCommunication([FromBody] ChatCommunicationDTO chatCommunicationDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (chatCommunicationDTO == null)
            {
                return BadRequest();
            }

            var checkSRInternalNotesIdinDb = _choiceRepoistory.GetChatCommunication().Find(c => c.Chat_ID == chatCommunicationDTO.Chat_ID);

            if (checkSRInternalNotesIdinDb != null)
            {
                return BadRequest();
            }

            ChatCommunication newlyChatCommunication = new ChatCommunication()
            {
                Chat_ID = chatCommunicationDTO.Chat_ID,
                ChatTitle = chatCommunicationDTO.ChatTitle,
                Booking_ID = chatCommunicationDTO.Booking_ID,
                Communications = chatCommunicationDTO.Communications,
                From_MyIT = chatCommunicationDTO.From_MyIT,
                Copy_to_close_remark = chatCommunicationDTO.Copy_to_close_remark,
                Procedure_ID = chatCommunicationDTO.Procedure_ID,
                IsPartnerSideCommunication = chatCommunicationDTO.IsPartnerSideCommunication,
                Procedure_info_communication = chatCommunicationDTO.Procedure_info_communication,
                Message_id = chatCommunicationDTO.Message_id,
                to_Message = chatCommunicationDTO.to_Message,
                CreatedDate = chatCommunicationDTO.CreatedDate,
                CreatedBy = chatCommunicationDTO.CreatedBy,
                LastModified = chatCommunicationDTO.LastModified,
                LastModifiedBY = chatCommunicationDTO.LastModifiedBY,
                Sharepoint_ID = chatCommunicationDTO.Sharepoint_ID
            };
            _choiceRepoistory.SetChatCommunication(newlyChatCommunication);
            _choiceRepoistory.Complete();
            return CreatedAtRoute("GetChatCommunication", new { name = newlyChatCommunication.ChatTitle }, newlyChatCommunication);
        }

    }
}



