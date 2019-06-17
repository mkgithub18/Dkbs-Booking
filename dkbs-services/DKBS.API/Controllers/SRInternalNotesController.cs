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
    public class SRInternalNotesController : Controller
    {
        private IChoiceRepository _choiceRepoistory;

        /// <summary>
        /// PartnerCenterInfo_Id
        /// </summary>
        /// <param name="choiceRepoistory"></param>
        public SRInternalNotesController(IChoiceRepository choiceRepoistory)
        {
            _choiceRepoistory = choiceRepoistory;
        }

        /// <summary>
        /// Get All GetSRInternalNotes
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public ActionResult<SRInternalNotesDTO> GetSRInternalNotes()
        {
            return Ok(_choiceRepoistory.GetSRInternalNotes());
        }


        /// <summary>
        /// Get GetById by CRMPartnerId
        /// </summary>
        /// <param name="BookingID"></param>
        /// <returns></returns> 
        [Route("BookingID")]
        [HttpGet()]
        public ActionResult<SRInternalNotesDTO> GetById(string BookingID)
        {
            return _choiceRepoistory.GetSRInternalNotes().FirstOrDefault(c => c.BookingID == BookingID);
        }

        /// <summary>
        /// Update UpdatePartnerCenterInfo
        /// </summary>
        /// <param name="InternalNote_ID"></param>
        /// <param name="sRInternalNotesDTO"></param>
        /// <returns></returns>


        [HttpPut()]
        [Route("UpdatesRInternalNotes/{EmailConversationID:int}")]
        public IActionResult UpdatesRInternalNotes(int InternalNote_ID, [FromBody] SRInternalNotesDTO sRInternalNotesDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (sRInternalNotesDTO == null)
            {
                return BadRequest();
            }

            var SRInternalNotes = _choiceRepoistory.GetSRInternalNotes().Find(c => c.InternalNoteID == InternalNote_ID);

            if (SRInternalNotes == null)
            {
                return BadRequest();
            }

            SRInternalNotes = sRInternalNotesDTO;

            _choiceRepoistory.Complete();
            return NoContent();
        }


        /// <summary>
        /// Creating SRInternalNotes
        /// </summary>
        /// <param name="sRInternalNotesDTO"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult SRInternalNotes([FromBody] SRInternalNotesDTO sRInternalNotesDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (sRInternalNotesDTO == null)
            {
                return BadRequest();
            }

            var checkSRInternalNotesIdinDb = _choiceRepoistory.GetSRInternalNotes().Find(c => c.InternalNoteID == sRInternalNotesDTO.InternalNoteID);

            if (checkSRInternalNotesIdinDb != null)
            {
                return BadRequest();
            }

            SRInternalNotes newlySRInternalNotes = new SRInternalNotes()
            {
                InternalNoteID = sRInternalNotesDTO.InternalNoteID,
                InternalNoteName = sRInternalNotesDTO.InternalNoteName,
                BookingID = sRInternalNotesDTO.BookingID,
                Notes = sRInternalNotesDTO.Notes,
                InternalNoteNotify = sRInternalNotesDTO.InternalNoteNotify,
                ScheduleAction = sRInternalNotesDTO.ScheduleAction,
                CopyToCloseRemark = sRInternalNotesDTO.CopyToCloseRemark,
                PlannedStart = sRInternalNotesDTO.PlannedStart,
                PlannedEnd = sRInternalNotesDTO.PlannedEnd,
                toMessage = sRInternalNotesDTO.toMessage,
                CreatedDate = sRInternalNotesDTO.CreatedDate,
                CreatedBy = sRInternalNotesDTO.CreatedBy,
                LastModified = sRInternalNotesDTO.LastModified,
                LastModifiedBY = sRInternalNotesDTO.LastModifiedBY,
                SharepointID = sRInternalNotesDTO.SharepointID,
            };         
            _choiceRepoistory.SetSRInternalNotes(newlySRInternalNotes);
            _choiceRepoistory.Complete();
            return CreatedAtRoute("GetSRInternalNotes", new { name = newlySRInternalNotes.InternalNoteName }, newlySRInternalNotes);
        }


    }
}


