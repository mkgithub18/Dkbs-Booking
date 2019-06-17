using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DKBS.Domain;
using DKBS.DTO;
using DKBS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DKBS.API.Controllers
{
    /// <summary>
    /// Provision
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class ProvisionController : Controller
    {
        private IChoiceRepository _choiceRepoistory;

        /// <summary>
        /// Provision
        /// </summary>
        /// <param name="choiceRepoistory"></param>
        public ProvisionController(IChoiceRepository choiceRepoistory)
        {
            _choiceRepoistory = choiceRepoistory;
        }

        /// <summary>
        /// Get All Provisions
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public ActionResult<ProvisionDTO> GetProvisions()
        {
            return Ok(_choiceRepoistory.GetProvisions());
        }

        /// <summary>
        /// Get provision by id
        /// </summary>
        /// <param name="provisionId"></param>
        /// <returns></returns>
        [HttpGet("{provisionId}")]
        public ActionResult<ProvisionDTO> GetProvision(int provisionId)
        {
            return _choiceRepoistory.GetProvisions().FirstOrDefault(c => c.ProvisionId == provisionId);
        }

        /// <summary>
        /// Get ProvisionDTO by BookingId
        /// </summary>
        /// <param name="BookingId"></param>
        /// <returns></returns>
        [Route("GettProvisionByBookingId")]
        [HttpGet()]
        public ActionResult<ProvisionDTO> GetById(int BookingId)
        {
            return _choiceRepoistory.GetProvisions().FirstOrDefault(c => c.BookingId == BookingId);
        }


        /// <summary>
        /// Get ProvisionDTO by BookingId
        /// </summary>
        /// <param name="BookingId"></param>
        /// <returns></returns>
        [Route("GetByMultiId")]
        [HttpGet()]
        public ActionResult<ProvisionDTO> GetByMultiId(int BookingId)
        {

            //string idChecked = "1,2,3,4,5";
            ////Split the string to an array
            //string[] ids = idChecked.Split(',');
            //var blog = _choiceRepoistory.GetProvisions().Where(x =>x.BookingId);

            return _choiceRepoistory.GetProvisions().FirstOrDefault(c => c.BookingId == BookingId);
        }

        /// <summary>
        /// Update provision
        /// </summary>
        /// <param name="provisionId"></param>
        /// <param name="provisionDTO"></param>
        /// <returns></returns>

        [HttpPut("{provisionId}")]
        public IActionResult UpdateProvision(int provisionId, [FromBody] ProvisionDTO provisionDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (provisionDTO == null)
                return BadRequest();

            var provision = _choiceRepoistory.GetProvisions().Find(c => c.ProvisionId == provisionId);

            if (provision == null)
            {
                return BadRequest();
            }

            provision = provisionDTO;

            _choiceRepoistory.Complete();
            return NoContent();
        }



        /// <summary>
        /// Creating Provision
        /// </summary>
        /// <param name="provisionDTO"></param>
        /// <returns></returns>
        // GET api/Provision/{Provision}
        [HttpPost]
        public ActionResult<IEnumerable<ProvisionDTO>> Provision([FromBody] ProvisionDTO provisionDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (provisionDTO == null)
            {
                return BadRequest();
            }

            var checkProvisiondinDb = _choiceRepoistory.GetProvisions().Find(c => c.ProvisionId == provisionDTO.ProvisionId);

            if (checkProvisiondinDb != null)
            {
                return BadRequest();
            }

            Provision newlyProvision = new Provision()
            {               
                ProvisionId = provisionDTO.ProvisionId,
                PartnerId = provisionDTO.PartnerId,
                CustomerId = provisionDTO.CustomerId,
                BookingId = provisionDTO.BookingId,
                Price = provisionDTO.Price,
                CreatedOn = System.DateTime.Now,
                DateofShipment = provisionDTO.DateofShipment,
                Debtor = provisionDTO.Debtor,
                ProvisionName = provisionDTO.ProvisionName,
                UnitID = provisionDTO.UnitID,
                CreatedBy = provisionDTO.CreatedBy,
                ProvisionSpID = provisionDTO.ProvisionSpID,
                LastModified = provisionDTO.LastModified,
                LastModifiedBy = provisionDTO.LastModifiedBy,       

            };
            
            _choiceRepoistory.SetProvision(newlyProvision);
            _choiceRepoistory.Complete();

            return CreatedAtRoute("GetProvisions", new { name = newlyProvision.ProvisionName }, newlyProvision);
        }

    }
}