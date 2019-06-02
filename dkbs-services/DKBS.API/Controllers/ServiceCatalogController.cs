using System;
using AutoMapper;
using DKBS.Repository;
using DKBS.Domain;
using DKBS.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace DKBS.API.Controllers
{
    /// <summary>
    /// ServiceCatalog
    /// </summary>
    [Route("ServiceCatalog")]
    [ApiController]
    public class ServiceCatalogController : ControllerBase
    {
        private readonly IChoiceRepository _choiceRepoistory;
        private IMapper _mapper;

        /// <summary>       
        /// </summary>
        /// <param name="choiceRepoistory"></param>
        /// <param name="mapper"></param>

        public ServiceCatalogController(IChoiceRepository choiceRepoistory, IMapper mapper)
        {
            _choiceRepoistory = choiceRepoistory;
            _mapper = mapper;
        }
        /// <summary>
        /// Get All GetServiceCatalog
        /// </summary>
        /// <returns></returns>

        [HttpGet()]
        public ActionResult<ServiceCatalogDTO> GetServiceCatalogController()
        {
            return Ok(_choiceRepoistory.GetServiceCatalog());
        }

        /// <summary>
        /// Get ServiceCatalogeByServiceCatalogueID List based on ServiceCatalogueID
        /// </summary>
        /// <param name="ServiceCatalogId"></param>
        /// <returns></returns>
        ///

        [HttpGet("{ServiceCatalogId}")]
        public ActionResult<IEnumerable<ServiceCatalogDTO>> GetSCPartnerCoursePackageMappingByCoursePackageID(int ServiceCatalogId)
        {
            return _choiceRepoistory.GetServiceCatalog().FindAll(c => c.ServiceCatalogId == ServiceCatalogId);
        }

        /// <summary>
        /// Creating ServiceCatalogDTO from SCD
        /// </summary>
        /// <param name="ServiceCatalogDTO"></param>
        /// <returns></returns>

       
        [HttpPost]
        public ActionResult<ServiceCatalogDTO> CreateServiceCatalog([FromBody] ServiceCatalogDTO serviceCatalogDTO)
        {

            try
            {
                if (serviceCatalogDTO == null)
                {
                    ModelState.AddModelError("ServiceCatalog", "ServiceCatalog object can't be null");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Intentionally commented                                               
                //var contactPersonInDb = _choiceRepoistory.GetById<ContactPerson>(c => c.AccountId == contactPersonDTO.AccountId);

                //if (contactPersonInDb != null)
                //{
                //    ModelState.AddModelError("ContactPerson", $"ContactPerson entry already exist for AccountId {contactPersonDTO.AccountId}.");
                //    return BadRequest(ModelState);
                //}

                var ServiceCatalogInDb = _choiceRepoistory.GetById<ServiceCatalog>(c => c.ServiceCatalogId == serviceCatalogDTO.ServiceCatalogId);
                if (ServiceCatalogInDb != null)
                {
                    ModelState.AddModelError("ServiceCatalog", $"ServiceCatalog entry already exist for CoursePackageMenueID {serviceCatalogDTO.ServiceCatalogId}.");
                    return BadRequest(ModelState);
                }

                ServiceCatalog newServiceCatalog = _mapper.Map<ServiceCatalogDTO, ServiceCatalog>(serviceCatalogDTO);

                newServiceCatalog.CreatedBy = "SCD";
                newServiceCatalog.CreatedDate = DateTime.UtcNow;
                newServiceCatalog.LastModified = DateTime.UtcNow;
                newServiceCatalog.LastModifiedBY = "SCD";

                _choiceRepoistory.Attach<ServiceCatalog>(newServiceCatalog);
                _choiceRepoistory.Complete();

                return CreatedAtRoute("GetServiceCatalogByServiceCatalogID", new { newServiceCatalog.ServiceCatalogId });
            }
            catch (Exception ex)
            {
                // TODO : Add logging and decide on showing ex.message
                return StatusCode(500, "An error occurred while creating ServiceCatalog. Please try again or contact adminstrator");
            }
        }

        /// <summary>
        /// Update Contact Person
        /// </summary>
        /// <param name="ServiceCatalogId"></param>
        /// <param name="ServiceCatalogDTO"></param>
        /// <returns></returns>

        [HttpPut("{ServiceCatalogId}")]
        public IActionResult UpdateServiceCatalog(int ServiceCatalogId, [FromBody] ServiceCatalogDTO serviceCatalogDTO)
        {
            try
            {
                //if (int.IsNullOrWhiteSpace(serviceCatalogueID))
                //{
                //    ModelState.AddModelError("ServiceCatalogueID", "ServiceCatalogueID can't be null or empty");
                //    return BadRequest(ModelState);
                //}

                if (serviceCatalogDTO == null)
                {
                    ModelState.AddModelError("serviceCatalog", "serviceCatalog object can't be null");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var serviceCatalogInDb = _choiceRepoistory.GetById<ServiceCatalog>(c => c.ServiceCatalogId == ServiceCatalogId);


                if (serviceCatalogInDb == null)
                {
                    ModelState.AddModelError("ServiceCatalog", $"No v found with SevicrCatalogeID {ServiceCatalogId}");
                    return NotFound(ModelState);
                }
                serviceCatalogInDb.ServiceCatalogId = serviceCatalogDTO.ServiceCatalogId;
                serviceCatalogInDb.CoursePackage = serviceCatalogDTO.CoursePackage;
                serviceCatalogInDb.CoursePackageEng = serviceCatalogDTO.CoursePackageEng;
                serviceCatalogInDb.Offered = serviceCatalogDTO.Offered;
                serviceCatalogInDb.Price = serviceCatalogDTO.Price;
                serviceCatalogInDb.CoursePackageType = serviceCatalogDTO.CoursePackageType;
                serviceCatalogInDb.CanBePurchased = serviceCatalogDTO.CanBePurchased;
                serviceCatalogInDb.CreatedDate = serviceCatalogDTO.CreatedDate;
                serviceCatalogInDb.CreatedBy = serviceCatalogDTO.CreatedBy;
                serviceCatalogInDb.LastModified = serviceCatalogDTO.LastModified;
                serviceCatalogInDb.LastModifiedBY = serviceCatalogDTO.LastModifiedBY;
                _choiceRepoistory.Attach(serviceCatalogInDb);
                _choiceRepoistory.Complete();

                return NoContent();

            }
            catch (Exception ex)
            {
                // TODO : Add logging and decide on showing ex.message
                return StatusCode(500, "An error occurred while updating ServiceCatalog. Please try again or contact adminstrator");
            }
        }



    }
}