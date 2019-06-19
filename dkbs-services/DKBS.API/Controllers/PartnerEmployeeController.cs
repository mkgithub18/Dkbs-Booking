using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DKBS.Domain;
using DKBS.DTO;
using DKBS.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Text;

namespace DKBS.API.Controllers
{
    /// <summary>
    /// PartnerEmployee controller
    /// </summary>
    /// 
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerEmployeeController : Controller
    {
        private readonly IChoiceRepository _choiceRepoistory;
        private IMapper _mapper;
        PartnerEmployeeCRMService partnerEmployeeCRMService = new PartnerEmployeeCRMService();
        /// <summary>
        /// PartnerEmployee Controller
        /// </summary>
        public PartnerEmployeeController(IChoiceRepository choiceReposiroty, IMapper mapper)
        {
            _choiceRepoistory = choiceReposiroty;
            _mapper = mapper;
        }


        /// <summary>
        /// Get PartnerEmployee  based on peSharepointId
        /// </summary>
        /// <param name="peSharePointId"></param>
        /// <returns></returns>
       // [Route("[action]/{peSharePointId}")]
        [HttpGet]
        [Route("[action]/{peSharePointId}", Name = "GetPartnerEmployeeById")]
        public ActionResult<PartnerEmployeeDTO> GetPartnerEmployeeById(string peSharePointId)
        {
            return Ok(_choiceRepoistory.GetPartnerEmployees().Find(x => x.PESharePointId == peSharePointId));
        }


        /// <summary>
        /// Get PartnerEmployee List based on some character entered by user in Partner name
        /// </summary>
        /// <param name="partnerName"></param>
        /// <returns></returns>
        [HttpGet("{partnerName}", Name = "GetPartnerEmployees")]
        public ActionResult<IEnumerable<PartnerEmployeeDTO>> GetPartnerEmployees(string partnerName)
        {
            //currently sdduming partnerName only later we will change as per requirement
            return _choiceRepoistory.GetPartnerEmployees().FindAll(c => c.CrmPartnerAccountId == partnerName);
        }

        /// <summary>
        /// Creating PartnerEmployee
        /// </summary>
        /// <param name="partnerEmployeeDto"></param>
        /// <returns></returns>
        // GET api/PartnerEmployee/{PartnerEmployee}
       [Authorize]
        [HttpPost()]
        public ActionResult<IEnumerable<PartnerEmployeeDTO>> CreatePartnerEmployee([FromBody] PartnerEmployeeDTO partnerEmployeeDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (partnerEmployeeDto == null)
                return BadRequest();

            var checkPartnerEmployeeinDb = _choiceRepoistory.GetPartnerEmployees().Find(c => c.PESharePointId == partnerEmployeeDto.PESharePointId);

            if (checkPartnerEmployeeinDb != null)
            {
                return BadRequest();
            }
            PartnerEmployee newlyCreatedPartnerEmployee = _mapper.Map<PartnerEmployeeDTO, PartnerEmployee>(partnerEmployeeDto);
            _choiceRepoistory.SetPartnerEmployees(newlyCreatedPartnerEmployee);

            bool Istrue = partnerEmployeeCRMService.CRMActionTypeGeneric(newlyCreatedPartnerEmployee, "CreatePartnerEmployeeCRM");

            if (Istrue)
            {
                _choiceRepoistory.Complete();
                return CreatedAtRoute("GetPartnerEmployeeById", new { peSharePointId = newlyCreatedPartnerEmployee.PESharePointId }, newlyCreatedPartnerEmployee);
            }
            return BadRequest();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="peSharePointId"></param>
        /// <param name="partnerEmployeeUpdateDTO"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("{peSharePointId}")]
        public IActionResult UpdatePartnerEmployee(string peSharePointId, [FromBody] PartnerEmployeeUpdateDTO partnerEmployeeUpdateDTO)
        {

            if (partnerEmployeeUpdateDTO == null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var checkPartnerIdinDb = _choiceRepoistory.GetById<PartnerEmployee>(c => c.PESharePointId == peSharePointId);//_choiceRepoistory.GetPartnerEmployees().Find(c => c.SharePointId == partnerEmployeeId);

            if (checkPartnerIdinDb == null)
            {
                return BadRequest();
            }

            //checkPartnerIdinDb = partnerEmployeeDTO;


            checkPartnerIdinDb.FirstName = partnerEmployeeUpdateDTO.FirstName;
            checkPartnerIdinDb.LastName = partnerEmployeeUpdateDTO.LastName;
            // PartnerEmployeeId = partnerEmployeeDto.PartnerEmployeeId,
            checkPartnerIdinDb.Email = partnerEmployeeUpdateDTO.Email;
            // ParticipantType = participantType,
            checkPartnerIdinDb.JobTitle = partnerEmployeeUpdateDTO.JobTitle;
            //  PartnerType = partnerType,
            checkPartnerIdinDb.MailGroup = partnerEmployeeUpdateDTO.MailGroup;


            // checkPartnerIdinDb.SharePointId = partnerEmployeeDTO.SharePointId;


            checkPartnerIdinDb.TelePhoneNumber = partnerEmployeeUpdateDTO.TelePhoneNumber;
            checkPartnerIdinDb.CrmPartnerAccountId = partnerEmployeeUpdateDTO.CrmPartnerAccountId;
            checkPartnerIdinDb.LastModified = partnerEmployeeUpdateDTO.LastModified;
            checkPartnerIdinDb.LastModifiedBy = partnerEmployeeUpdateDTO.LastModifiedBy;
            checkPartnerIdinDb.SMSNotification = partnerEmployeeUpdateDTO.SMSNotification;
            checkPartnerIdinDb.EmailNotification = partnerEmployeeUpdateDTO.EmailNotification;
            checkPartnerIdinDb.Identifier = partnerEmployeeUpdateDTO.Identifier;
           checkPartnerIdinDb.DeactivatedUser = partnerEmployeeUpdateDTO.DeactivatedUser;

            _choiceRepoistory.Attach(checkPartnerIdinDb);

          // _choiceRepoistory.Complete();

            bool Istrue= partnerEmployeeCRMService.CRMActionTypeGeneric(checkPartnerIdinDb, "UpdatePartnerEmployeeCRM");


            if (Istrue)
            {
                _choiceRepoistory.Complete();
                return NoContent();
            }

           
            return BadRequest();
        }

    }
   

}
