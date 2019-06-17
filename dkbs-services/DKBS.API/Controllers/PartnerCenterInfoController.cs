﻿using DKBS.Domain;
using DKBS.DTO;
using DKBS.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DKBS.API.Controllers
{
    /// <summary>
    /// PartnerCenterInfoController
    /// </summary>
    /// 

    [Route("api/[controller]")]
    [ApiController]
    public class PartnerCenterInfoController : Controller
    {
        private IChoiceRepository _choiceRepoistory;

        /// <summary>
        /// PartnerCenterInfo_Id
        /// </summary>
        /// <param name="choiceRepoistory"></param>
        public PartnerCenterInfoController(IChoiceRepository choiceRepoistory)
        {
            _choiceRepoistory = choiceRepoistory;
        }

        /// <summary>
        /// Get All PartnerCenterInfo
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public ActionResult<PartnerCenterInfoDTO> GetPartnerCenterInfo()
        {
            return Ok(_choiceRepoistory.GetPartnerCenterInfo());
        }

        /// <summary>
        /// Get PartnerCenterInfo_Id by id
        /// </summary>
        /// <param name="PartnerCenterInfo_Id"></param>
        /// <returns></returns>
        [HttpGet("{PartnerCenterInfo_Id}")]
        public ActionResult<PartnerCenterInfoDTO> GetPartnerCenterInfo(int PartnerCenterInfo_Id)
        {
            return _choiceRepoistory.GetPartnerCenterInfo().FirstOrDefault(c => c.PartnerCenterInfoId == PartnerCenterInfo_Id);
        }


        /// <summary>
        /// Get PartnerCenterInfo_Id by CRMPartnerId
        /// </summary>
        /// <param name="CRMPartnerId"></param>
        /// <returns></returns> 
        [Route("GetByCRMPartnerId")]
        [HttpGet()]
        public ActionResult<PartnerCenterInfoDTO> GetById(int CRMPartnerId)
        {
            return _choiceRepoistory.GetPartnerCenterInfo().FirstOrDefault(c => c.CRMPartnerId == CRMPartnerId);
        }

        /// <summary>
        /// Update UpdatePartnerCenterInfo
        /// </summary>
        /// <param name="PartnerCenterInfo_Id"></param>
        /// <param name="partnerCenterInfoDTO"></param>
        /// <returns></returns>

        //[HttpPut("{PartnerCenterInfo_Id}")]
        [HttpPut()]
        [Route("UpdatePartnerCenterInfo/{PartnerCenterInfo_Id:int}")]
        public IActionResult UpdatePartnerCenterInfo(int PartnerCenterInfo_Id, [FromBody] PartnerCenterInfoDTO partnerCenterInfoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (partnerCenterInfoDTO == null)
                return BadRequest();

            var PartnerCenterInfo = _choiceRepoistory.GetPartnerCenterInfo().Find(c => c.PartnerCenterInfoId == PartnerCenterInfo_Id);

            if (PartnerCenterInfo == null)
            {
                return BadRequest();
            }

            PartnerCenterInfo = partnerCenterInfoDTO;

            _choiceRepoistory.Complete();
            UpdateCRMPartnerInfoModificationdate(partnerCenterInfoDTO.CRMPartnerId);
            return NoContent();
        }
        
        private void UpdateCRMPartnerInfoModificationdate(int? CRMPartnerId)
        {
            var partner = _choiceRepoistory.GetById<CRMPartner>(c => c.CRMCRMPartnerId == CRMPartnerId);
            partner.PartnerInfoModificationdate = DateTime.UtcNow;
            _choiceRepoistory.Attach(partner);
            _choiceRepoistory.Complete();
        }

    }


}
