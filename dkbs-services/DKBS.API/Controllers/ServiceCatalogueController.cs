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
    [Route("ServiceCatalogue")]
    [ApiController]
    public class ServiceCatalogueController : ControllerBase
    {
        private readonly IChoiceRepository _choiceRepoistory;
        private IMapper _mapper;

        /// <summary>       
        /// </summary>
        /// <param name="choiceRepoistory"></param>
        /// <param name="mapper"></param>

        public ServiceCatalogueController(IChoiceRepository choiceRepoistory, IMapper mapper)
        {
            _choiceRepoistory = choiceRepoistory;
            _mapper = mapper;
        }
        /// <summary>
        /// Get All GetServiceCatalog
        /// </summary>
        /// <returns></returns>

        [HttpGet()]
        public ActionResult<ServiceCatalogueDTO> GetServiceCatalogController()
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
        public ActionResult<IEnumerable<ServiceCatalogueDTO>> GetServiceCatalogByServiceCatalogID(int ServiceCatalogId)
        {
            return _choiceRepoistory.GetServiceCatalog().FindAll(c => c.ServiceCatalogueID == ServiceCatalogId);
        }

        /// <summary>
        /// Creating ServiceCatalogDTO from SCD
        /// </summary>
        /// <param name="ServiceCatalogDTO"></param>
        /// <returns></returns>


        [HttpPost]
        public ActionResult<ServiceCatalogueDTO> CreateServiceCatalog([FromBody] ServiceCatalogueDTO serviceCatalogDTO)
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
                var ServiceCatalogInDb = _choiceRepoistory.GetById<ServiceCatalogue>(c => c.CoursePackageName == serviceCatalogDTO.CoursePackageName);
                if (ServiceCatalogInDb != null)
                {
                    ModelState.AddModelError("ServiceCatalog", $"ServiceCatalog entry already exist for ServiceCatalogueID {serviceCatalogDTO.ServiceCatalogueID}.");
                    return BadRequest(ModelState);
                }

                ServiceCatalogue newServiceCatalog = _mapper.Map<ServiceCatalogueDTO, ServiceCatalogue>(serviceCatalogDTO);

                //newServiceCatalog.CreatedBy = "SCD";
                newServiceCatalog.CreatedDate = DateTime.UtcNow;
                newServiceCatalog.LastModified = DateTime.UtcNow;
                //newServiceCatalog.LastModifiedBY = "SCD";

                _choiceRepoistory.Attach<ServiceCatalogue>(newServiceCatalog);
                _choiceRepoistory.Complete();

                string status = AddNewCoursePackageMenue(serviceCatalogDTO, newServiceCatalog.ServiceCatalogueID);

                if (status == "Error")
                {
                    return BadRequest(ModelState);
                }

                return CreatedAtRoute("ServiceCatalogue", new { newServiceCatalog.ServiceCatalogueID });
            }
            catch (Exception ex)
            {
                // TODO : Add logging and decide on showing ex.message
                return StatusCode(500, "An error occurred while creating ServiceCatalog. Please try again or contact adminstrator");
            }
        }
        /// <summary>
        /// Add New CoursePackageMenue                                                                                                                         
        /// </summary>
        /// <param name="serviceCatalogDTO"></param>
        /// <param name="serviceCatalogId"></param>
        /// <returns></returns>

        private string AddNewCoursePackageMenue(ServiceCatalogueDTO serviceCatalogDTO, int serviceCatalogId)
        {
            foreach (var coursePackageMenue in serviceCatalogDTO.CoursePackageMenueList)
            {
                var CoursePackageMenueInDb = _choiceRepoistory.GetById<CoursePackageMenue>(c => c.ServiceCatalogueID == serviceCatalogId);
                if (CoursePackageMenueInDb != null)
                {
                    ModelState.AddModelError("CoursePackageMenue", $"CoursePackageMenue entry \"{coursePackageMenue.Description}\"  already exist for ServiceCatalogId {serviceCatalogDTO.ServiceCatalogueID}.");
                    return "Error";
                }

                CoursePackageMenue newcoursePackageMenue = new CoursePackageMenue
                {
                    Description = coursePackageMenue.Description,
                    ServiceCatalogueID = serviceCatalogId,
                    Include = coursePackageMenue.Include,
                    Order = coursePackageMenue.Order,
                    CreatedDate = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow,
                    CoursePackageMenue_SPID = string.Empty,
                    CreatedBy = string.Empty,
                    LastModifiedBY = string.Empty
                };
                _choiceRepoistory.Attach<CoursePackageMenue>(newcoursePackageMenue);
                _choiceRepoistory.Complete();
            }
            return "Success";
        }


        /// <summary>
        /// Update Contact Person
        /// </summary>
        /// <param name="ServiceCatalogId"></param>
        /// <param name="ServiceCatalogDTO"></param>
        /// <returns></returns>

        [HttpPut("{ServiceCatalogId}")]
        public IActionResult UpdateServiceCatalog(int ServiceCatalogId, [FromBody] ServiceCatalogueDTO serviceCatalogDTO)
        {
            try
            {
                if (serviceCatalogDTO == null)
                {
                    ModelState.AddModelError("serviceCatalog", "serviceCatalog object can't be null");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var serviceCatalogInDb = _choiceRepoistory.GetById<ServiceCatalogue>(c => c.ServiceCatalogueID == ServiceCatalogId);


                if (serviceCatalogInDb == null)
                {
                    ModelState.AddModelError("ServiceCatalog", $"No v found with SevicrCatalogeID {ServiceCatalogId}");
                    return NotFound(ModelState);
                }
                serviceCatalogInDb.ServiceCatalogueID = serviceCatalogDTO.ServiceCatalogueID;
                serviceCatalogInDb.CoursePackageName = serviceCatalogDTO.CoursePackageName;
                serviceCatalogInDb.Offered = serviceCatalogDTO.Offered;
                serviceCatalogInDb.Price = serviceCatalogDTO.Price;
                serviceCatalogInDb.CreatedDate = serviceCatalogDTO.CreatedDate;
                serviceCatalogInDb.CreatedBy = serviceCatalogDTO.CreatedBy;
                serviceCatalogInDb.LastModified = serviceCatalogDTO.LastModified;
                serviceCatalogInDb.LastModifiedBY = serviceCatalogDTO.LastModifiedBY;
                _choiceRepoistory.Attach(serviceCatalogInDb);
                _choiceRepoistory.Complete();

                UpdateCoursePackageMenue(serviceCatalogDTO, serviceCatalogInDb.ServiceCatalogueID);

                return NoContent();

            }
            catch (Exception ex)
            {
                // TODO : Add logging and decide on showing ex.message
                return StatusCode(500, "An error occurred while updating ServiceCatalog. Please try again or contact adminstrator");
            }
        }

        private void UpdateCoursePackageMenue(ServiceCatalogueDTO serviceCatalogDTO, int serviceCatalogId)
        {
            foreach (var coursePackageMenue in serviceCatalogDTO.CoursePackageMenueList)
            {
                var CoursePackageMenueInDb = _choiceRepoistory.GetById<CoursePackageMenue>(c => c.ServiceCatalogueID == serviceCatalogId && c.Description == coursePackageMenue.Description);
                if (CoursePackageMenueInDb == null)
                {
                    CoursePackageMenue newcoursePackageMenue = new CoursePackageMenue
                    {
                        Description = coursePackageMenue.Description,
                        ServiceCatalogueID = serviceCatalogId,
                        Include = coursePackageMenue.Include,
                        Order = coursePackageMenue.Order,
                        CreatedDate = DateTime.UtcNow,
                        LastModified = DateTime.UtcNow
                    };
                    _choiceRepoistory.Attach<CoursePackageMenue>(newcoursePackageMenue);
                    _choiceRepoistory.Complete();
                }
                else
                {
                    CoursePackageMenueInDb.Description = coursePackageMenue.Description;
                    CoursePackageMenueInDb.ServiceCatalogueID = serviceCatalogId;
                    CoursePackageMenueInDb.Include = coursePackageMenue.Include;
                    CoursePackageMenueInDb.Order = coursePackageMenue.Order;
                    CoursePackageMenueInDb.LastModified = DateTime.UtcNow;
                    _choiceRepoistory.Attach<CoursePackageMenue>(CoursePackageMenueInDb);
                    _choiceRepoistory.Complete();
                }


            }
        }


    }
}