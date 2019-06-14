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
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DKBS.API.Controllers
{
    /// <summary>
    /// Customer Controller
    /// </summary>
    /// 
    [Authorize]
    [Route("customer")]
    public class CustomerController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IChoiceRepository _choiceRepoistory;
        private readonly ISharepointService _sharePointService;
        private IMapper _mapper;

        /// <summary>
        /// Customer Controller
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="choiceReposiroty"></param>
        /// <param name="sharePointService"></param>
        ///  <param name="configuration"></param>
        public CustomerController(IChoiceRepository choiceReposiroty, IMapper mapper, ISharepointService sharePointService, IConfiguration configuration)
        {
            _choiceRepoistory = choiceReposiroty;
            _mapper = mapper;
            _sharePointService = sharePointService;
            _configuration = configuration;
        }
        /// <summary>
        /// Get All Customers
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public ActionResult<CustomerDTO> GetCustomers()
        {
            return Ok(_choiceRepoistory.GetCustomers());
        }
        /// <summary>
        /// Get Customer details by account id
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [HttpGet("{accountId}", Name = "GetCustomerByAccountId")]
        public ActionResult<CustomerDTO> GetCustomerByAccountId(string accountId)
        {
            return _choiceRepoistory.GetCustomers().Find(c => c.AccountId == accountId);
        }

        /// <summary>
        /// Creating Customer from CRM
        /// </summary>
        /// <param name="customerDto"></param>
        /// <returns></returns>
        ///
        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> CreateCustomer([FromBody] CustomerDTO customerDto)
        {
            try
            {
                if (customerDto == null)
                {
                    ModelState.AddModelError("Customer", "Customer object can't be null");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var customer = _choiceRepoistory.GetById<Customer>(c => c.AccountId == customerDto.AccountId);

                if (customer != null)
                {
                    ModelState.AddModelError("Customer", $"Customer entry already exist for AccountId {customerDto.AccountId}.");
                    return BadRequest(ModelState);
                }

                Customer newCustomer = _mapper.Map<CustomerDTO, Customer>(customerDto);
                newCustomer.CreatedDate = DateTime.UtcNow;
                newCustomer.CreatedBy = "CRM";
                newCustomer.LastModified = DateTime.UtcNow;
                newCustomer.LastModifiedBy = "CRM";
               

                if (bool.Parse(_configuration["SharePointIntegrationEnabled"].ToString()))
                {
                    var sharePointId = await _sharePointService.InsertCustomerAsync(newCustomer);
                    if (sharePointId <=0)
                    {
                        return StatusCode(500, "An error occurred while creating sharepoint customer. Please try again or contact adminstrator");
                    }
                    newCustomer.SharePointId = sharePointId;
                }
                _choiceRepoistory.Attach<Customer>(newCustomer);
                _choiceRepoistory.Complete();


                return CreatedAtRoute("GetCustomerByAccountId", new { newCustomer.AccountId }, customer);
            }
            catch (Exception)
            {
                // TODO : Add logging and decide on showing ex.message
                return StatusCode(500, "An error occurred while creating Customer. Please try again or contact adminstrator");
            }

        }


        /// <summary>
        /// Update Customer
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="customerUpdateDTO"></param>
        /// <returns></returns>
        /// 
        [HttpPut("{accountId}")]
        public async Task<IActionResult> UpdateCustomer(string accountId, [FromBody] CustomerUpdateDTO customerUpdateDTO)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(accountId))
                {
                    ModelState.AddModelError("AccountId", "AccountId can't be null or empty.");
                    return BadRequest(ModelState);
                }

                if (customerUpdateDTO == null)
                {
                    ModelState.AddModelError("Customer", "Customer object can't be null");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var customer = _choiceRepoistory.GetById<Customer>(c => c.AccountId == accountId);

                if (customer == null)
                {
                    ModelState.AddModelError("Customer", $"No customer found with AccountId {accountId}");
                    return NotFound(ModelState);
                }

                customer.Address1 = customerUpdateDTO.Address1;
                customer.Address2 = customerUpdateDTO.Address2;
                customer.CompanyName = customerUpdateDTO.CompanyName;
                customer.Country = customerUpdateDTO.Country;
                customer.IndustryCode = customerUpdateDTO.IndustryCode;
                customer.PhoneNumber = customerUpdateDTO.PhoneNumber;
                customer.PostNumber = customerUpdateDTO.PostNumber;
                customer.StateAgreement = customerUpdateDTO.StateAgreement;
                customer.Town = customerUpdateDTO.Town;
                customer.LastModified = DateTime.UtcNow;
                customer.LastModifiedBy = "CRM";
                _choiceRepoistory.Attach(customer);
                if (bool.Parse(_configuration["SharePointIntegrationEnabled"].ToString()))
                {
                    var status = await _sharePointService.UpdateCustomerAsync(customer);
                    if (!status)
                    {
                        return StatusCode(500, "An error occurred while creating sharepoint customer. Please try again or contact adminstrator");
                    }
                }
                _choiceRepoistory.Complete();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating Customer. Please try again or contact adminstrator");
            }
        }

    }
}