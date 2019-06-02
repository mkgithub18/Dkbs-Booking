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
    /// Procedure
    /// </summary>   
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedureController : Controller
    {

        private IChoiceRepository _choiceRepoistory;

        /// <summary>
        /// Procedure
        /// </summary>
        /// <param name="choiceRepoistory"></param>
        public ProcedureController(IChoiceRepository choiceRepoistory)
        {
            _choiceRepoistory = choiceRepoistory;
        }

        /// <summary>
        /// Get All Procedures
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public ActionResult<ProcedureDTO> GetProcedures()
        {
            return Ok(_choiceRepoistory.GetProcedures());
        }

        /// <summary>
        /// Get procedure by id
        /// </summary>
        /// <param name="procedureId"></param>
        /// <returns></returns>
        [HttpGet("{procedureId}")]
        public ActionResult<ProcedureDTO> GetProcedureById(int procedureId)
        {
            return _choiceRepoistory.GetProcedures().FirstOrDefault(c => c.ProcedureId == procedureId);
        }


        /// <summary>
        /// Update procedure
        /// </summary>
        /// <param name="procedureId"></param>
        /// <param name="procedureDTO"></param>
        /// <returns></returns>
        [HttpPut("{procedureId}")]
        public IActionResult UpdateProcedure(int procedureId, [FromBody] ProcedureDTO procedureDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (procedureDTO == null)
                return BadRequest();

            var procedure = _choiceRepoistory.GetProcedures().Find(c => c.ProcedureId == procedureId);

            if (procedure == null)
            {
                return BadRequest();
            }

            procedure = procedureDTO;

            _choiceRepoistory.Complete();
            return NoContent();
        }
    }
}