using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DKBS.Domain;
using DKBS.DTO;
using DKBS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DKBS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerCenterDescriptionController : ControllerBase
    {
        private readonly IChoiceRepository _choiceRepoistory;
        private IMapper _mapper;
        public PartnerCenterDescriptionController(IChoiceRepository choiceReposiroty, IMapper mapper)
        {
            _choiceRepoistory = choiceReposiroty;
            _mapper = mapper;
        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult<PartnerCenterDescriptionDTO> GetPartnerCenterDescription()
        {
            return Ok(_choiceRepoistory.GetPartnerCenterDescriptions());
        }

        // GET api/<controller>/5
        [HttpGet("{partnerCenterDescriptionId}")]
        public ActionResult<PartnerCenterDescriptionDTO> GetPartnerCenterDescriptionId(int partnerCenterDescriptionId)
        {
            return _choiceRepoistory.GetPartnerCenterDescriptions().FirstOrDefault(c => c.PartnerCenterDescription_Id == partnerCenterDescriptionId);
        }

        // POST api/<controller>

        [HttpPost]
        public ActionResult<IEnumerable<PartnerCenterDescriptionDTO>> CreatePartnerCenterDescription([FromBody] PartnerCenterDescriptionDTO partnerCenterDescriptionDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (partnerCenterDescriptionDto == null)
                return BadRequest();


            var checkPartnerIdinDb = _choiceRepoistory.GetPartnerCenterDescriptions().Find(c => c.PartnerCenterDescription_Id == partnerCenterDescriptionDto.PartnerCenterDescription_Id);

            if (checkPartnerIdinDb != null)
            {
                return BadRequest();
            }

            PartnerCenterDescription newlyCreatedPartnerCenterDescription = new PartnerCenterDescription()
            {
                PartnerCenterDescription_Id = partnerCenterDescriptionDto.PartnerCenterDescription_Id,
                PartnerId = partnerCenterDescriptionDto.PartnerId,
                Rooms = partnerCenterDescriptionDto.Rooms,
                Capacity = partnerCenterDescriptionDto.Capacity,
                Facilities = partnerCenterDescriptionDto.Facilities,
                Activities = partnerCenterDescriptionDto.Activities,
                ApprovalStatus = partnerCenterDescriptionDto.ApprovalStatus,
                TextforQuotationforEmail = partnerCenterDescriptionDto.TextforQuotationforEmail,
                Transportation = partnerCenterDescriptionDto.Transportation,
                Description = partnerCenterDescriptionDto.Description
            };
            var destination = _mapper.Map<PartnerCenterDescription, PartnerCenterDescriptionDTO>(newlyCreatedPartnerCenterDescription);


            _choiceRepoistory.GetPartnerCenterDescriptions().Add(destination);
            _choiceRepoistory.Complete();
            return CreatedAtRoute("GetPartnerCenterDescriptionsById", new { name = newlyCreatedPartnerCenterDescription.PartnerCenterDescription_Id }, newlyCreatedPartnerCenterDescription);
        }


        // PUT api/<controller>/5
        [HttpPut("{PartnerCenterDescription_Id}")]
        public IActionResult UpdatePartnerCenterDescription(int PartnerCenterDescription_Id, [FromBody] PartnerCenterDescriptionDTO partnerCenterDescriptionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (partnerCenterDescriptionDto == null)
                return BadRequest();

            var partnerCenterDescription = _choiceRepoistory.GetPartnerCenterDescriptions().Find(c => c.PartnerCenterDescription_Id == PartnerCenterDescription_Id);

            if (partnerCenterDescription == null)
            {
                return BadRequest();
            }

            partnerCenterDescription = partnerCenterDescriptionDto;

            _choiceRepoistory.Complete();
            return NoContent();
        }
        
    }
}
