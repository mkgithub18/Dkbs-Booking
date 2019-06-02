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
    /// CoursePackageFreeServices
    /// </summary>

    [Route("CoursePackageFreeServices")]
    [ApiController]
    public class CoursePackageFreeServicesController : ControllerBase
    {
        private readonly IChoiceRepository _choiceRepoistory;
        private IMapper _mapper;

        /// <summary>       
        /// </summary>
        /// <param name="choiceRepoistory"></param>
        /// <param name="mapper"></param>
        public CoursePackageFreeServicesController(IChoiceRepository choiceRepoistory, IMapper mapper)
        {
            _choiceRepoistory = choiceRepoistory;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All GetCoursePackageFreeServices
        /// </summary>
        /// <returns></returns>

        [HttpGet()]
        public ActionResult<CoursePackageFreeServicesDTO> GetCoursePackageFreeServicesController()
        {
            return Ok(_choiceRepoistory.GetAllCoursePackageFreeServices());
        }


        /// <summary>
        /// Get CoursePackageMenueByServiceCatalogueID List based on ServiceCatalogueID
        /// </summary>
        /// <param name="CoursePackageID"></param>
        /// <returns></returns>
        /// 

        [HttpGet("{id}")]
        public ActionResult<CoursePackageFreeServicesDTO> GetCoursePackageMenueByCoursePackageID(int id)
        {
            return Ok(_choiceRepoistory.GetAllCoursePackageFreeServices().Find(c => c.CoursePackageFreeServiceID == id));
        }



        /// <summary>
        /// Creating CoursePackageFreeServicesDTO from CPFSD
        /// </summary>
        /// <param name="CoursePackageFreeServicesDTO"></param>
        /// <returns></returns>
        ///

        [Authorize]
        [HttpPost]
        public ActionResult<CoursePackageFreeServicesDTO> CreateCoursePackageFreeServices([FromBody] CoursePackageFreeServicesDTO CoursePackageFreeServicesDTO)
        {

            try
            {
                if (CoursePackageFreeServicesDTO == null)
                {
                    ModelState.AddModelError("CoursePackageFreeServices", "CoursePackageFreeServices object can't be null");
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

                var CoursePackageFreeServicesInDb = _choiceRepoistory.GetById<CoursePackageFreeServices>(c => c.CoursePackageFreeServiceID == CoursePackageFreeServicesDTO.CoursePackageFreeServiceID && c.CoursePackageID == CoursePackageFreeServicesDTO.CoursePackageID);
                if (CoursePackageFreeServicesInDb != null)
                {
                    ModelState.AddModelError("CoursePackageFreeServices", $"CoursePackageFreeServices entry already exist for CoursePackageFreeServicesID {CoursePackageFreeServicesDTO.CoursePackageFreeServiceID}.");
                    return BadRequest(ModelState);
                }

                CoursePackageFreeServices newCoursePackageFreeServices = _mapper.Map<CoursePackageFreeServicesDTO, CoursePackageFreeServices>(CoursePackageFreeServicesDTO);
                _choiceRepoistory.Attach<CoursePackageFreeServices>(newCoursePackageFreeServices);
                _choiceRepoistory.Complete();

                return CreatedAtRoute("GetCoursePackageFreeServicesByCoursePackageID", new { newCoursePackageFreeServices.CoursePackageFreeServiceID }, newCoursePackageFreeServices);
            }
            catch (Exception ex)
            {
                // TODO : Add logging and decide on showing ex.message
                return StatusCode(500, "An error occurred while creating CoursePackageFreeServices. Please try again or contact adminstrator");
            }

        }

        /// <summary>
        /// Update Contact Person
        /// </summary>
        /// <param name="coursePackageFreeServiceID"></param>
        /// <param name="CoursePackageFreeServicesDTO"></param>
        /// <returns></returns>
        ///

        [Authorize]
        [HttpPut("{coursePackageFreeServiceID}")]
        public IActionResult UpdatecoursePackageFreeService(int coursePackageFreeServiceID, [FromBody] CoursePackageFreeServicesDTO coursePackageFreeServicesDTO)
        {
            try
            {
                //if (int.IsNullOrWhiteSpace(serviceCatalogueID))
                //{
                //    ModelState.AddModelError("ServiceCatalogueID", "ServiceCatalogueID can't be null or empty");
                //    return BadRequest(ModelState);
                //}

                if (coursePackageFreeServicesDTO == null)
                {
                    ModelState.AddModelError("CoursePackageFreeServices", "CoursePackageFreeServices object can't be null");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var CoursePackageFreeServicesInDb = _choiceRepoistory.GetById<CoursePackageFreeServices>(c => c.CoursePackageFreeServiceID == coursePackageFreeServiceID && c.CoursePackageID == coursePackageFreeServicesDTO.CoursePackageID);


                if (CoursePackageFreeServicesInDb == null)
                {
                    ModelState.AddModelError("CoursePackageFreeServices", $"No CoursePackageFreeServices found with CoursePackageID {coursePackageFreeServicesDTO}");
                    return NotFound(ModelState);
                }
                CoursePackageFreeServicesInDb.CoursePackageFreeServiceID = coursePackageFreeServicesDTO.CoursePackageFreeServiceID;
                CoursePackageFreeServicesInDb.CoursePackageID = coursePackageFreeServicesDTO.CoursePackageID;
                CoursePackageFreeServicesInDb.Description = coursePackageFreeServicesDTO.Description;
                CoursePackageFreeServicesInDb.SharepointID = coursePackageFreeServicesDTO.SharepointID;               
                _choiceRepoistory.Attach(CoursePackageFreeServicesInDb);
                _choiceRepoistory.Complete();

                return NoContent();

            }
            catch (Exception ex)
            {
                // TODO : Add logging and decide on showing ex.message
                return StatusCode(500, "An error occurred while updating CoursePackageFreeService. Please try again or contact adminstrator");
            }
        }






    }
}