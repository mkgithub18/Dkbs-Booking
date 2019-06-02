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
    /// CoursePackagePremiumServices
    /// </summary>
    [Route("CoursePackagePremiumServices")]
    [ApiController]
    public class CoursePackagePremiumServicesController : ControllerBase
    {
        private readonly IChoiceRepository _choiceRepoistory;
        private IMapper _mapper;
        
        /// <summary>       
        /// </summary>
        /// <param name="choiceRepoistory"></param>
        /// <param name="mapper"></param>
        public CoursePackagePremiumServicesController(IChoiceRepository choiceRepoistory, IMapper mapper)
        {
            _choiceRepoistory = choiceRepoistory;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All GetCoursePackagePremiumServices
        /// </summary>
        /// <returns></returns>

        [HttpGet()]
        public ActionResult<CoursePackagePremiumServicesDTO> GetCoursePackagePremiumServicesController()
        {
            return Ok(_choiceRepoistory.GetAllCoursePackagePremiumServices());
        }

        /// <summary>
        /// Get CoursePackageMenueByServiceCatalogueID List based on ServiceCatalogueID
        /// </summary>
        /// <param name="CoursePackageID"></param>
        /// <returns></returns>
        /// 
        [HttpGet("{CoursePackagePremiumServiceID}", Name = "GetCoursePackagePremiumServicesByCoursePackageID")]
        public ActionResult<IEnumerable<CoursePackagePremiumServicesDTO>> GetCoursePackagePremiumServicesByCoursePackageID(int coursePackagePremiumServiceID)
        {
            return _choiceRepoistory.GetAllCoursePackagePremiumServices().FindAll(c => c.CoursePackagePremiumServiceID == coursePackagePremiumServiceID);
        }

        /// <summary>
        /// Creating CoursePackagePremiumServicesDTO from CPPSD
        /// </summary>
        /// <param name="CoursePackageFreeServicesDTO"></param>
        /// <returns></returns>
        ///

        [Authorize]
        [HttpPost]
        public ActionResult<CoursePackagePremiumServicesDTO> CreateCoursePackagePremiumServices([FromBody] CoursePackagePremiumServicesDTO CoursePackagePremiumServicesDTO)
        {

            try
            {
                if (CoursePackagePremiumServicesDTO == null)
                {
                    ModelState.AddModelError("CoursePackagePremiumServices", "CoursePackagePremiumServices object can't be null");
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

                var CoursePackagePremiumServicesInDb = _choiceRepoistory.GetById<CoursePackagePremiumServices>(c => c.CoursePackagePremiumServiceID == CoursePackagePremiumServicesDTO.CoursePackagePremiumServiceID && c.CoursePackageID == CoursePackagePremiumServicesDTO.CoursePackageID);
                if (CoursePackagePremiumServicesInDb != null)
                {
                    ModelState.AddModelError("CoursePackagePremiumServices", $"CoursePackagePremiumServices entry already exist for CoursePackagePremiumServicesID {CoursePackagePremiumServicesDTO.CoursePackagePremiumServiceID}.");
                    return BadRequest(ModelState);
                }

                CoursePackagePremiumServices newCoursePackagePremiumServices = _mapper.Map<CoursePackagePremiumServicesDTO, CoursePackagePremiumServices>(CoursePackagePremiumServicesDTO);
                _choiceRepoistory.Attach<CoursePackagePremiumServices>(newCoursePackagePremiumServices);
                _choiceRepoistory.Complete();

                return CreatedAtRoute("GetCoursePackagePremiumServicesByCoursePackageID", new { newCoursePackagePremiumServices.CoursePackagePremiumServiceID }, newCoursePackagePremiumServices);
            }
            catch (Exception ex)
            {
                // TODO : Add logging and decide on showing ex.message
                return StatusCode(500, "An error occurred while creating CoursePackagePremiumServices. Please try again or contact adminstrator");
            }

        }
        /// <summary>
        /// Update Contact Person
        /// </summary>
        /// <param name="coursePackagePremiumServiceID"></param>
        /// <param name="coursePackagePremiumServicesDTO"></param>
        /// <returns></returns>
        ///

        [Authorize]
        [HttpPut("{coursePackagePremiumServiceID}")]
        public IActionResult UpdatecoursePackagePremiumService(int coursePackagePremiumServiceID, [FromBody] CoursePackagePremiumServicesDTO coursePackagePremiumServicesDTO)
        {
            try
            {
                //if (int.IsNullOrWhiteSpace(serviceCatalogueID))
                //{
                //    ModelState.AddModelError("ServiceCatalogueID", "ServiceCatalogueID can't be null or empty");
                //    return BadRequest(ModelState);
                //}

                if (coursePackagePremiumServicesDTO == null)
                {
                    ModelState.AddModelError("CoursePackagePremiumServices", "CoursePackagePremiumServices object can't be null");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var CoursePackagePremiumServicesInDb = _choiceRepoistory.GetById<CoursePackagePremiumServices>(c => c.CoursePackagePremiumServiceID == coursePackagePremiumServiceID && c.CoursePackageID == coursePackagePremiumServicesDTO.CoursePackageID);


                if (CoursePackagePremiumServicesInDb == null)
                {
                    ModelState.AddModelError("CoursePackagePremiumServices", $"No CoursePackagePremiumServices found with CoursePackageID {coursePackagePremiumServicesDTO}");
                    return NotFound(ModelState);
                }
                CoursePackagePremiumServicesInDb.CoursePackagePremiumServiceID = coursePackagePremiumServicesDTO.CoursePackagePremiumServiceID;
                CoursePackagePremiumServicesInDb.CoursePackageID = coursePackagePremiumServicesDTO.CoursePackageID;
                CoursePackagePremiumServicesInDb.Description = coursePackagePremiumServicesDTO.Description;
                CoursePackagePremiumServicesInDb.SharepointID = coursePackagePremiumServicesDTO.SharepointID;
                CoursePackagePremiumServicesInDb.Price = coursePackagePremiumServicesDTO.Price;
                _choiceRepoistory.Attach(CoursePackagePremiumServicesInDb);
                _choiceRepoistory.Complete();

                return NoContent();

            }
            catch (Exception ex)
            {
                // TODO : Add logging and decide on showing ex.message
                return StatusCode(500, "An error occurred while updating CoursePackagePremiumService. Please try again or contact adminstrator");
            }
        }
    }
}