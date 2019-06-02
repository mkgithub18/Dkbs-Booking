using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DKBS.DTO;
using DKBS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DKBS.API.Controllers
{
    /// <summary>
    /// Procedure info.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedureInfoController : Controller
    {
        private IChoiceRepository _choiceRepoistory;

        /// <summary>
        /// Procedure info.
        /// </summary>
        /// <param name="choiceRepoistory"></param>
        public ProcedureInfoController(IChoiceRepository choiceRepoistory)
        {
            _choiceRepoistory = choiceRepoistory;
        }


        /// <summary>
        /// Get procedureInfo by id
        /// </summary>
        /// <param name="procedureInfoId"></param>
        /// <returns></returns>
        [HttpGet("{procedureInfoId}")]
        public ActionResult<ProcedureInfoDTO> GetProcedureInfo(int procedureInfoId)
        {
            return _choiceRepoistory.GetProcedureInfos().FirstOrDefault(c => c.ProcedureInfoId == procedureInfoId);
        }


        /// <summary>
        /// Update procedureInfo
        /// </summary>
        /// <param name="procedureInfoId"></param>
        /// <param name="procedureInfoDTO"></param>
        /// <returns></returns>
        [HttpPut("{procedureInfoId}")]
        public IActionResult UpdateProcedureInfo(int procedureInfoId, [FromBody] ProcedureInfoDTO procedureInfoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (procedureInfoDTO == null)
                return BadRequest();

            var procedureInfo = _choiceRepoistory.GetProcedureInfos().Find(c => c.ProcedureInfoId == procedureInfoId);

            if (procedureInfo == null)
            {
                return BadRequest();
            }

            procedureInfo = procedureInfoDTO;

            _choiceRepoistory.Complete();
            return NoContent();
        }
    }
}