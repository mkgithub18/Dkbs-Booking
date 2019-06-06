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
    /// CoursePackageMenue
    /// </summary>
    [Route("CoursePackageMenue")]
    [ApiController]
    public class CoursePackageMenueController : ControllerBase
    {
        private readonly IChoiceRepository _choiceRepoistory;
        private IMapper _mapper;

        /// <summary>       
        /// </summary>
        /// <param name="choiceRepoistory"></param>
        /// <param name="mapper"></param>

        public CoursePackageMenueController(IChoiceRepository choiceRepoistory, IMapper mapper)
        {
            _choiceRepoistory = choiceRepoistory;
            _mapper = mapper;
        }
        /// <summary>
        /// Get All GetCoursePackageMenue
        /// </summary>
        /// <returns></returns>

        [HttpGet()]
        public ActionResult<CoursePackageMenueDTO> GetCoursePackageMenueController()
        {
            return Ok(_choiceRepoistory.GetAllCoursePackageMenue());
        }

        /// <summary>
        /// Get CoursePackageMenueByServiceCatalogueID List based on ServiceCatalogueID
        /// </summary>
        /// <param name="CoursePackageID"></param>
        /// <returns></returns>
        /// 

        [HttpGet("{CoursePackageMenueID}")]
        public ActionResult<IEnumerable<CoursePackageMenueDTO>> GetCoursePackageMenueByCoursePackageID(int CoursePackageMenueID)
        {
            return _choiceRepoistory.GetAllCoursePackageMenue().FindAll(c => c.CoursePackageMenueID == CoursePackageMenueID);
        }


        /// <summary>
        /// Creating CoursePackageMenueDTO from CPMD
        /// </summary>
        /// <param name="CoursePackageMenueDTO"></param>
        /// <returns></returns>
        ///

        //[Authorize]
        [HttpPost]
        public ActionResult<CoursePackageMenueDTO> CreateCoursePackageMenue([FromBody] CoursePackageMenueDTO CoursePackageMenueDTO)
        {

            try
            {
                if (CoursePackageMenueDTO == null)
                {
                    ModelState.AddModelError("CoursePackageMenue", "CoursePackageMenue object can't be null");
                    return BadRequest(ModelState); 
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

               
                var CoursePackageMenueInDb = _choiceRepoistory.GetById<CoursePackageMenue>(c => c.CoursePackageMenueID == CoursePackageMenueDTO.CoursePackageMenueID);
                if (CoursePackageMenueInDb != null)
                {
                    ModelState.AddModelError("CoursePackageMenue", $"CoursePackageMenue entry already exist for CoursePackageMenueID {CoursePackageMenueDTO.ServiceCatalogueID}.");
                    return BadRequest(ModelState);
                }

                CoursePackageMenue newCoursePackageMenue = _mapper.Map<CoursePackageMenueDTO, CoursePackageMenue>(CoursePackageMenueDTO);       
                _choiceRepoistory.Attach<CoursePackageMenue>(newCoursePackageMenue);
                _choiceRepoistory.Complete();

                return CreatedAtRoute("CoursePackageMenue", new { newCoursePackageMenue.CoursePackageMenueID });
            }
            catch (Exception ex)
            {
                // TODO : Add logging and decide on showing ex.message
                return StatusCode(500, "An error occurred while creating CoursePackageMenue. Please try again or contact adminstrator");
            }

        }

        /// <summary>
        /// Update Contact Person
        /// </summary>
        /// <param name="id"></param>
        /// <param name="coursePackageMenuenDTO"></param>
        /// <returns></returns>
        ///

        //[Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateCoursePackageMenue(int id, [FromBody] CoursePackageMenueDTO coursePackageMenuenDTO)
        {
            try
            {
                //if (int.IsNullOrWhiteSpace(serviceCatalogueID))
                //{
                //    ModelState.AddModelError("ServiceCatalogueID", "ServiceCatalogueID can't be null or empty");
                //    return BadRequest(ModelState);
                //}

                if (coursePackageMenuenDTO == null)
                {
                    ModelState.AddModelError("CoursePackageMenue", "CoursePackageMenue object can't be null");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var CoursePackageMenueInDb = _choiceRepoistory.GetById<CoursePackageMenue>(c => c.ServiceCatalogueID == id);


                if (CoursePackageMenueInDb == null)
                {
                    ModelState.AddModelError("CoursePackageMenue", $"No CoursePackageMenue found with CoursePackageID {id}");
                    return NotFound(ModelState);
                }
                CoursePackageMenueInDb.CoursePackageMenueID = coursePackageMenuenDTO.CoursePackageMenueID;
               // CoursePackageMenueInDb.CoursePackageID = coursePackageMenuenDTO.CoursePackageID;
                CoursePackageMenueInDb.ServiceCatalogueID = coursePackageMenuenDTO.ServiceCatalogueID;
                CoursePackageMenueInDb.Description = coursePackageMenuenDTO.Description;
                CoursePackageMenueInDb.Include = coursePackageMenuenDTO.Include;
                CoursePackageMenueInDb.Order = coursePackageMenuenDTO.Order;
                CoursePackageMenueInDb.CoursePackageMenue_SPID = coursePackageMenuenDTO.CoursePackageMenue_SPID;
                _choiceRepoistory.Attach(CoursePackageMenueInDb);
                _choiceRepoistory.Complete();

                return NoContent();

            }
            catch (Exception ex)
            {
                // TODO : Add logging and decide on showing ex.message
                return StatusCode(500, "An error occurred while updating CoursePackageMenue. Please try again or contact adminstrator");
            }
        }

    }

}