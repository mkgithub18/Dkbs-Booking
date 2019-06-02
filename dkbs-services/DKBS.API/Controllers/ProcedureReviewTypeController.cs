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
    /// Provision review type.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedureReviewTypeController : Controller
    {

        private IChoiceRepository _choiceRepoistory;

        /// <summary>
        /// Provision review type.
        /// </summary>
        /// <param name="choiceRepoistory"></param>
        public ProcedureReviewTypeController(IChoiceRepository choiceRepoistory)
        {
            _choiceRepoistory = choiceRepoistory;
        }

        /// <summary>
        /// Get All ProcedureReviewTypes
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public ActionResult<ProcedureReviewTypeDTO> GetProcedureReviewTypes()
        {
            return Ok(_choiceRepoistory.GetProcedureReviewTypes());
        }

        /// <summary>
        /// Get procedure reviewType by Id
        /// </summary>
        /// <param name="procedureReviewTypeId"></param>
        /// <returns></returns>
        [HttpGet("{procedureReviewTypeId}")]
        public ActionResult<ProcedureReviewTypeDTO> GetProcedureInfo(int procedureReviewTypeId)
        {
            return _choiceRepoistory.GetProcedureReviewTypes().FirstOrDefault(c => c.ProcedureReviewTypeId == procedureReviewTypeId);
        }


        /// <summary>
        /// Update procedure info
        /// </summary>
        /// <param name="procedureReviewTypeId"></param>
        /// <param name="procedureReviewTypeDTO"></param>
        /// <returns></returns>
        [HttpPut("{procedureReviewTypeId}")]
        public IActionResult UpdateProcedureInfo(int procedureReviewTypeId, [FromBody] ProcedureReviewTypeDTO procedureReviewTypeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (procedureReviewTypeDTO == null)
                return BadRequest();

            var procedureReviewType = _choiceRepoistory.GetProcedureReviewTypes().Find(c => c.ProcedureReviewTypeId == procedureReviewTypeId);

            if (procedureReviewType == null)
            {
                return BadRequest();
            }

            procedureReviewType = procedureReviewTypeDTO;

            _choiceRepoistory.Complete();
            return NoContent();
        }


    }
}