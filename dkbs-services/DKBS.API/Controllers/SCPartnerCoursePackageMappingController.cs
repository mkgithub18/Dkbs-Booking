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
    /// SCPartnerCoursePackageMapping
    /// </summary>

    [Route("SCPartnerCoursePackage")]
    [ApiController]
    public class SCPartnerCoursePackageMappingController : ControllerBase
    {
        private readonly IChoiceRepository _choiceRepoistory;
        private IMapper _mapper;

        /// <summary>       
        /// </summary>
        /// <param name="choiceRepoistory"></param>
        /// <param name="mapper"></param>

        public SCPartnerCoursePackageMappingController(IChoiceRepository choiceRepoistory, IMapper mapper)
        {
            _choiceRepoistory = choiceRepoistory;
            _mapper = mapper;
        }
        /// <summary>
        /// Get All GetCoursePackageMenue
        /// </summary>
        /// <returns></returns>

        [HttpGet()]
        public ActionResult<SCPartnerCoursePackageMappingDTO> GetSCPartnerCoursePackageMappingController()
        {
            return Ok(_choiceRepoistory.GetAllSCPartnerCoursePackageMapping());
        }

        /// <summary>
        /// Get CoursePackageMenueByServiceCatalogueID List based on ServiceCatalogueID
        /// </summary>
        /// <param name="CoursePackageID"></param>
        /// <returns></returns>
        ///

        [HttpGet("{Id}")]
        public ActionResult<IEnumerable<SCPartnerCoursePackageMappingDTO>> GetSCPartnerCoursePackageMappingByCoursePackageID(int Id)
        {
            return _choiceRepoistory.GetAllSCPartnerCoursePackageMapping().FindAll(c => c.ID == Id);
        }


        /// <summary>
        /// Creating CoursePackageMenueDTO from CPMD
        /// </summary>
        /// <param name="SCPartnerCoursePackageMappingDTO"></param>
        /// <returns></returns>

        //[Authorize]
        [HttpPost]
        public ActionResult<SCPartnerCoursePackageMappingDTO> CreateSCPartnerCoursePackageMapping([FromBody] SCPartnerCoursePackageMappingDTO SCPartnerCoursePackageMappingDTO)
        {

            try
            {
                if (SCPartnerCoursePackageMappingDTO == null)
                {
                    ModelState.AddModelError("SCPartnerCoursePackageMapping", "SCPartnerCoursePackageMapping object can't be null");
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

                var SCPartnerCoursePackageMappingInDb = _choiceRepoistory.GetById<SCPartnerCoursePackageMapping>(c => c.ID == SCPartnerCoursePackageMappingDTO.ID);
                if (SCPartnerCoursePackageMappingInDb != null)
                {
                    ModelState.AddModelError("SCPartnerCoursePackageMapping", $"SCPartnerCoursePackageMapping entry already exist for CoursePackageMenueID {SCPartnerCoursePackageMappingDTO.ServiceCatalogueID}.");
                    return BadRequest(ModelState);
                }

                SCPartnerCoursePackageMapping newSCPartnerCoursePackageMapping = _mapper.Map<SCPartnerCoursePackageMappingDTO, SCPartnerCoursePackageMapping>(SCPartnerCoursePackageMappingDTO);
                _choiceRepoistory.Attach<SCPartnerCoursePackageMapping>(newSCPartnerCoursePackageMapping);
                _choiceRepoistory.Complete();

                return CreatedAtRoute("GetSCPartnerCoursePackageMappingByCoursePackageID", new { newSCPartnerCoursePackageMapping.ServiceCatalogueID }, newSCPartnerCoursePackageMapping);
            }
            catch (Exception ex)
            {
                // TODO : Add logging and decide on showing ex.message
                return StatusCode(500, "An error occurred while creating SCPartnerCoursePackageMapping. Please try again or contact adminstrator");
            }

        }

        /// <summary>
        /// Update Contact Person
        /// </summary>
        /// <param name="id"></param>
        /// <param name="SCPartnerCoursePackageMappingDTO"></param>
        /// <returns></returns>
        ///

        //[Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateSCPartnerCoursePackageMapping(int id, [FromBody] SCPartnerCoursePackageMappingDTO sCPartnerCoursePackageMappingDTO)
        {
            try
            {
                //if (int.IsNullOrWhiteSpace(serviceCatalogueID))
                //{
                //    ModelState.AddModelError("ServiceCatalogueID", "ServiceCatalogueID can't be null or empty");
                //    return BadRequest(ModelState);
                //}

                if (sCPartnerCoursePackageMappingDTO == null)
                {
                    ModelState.AddModelError("SCPartnerCoursePackageMapping", "SCPartnerCoursePackageMapping object can't be null");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var SCPartnerCoursePackageMappingInDb = _choiceRepoistory.GetById<SCPartnerCoursePackageMapping>(c => c.ServiceCatalogueID == id && c.CoursePackageID == sCPartnerCoursePackageMappingDTO.CoursePackageID);


                if (SCPartnerCoursePackageMappingInDb == null)
                {
                    ModelState.AddModelError("SCPartnerCoursePackageMapping", $"No SCPartnerCoursePackageMapping found with CoursePackageID {id}");
                    return NotFound(ModelState);
                }
                SCPartnerCoursePackageMappingInDb.ServiceCatalogueID = sCPartnerCoursePackageMappingDTO.ServiceCatalogueID;
                SCPartnerCoursePackageMappingInDb.CoursePackageID = sCPartnerCoursePackageMappingDTO.CoursePackageID;
                SCPartnerCoursePackageMappingInDb.ParterID = sCPartnerCoursePackageMappingDTO.ParterID;
                SCPartnerCoursePackageMappingInDb.CoursePackageFreeServiceID = sCPartnerCoursePackageMappingDTO.CoursePackageFreeServiceID;
                SCPartnerCoursePackageMappingInDb.CoursePackageYearPriceID = sCPartnerCoursePackageMappingDTO.CoursePackageYearPriceID;
                SCPartnerCoursePackageMappingInDb.CoursePackagePremiumServiceID = sCPartnerCoursePackageMappingDTO.CoursePackagePremiumServiceID;
                SCPartnerCoursePackageMappingInDb.CoursePackageMenueID = sCPartnerCoursePackageMappingDTO.CoursePackageMenueID;
                SCPartnerCoursePackageMappingInDb.Offered = sCPartnerCoursePackageMappingDTO.Offered;
                _choiceRepoistory.Attach(SCPartnerCoursePackageMappingInDb);
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