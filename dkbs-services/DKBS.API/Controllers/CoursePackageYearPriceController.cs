using System;
using AutoMapper;
using DKBS.Repository;
using DKBS.Domain;
using DKBS.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using DKBS.Data;

namespace DKBS.API.Controllers
{
    /// <summary>
    /// CoursePackageYearPrice
    /// </summary>
    /// 
    [Route("CoursePackageYearPrice")]
    [ApiController]
    public class CoursePackageYearPriceController : ControllerBase
    {
        private readonly IChoiceRepository _choiceRepoistory;
        private IMapper _mapper;

        /// <summary>       
        /// </summary>
        /// <param name="choiceRepoistory"></param>
        /// <param name="mapper"></param>
        public CoursePackageYearPriceController(IChoiceRepository choiceRepoistory, IMapper mapper)
        {
            _choiceRepoistory = choiceRepoistory;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All GetCoursePackageYearPrice
        /// </summary>
        /// <returns></returns>

        [HttpGet()]
        public ActionResult<CoursePackageYearPriceDTO> GetCoursePackageYearPriceController()
        {
            return Ok(_choiceRepoistory.GetAllCoursePackageYearPrice());
        }

        /// <summary>
        /// Get coursePackageYearPriceByServiceCatalogueID List based on ServiceCatalogueID
        /// </summary>
        /// <param name="CoursePackageID"></param>
        /// <returns></returns>      
        /// 


        [HttpGet("{coursePackageYearPriceID}", Name = "GetCoursePackageYearPriceByCoursePackageID")]
        public ActionResult<CoursePackageYearPriceDTO> GetCoursePackageYearPriceByCoursePackageID(int coursePackageYearPriceID)
        {
            return Ok(_choiceRepoistory.GetAllCoursePackageYearPrice().Find(c => c.CoursePackageYearPriceID == coursePackageYearPriceID));
        }

        /// <summary>
        /// Creating CoursePackageYearPriceDTO from CPYPD
        /// </summary>
        /// <param name="CoursePackageYearPriceDTO"></param>
        /// <returns></returns>

        [Authorize]
        [HttpPost]
        public ActionResult<CoursePackageYearPriceDTO> CreateCoursePackageYearPrice([FromBody] CoursePackageYearPriceDTO CoursePackageYearPriceDTO)
        {

            try
            {
                if (CoursePackageYearPriceDTO == null)
                {
                    ModelState.AddModelError("CoursePackageYearPrice", "CoursePackageYearPrice object can't be null");
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

                var CoursePackageYearPriceInDb = _choiceRepoistory.GetById<CoursePackageYearPrice>(c => c.CoursePackageYearPriceID == CoursePackageYearPriceDTO.CoursePackageYearPriceID && c.CoursePackageID == CoursePackageYearPriceDTO.CoursePackageID);
                if (CoursePackageYearPriceInDb != null)
                {
                    ModelState.AddModelError("CoursePackageYearPrice", $"CoursePackageYearPrice entry already exist for CoursePackageYearPriceID { CoursePackageYearPriceDTO.CoursePackageYearPriceID}.");
                    return BadRequest(ModelState);
                }

                CoursePackageYearPrice newCoursePackageYearPrice = _mapper.Map<CoursePackageYearPriceDTO, CoursePackageYearPrice>(CoursePackageYearPriceDTO);
                _choiceRepoistory.Attach<CoursePackageYearPrice>(newCoursePackageYearPrice);
                _choiceRepoistory.Complete();

                return CreatedAtRoute("GetCoursePackageFreeServicesByCoursePackageID", new { newCoursePackageYearPrice.CoursePackageYearPriceID }, newCoursePackageYearPrice);
            }
            catch (Exception ex)
            {
                // TODO : Add logging and decide on showing ex.message
                return StatusCode(500, "An error occurred while creating newCoursePackageYearPrice. Please try again or contact adminstrator");
            }

        }


        /// <summary>
        /// Update Contact Person
        /// </summary>
        /// <param name="CoursePackageYearPriceID"></param>
        /// <param name="CoursePackageYearPriceDTO"></param>
        /// <returns></returns>
        ///

        [Authorize]
        [HttpPut("{CoursePackageYearPriceID}")]
        public IActionResult UpdateCoursePackageYearPrice(int CoursePackageYearPriceID, [FromBody] CoursePackageYearPriceDTO coursePackageYearPriceDTO)
        {
            try
            {
                //if (int.IsNullOrWhiteSpace(serviceCatalogueID))
                //{
                //    ModelState.AddModelError("ServiceCatalogueID", "ServiceCatalogueID can't be null or empty");
                //    return BadRequest(ModelState);
                //}

                if (coursePackageYearPriceDTO == null)
                {
                    ModelState.AddModelError("CoursePackageYearPrice", "CoursePackageYearPrice object can't be null");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var CoursePackageYearPriceInDb = _choiceRepoistory.GetById<CoursePackageYearPrice>(c => c.CoursePackageYearPriceID == CoursePackageYearPriceID && c.CoursePackageID == coursePackageYearPriceDTO.CoursePackageID);


                if (CoursePackageYearPriceInDb == null)
                {
                    ModelState.AddModelError("CoursePackageYearPrice", $"No CoursePackageYearPrice found with CoursePackageID {coursePackageYearPriceDTO}");
                    return NotFound(ModelState);
                }
                CoursePackageYearPriceInDb.CoursePackageYearPriceID = coursePackageYearPriceDTO.CoursePackageYearPriceID;
                CoursePackageYearPriceInDb.CoursePackageID = coursePackageYearPriceDTO.CoursePackageID;
                CoursePackageYearPriceInDb.Year = coursePackageYearPriceDTO.Year;
                CoursePackageYearPriceInDb.SharepointID = coursePackageYearPriceDTO.SharepointID;
                CoursePackageYearPriceInDb.PricePerPerson = coursePackageYearPriceDTO.PricePerPerson;              
                _choiceRepoistory.Attach(CoursePackageYearPriceInDb);
                _choiceRepoistory.Complete();
                return NoContent();

            }
            catch (Exception ex)
            {
                // TODO : Add logging and decide on showing ex.message
                return StatusCode(500, "An error occurred while updating CoursePackageYearPrice. Please try again or contact adminstrator");
            }
        }


    }
}