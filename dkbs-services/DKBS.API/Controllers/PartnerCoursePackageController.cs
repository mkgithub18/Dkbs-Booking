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
    [Route("PartnerCoursePackage")]
    [ApiController]
    public class PartnerCoursePackageController : ControllerBase
    {
        private readonly IChoiceRepository _choiceRepoistory;
        private IMapper _mapper;


        public PartnerCoursePackageController(IChoiceRepository choiceRepoistory, IMapper mapper)
        {
            _choiceRepoistory = choiceRepoistory;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All GetPartnerCoursePackage
        /// </summary>
        /// <returns></returns>

        [HttpGet()]
        public ActionResult<PartnerCoursePackagesDTO> GetServiceCatalogController()
        {
            return Ok(_choiceRepoistory.GetPartnerCoursePackages());
        }

        /// <summary>
        /// Get PartnerCoursePackage By ID 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        [HttpGet("{ID}")]
        public ActionResult<IEnumerable<PartnerCoursePackagesDTO>> GetPartnerCoursePackageByID(int ID)
        {
            return _choiceRepoistory.GetPartnerCoursePackages().FindAll(c => c.ID == ID);
        }





        /// <summary>
        /// Update Partner Course Package
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="partnerCoursePackageDTO"></param>
        /// <param name="PartnerCoursePackageDTO"></param>
        /// <returns></returns>

        [HttpPut("{Id}")]
        public IActionResult UpdatePartnerCoursePackage(int Id, [FromBody] PartnerCoursePackagesDTO partnerCoursePackageDTO)
        {
            try
            {
                if (partnerCoursePackageDTO == null)
                {
                    ModelState.AddModelError("partnerCoursePackage", "partnerCoursePackage object can't be null");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var partnerCoursePackageInDb = _choiceRepoistory.GetById<PartnerCoursePackages>(c => c.Id == Id);
                if (partnerCoursePackageInDb == null)
                {
                    ModelState.AddModelError("PartnerCoursePackage", $"Not found with Id {Id}");
                    return NotFound(ModelState);
                }

                partnerCoursePackageInDb.PartnerID = partnerCoursePackageDTO.PartnerID;
                partnerCoursePackageInDb.Offered = partnerCoursePackageDTO.Offered;
                partnerCoursePackageInDb.Price = partnerCoursePackageDTO.Price;
                partnerCoursePackageInDb.ServiceCatalogueID = partnerCoursePackageDTO.ServiceCatalogueID;
                _choiceRepoistory.Attach(partnerCoursePackageInDb);
                _choiceRepoistory.Complete();
                UpdateCoursePackageMenue(partnerCoursePackageDTO, partnerCoursePackageInDb.Id, partnerCoursePackageInDb.PartnerID, partnerCoursePackageInDb.ServiceCatalogueID);
                UpdateCoursePackageFreeServices(partnerCoursePackageDTO, partnerCoursePackageInDb.Id, partnerCoursePackageInDb.PartnerID, partnerCoursePackageInDb.ServiceCatalogueID);
                UpdateCoursePackagePremiumServices(partnerCoursePackageDTO, partnerCoursePackageInDb.Id, partnerCoursePackageInDb.PartnerID,partnerCoursePackageInDb.ServiceCatalogueID);
                UpdateCoursePackageYearPrice(partnerCoursePackageDTO, partnerCoursePackageInDb.Id,partnerCoursePackageInDb.PartnerID,partnerCoursePackageInDb.ServiceCatalogueID);
                UpdateCRMPartnerInfoModificationdate(partnerCoursePackageDTO.PartnerID);
                return NoContent();

            }
            catch (Exception ex)
            {
                // TODO : Add logging and decide on showing ex.message
                return StatusCode(500, "An error occurred while updating PartnerCoursePackage. Please try again or contact adminstrator");
            }
        }

        private void UpdateCRMPartnerInfoModificationdate(int partnerID)
        {
            var partner = _choiceRepoistory.GetById<CRMPartner>(c => c.CRMPartnerId == partnerID);
            partner.PartnerInfoModificationdate = DateTime.UtcNow;
            _choiceRepoistory.Attach(partner);
            _choiceRepoistory.Complete();
        }

        private void UpdateCoursePackageMenue(PartnerCoursePackagesDTO partnerCoursePackageDTO, int Id, int PartnerId, int serviceCatalogueID)
        {
            foreach (var partnercoursePackageMenue in partnerCoursePackageDTO.PartnerCoursePackageMenueList)
            {
                var partnerCoursePackageMenueInDb = _choiceRepoistory.GetById<PartnerCoursePackageMenue>(c => c.CoursePackageMenueID == partnercoursePackageMenue.CoursePackageMenueID
                && c.PartnerID == PartnerId
                && c.ServiceCatalogueID == serviceCatalogueID);
                if (partnerCoursePackageMenueInDb == null)
                {
                    PartnerCoursePackageMenue newpartnercoursePackageMenue = new PartnerCoursePackageMenue
                    {

                        CoursePackageMenueID = partnercoursePackageMenue.CoursePackageMenueID,
                        Include = partnercoursePackageMenue.Include,
                        PartnerID = PartnerId,
                        ServiceCatalogueID = serviceCatalogueID,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now
                    };
                    _choiceRepoistory.Attach<PartnerCoursePackageMenue>(newpartnercoursePackageMenue);
                    _choiceRepoistory.Complete();
                }
                else
                {
                    partnerCoursePackageMenueInDb.CoursePackageMenueID = partnercoursePackageMenue.CoursePackageMenueID;
                    partnerCoursePackageMenueInDb.Include = partnercoursePackageMenue.Include;                
                    _choiceRepoistory.Attach<PartnerCoursePackageMenue>(partnerCoursePackageMenueInDb);
                    _choiceRepoistory.Complete();

                }

            }
        }


        private void UpdateCoursePackageFreeServices(PartnerCoursePackagesDTO partnerCoursePackageDTO, int Id, int PartnerId, int serviceCatalogueID)
        {
            foreach (var partnercoursePackageFreeServices in partnerCoursePackageDTO.PartnerCoursePackageFreeServicesList)
            {
                var partnercoursePackageFreeServicesInDb = _choiceRepoistory.GetById<PartnerCoursePackageFreeServices>(c => c.PartnerCoursePackageFreeServiceID == partnercoursePackageFreeServices.PartnerCoursePackageFreeServiceID
                && c.PartnerID == PartnerId
                && c.ServiceCatalogueID == serviceCatalogueID);
                if (partnercoursePackageFreeServicesInDb == null)
                {
                    PartnerCoursePackageFreeServices newPartnerCoursePackageFreeServices = new PartnerCoursePackageFreeServices
                    {

                        Description = partnercoursePackageFreeServices.Description,
                        PartnerID = PartnerId,
                        ServiceCatalogueID = serviceCatalogueID,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now

                    };
                    _choiceRepoistory.Attach<PartnerCoursePackageFreeServices>(newPartnerCoursePackageFreeServices);
                    _choiceRepoistory.Complete();
                }
                else
                {
                    partnercoursePackageFreeServicesInDb.Description = partnercoursePackageFreeServices.Description;
                    _choiceRepoistory.Attach<PartnerCoursePackageFreeServices>(partnercoursePackageFreeServicesInDb);
                    _choiceRepoistory.Complete();

                }

            }
        }

        private void UpdateCoursePackagePremiumServices(PartnerCoursePackagesDTO partnerCoursePackageDTO, int Id, int PartnerId, int serviceCatalogueID)
        {
            foreach (var partnercoursePackagePremiumServices in partnerCoursePackageDTO.PartnerCoursePackagePremiumServicesList)
            {
                var partnercoursePackagePremiumServicesInDb = _choiceRepoistory.GetById<PartnerCoursePackagePremiumServices>(c => c.PartnerCoursePackagePremiumServiceID == partnercoursePackagePremiumServices.PartnerCoursePackagePremiumServiceID && c.PartnerID== PartnerId && c.ServiceCatalogueID == serviceCatalogueID);
                if (partnercoursePackagePremiumServicesInDb == null)
                {
                    PartnerCoursePackagePremiumServices newPartnerCoursePackagePremiumServices = new PartnerCoursePackagePremiumServices
                    {

                        Description = partnercoursePackagePremiumServices.Description,
                        Price = partnercoursePackagePremiumServices.Price,
                        PartnerID = PartnerId,
                        ServiceCatalogueID = serviceCatalogueID,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now

                    };
                    _choiceRepoistory.Attach<PartnerCoursePackagePremiumServices>(newPartnerCoursePackagePremiumServices);
                    _choiceRepoistory.Complete();
                }
                else
                {
                    partnercoursePackagePremiumServicesInDb.Description = partnercoursePackagePremiumServices.Description;
                    partnercoursePackagePremiumServicesInDb.Price = partnercoursePackagePremiumServices.Price;
                    _choiceRepoistory.Attach<PartnerCoursePackagePremiumServices>(partnercoursePackagePremiumServicesInDb);
                    _choiceRepoistory.Complete();

                }

            }
        }

        private void UpdateCoursePackageYearPrice(PartnerCoursePackagesDTO partnerCoursePackageDTO, int Id , int PartnerId, int serviceCatalogueID)
        {
            foreach (var partnercoursePackageYearPrice in partnerCoursePackageDTO.PartnerCoursePackageYearPriceList)
            {
                var partnercoursePackageYearPriceInDb = _choiceRepoistory.GetById<PartnerCoursePackageYearPrice>(c => c.PartnerCoursePackageYearPriceID==partnercoursePackageYearPrice.PartnerCoursePackageYearPriceID && c.PartnerID == PartnerId && c.ServiceCatalogueID == serviceCatalogueID);
                if (partnercoursePackageYearPriceInDb == null)
                {
                    PartnerCoursePackageYearPrice newPartnerCoursePackageYearPrice = new PartnerCoursePackageYearPrice
                    {

                        Year = partnercoursePackageYearPrice.Year,
                        PricePerPerson = partnercoursePackageYearPrice.PricePerPerson,
                        PartnerID = PartnerId,
                        ServiceCatalogueID = serviceCatalogueID,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now

                    };
                    _choiceRepoistory.Attach<PartnerCoursePackageYearPrice>(newPartnerCoursePackageYearPrice);
                    _choiceRepoistory.Complete();
                }
                else
                {
                    partnercoursePackageYearPriceInDb.Year = partnercoursePackageYearPrice.Year;
                    partnercoursePackageYearPriceInDb.PricePerPerson = partnercoursePackageYearPrice.PricePerPerson;
                    _choiceRepoistory.Attach<PartnerCoursePackageYearPrice>(partnercoursePackageYearPriceInDb);
                    _choiceRepoistory.Complete();

                }

            }
        }




    }
}