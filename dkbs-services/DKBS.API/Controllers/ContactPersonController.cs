using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DKBS.Domain;
using DKBS.DTO;
using DKBS.Infrastructure.Sharepoint;
using DKBS.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DKBS.API.Controllers
{
    /// <summary>
    /// Contact Parson
    /// </summary>
    /// 
    [Authorize]
    [Route("contactperson")]
    [ApiController]
    public class ContactPersonController : ControllerBase
    {
        private readonly IChoiceRepository _choiceRepoistory;
        private readonly ISharepointService _sharePointService;
        private readonly IConfiguration _configuration;
        private IMapper _mapper;

        /// <summary>
        /// Contact Parson
        /// </summary>
        /// <param name="choiceReposiroty"></param>
        /// <param name="mapper"></param>
        /// <param name="sharePointService"></param>
        /// <param name="configuration"></param>

        public ContactPersonController(IChoiceRepository choiceReposiroty, IMapper mapper, ISharepointService sharePointService, IConfiguration configuration)
        {
            _choiceRepoistory = choiceReposiroty;
            _mapper = mapper;
            _sharePointService = sharePointService;
            _configuration = configuration;
        }

        /// <summary>
        /// Get All ContactPersons details.
        /// </summary>
        /// <returns>List of ContactPersons.</returns>
        [HttpGet()]
        public ActionResult<ContactPersonDTO> GetContactPersons()
        {
            return Ok(_choiceRepoistory.GetContactPersons());
        }



        ///// <summary>
        ///// Get ContactPersonByCustomerId List based on ContactId
        ///// </summary>
        ///// <param name="contactId"></param>
        ///// <returns></returns>
        ///// 
        //[Route("[action]/{contactId}",Name = "GetContactPersonByContactId")]
        //[HttpGet]
        //public ActionResult<IEnumerable<ContactPersonDTO>> GetContactPersonByContactId(string contactId)
        //{
        //    return _choiceRepoistory.GetContactPersons().FindAll(c => c.ContactId == contactId);
        //}


        /// <summary>
        /// Get ContactPersonByCustomerId List based on CustomerId
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        /// 

        [HttpGet("{contactId}", Name = "GetContactPersonByAccountId")]
        public ActionResult<IEnumerable<ContactPersonDTO>> GetContactPersonByAccountId(string contactId)
        {
            return _choiceRepoistory.GetContactPersons().FindAll(c => c.ContactId == contactId);
        }


        /// <summary>
        /// Creating ContactPerson from CRM
        /// </summary>
        /// <param name="contactPersonDTO"></param>
        /// <returns></returns>
        /// 

        [HttpPost]
        public async Task<ActionResult<ContactPersonDTO>> CreateContactPerson([FromBody] ContactPersonDTO contactPersonDTO)
        {
            try
            {
                if (contactPersonDTO == null)
                {
                    ModelState.AddModelError("ContactPerson", "ContactPerson object can't be null");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var contactPersonInDb = _choiceRepoistory.GetById<ContactPerson>(c => c.ContactId == contactPersonDTO.ContactId);
                if (contactPersonInDb != null)
                {
                    ModelState.AddModelError("ContactPerson", $"ContactPerson entry already exist for ContactId {contactPersonDTO.ContactId}.");
                    return BadRequest(ModelState);
                }

                ContactPerson newContactPerson = _mapper.Map<ContactPersonDTO, ContactPerson>(contactPersonDTO);
                newContactPerson.CreatedBy = "CRM";
                newContactPerson.CreatedDate = DateTime.UtcNow;
                newContactPerson.LastModified = DateTime.UtcNow;
                newContactPerson.LastModifiedBy = "CRM";
              
                if (bool.Parse(_configuration["SharePointIntegrationEnabled"].ToString()))
                {
                    var sharePointId = await _sharePointService.InsertCustomerContactAsync(newContactPerson, _choiceRepoistory.GetById<Customer>(c => c.AccountId == newContactPerson.AccountId)).ConfigureAwait(false);
                    if (sharePointId <= 0)
                    {
                        return StatusCode(500, "An error occurred while creating sharepoint customer contact. Please try again or contact adminstrator");
                    }
                    newContactPerson.SharePointId = sharePointId;
                }
                _choiceRepoistory.Attach<ContactPerson>(newContactPerson);
                _choiceRepoistory.Complete();
                return CreatedAtRoute("GetContactPersonByAccountId", new { newContactPerson.ContactId }, contactPersonDTO);
            }
            catch (Exception)
            {
                // TODO : Add logging and decide on showing ex.message
                return StatusCode(500, "An error occurred while creating ContactPerson. Please try again or contact adminstrator");
            }

        }

        /// <summary>
        /// Update Contact Person
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="contactPersonUpdateDTO"></param>
        /// <returns></returns>
        /// 

        
        [HttpPut("{contactId}")]
        public async Task<IActionResult> UpdateContactPerson(string contactId, [FromBody] ContactPersonUpdateDTO contactPersonUpdateDTO)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(contactId))
                {
                    ModelState.AddModelError("ContactId", "ContactId can't be null or empty");
                    return BadRequest(ModelState);
                }

                if (contactPersonUpdateDTO == null)
                {
                    ModelState.AddModelError("ContactPerson", "ContactPerson object can't be null");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var contactPersonInDb = _choiceRepoistory.GetById<ContactPerson>(c => c.ContactId == contactId);


                if (contactPersonInDb == null)
                {
                    ModelState.AddModelError("ContactPerson", $"No contact person found with AccountId {contactId}");
                    return NotFound(ModelState);
                }

                contactPersonInDb.AccountId = contactPersonUpdateDTO.AccountId;
                contactPersonInDb.Email = contactPersonUpdateDTO.Email;
                contactPersonInDb.FirstName = contactPersonUpdateDTO.FirstName;
                contactPersonInDb.LastName = contactPersonUpdateDTO.LastName;
                contactPersonInDb.MobilePhone = contactPersonUpdateDTO.MobilePhone;
                contactPersonInDb.Telephone = contactPersonUpdateDTO.Telephone;

                contactPersonInDb.LastModified = DateTime.UtcNow;
                contactPersonInDb.LastModifiedBy = "CRM";
                _choiceRepoistory.Attach(contactPersonInDb);
                if (bool.Parse(_configuration["SharePointIntegrationEnabled"].ToString()))
                {
                    var status = await _sharePointService.UpdateCustomerContactAsync(contactPersonInDb, _choiceRepoistory.GetById<Customer>(c => c.AccountId == contactPersonInDb.AccountId)).ConfigureAwait(false);
                    if (!status)
                    {
                        return StatusCode(500, "An error occurred while updating sharepoint customer contact. Please try again or contact adminstrator");
                    }
                }
                _choiceRepoistory.Complete();
                return NoContent();

            }
            catch (Exception ex)
            {
                // TODO : Add logging and decide on showing ex.message
                return StatusCode(500, "An error occurred while updating ContactPerson. Please try again or contact adminstrator");
            }
        }
    }
}
