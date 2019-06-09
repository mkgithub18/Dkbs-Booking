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
    /// EmailConversationController
    /// </summary>
    /// 

    [Route("api/[controller]")]
    [ApiController]
    public class SRInternalNotifyController : Controller
    {
        private IChoiceRepository _choiceRepoistory;

        /// <summary>
        /// PartnerCenterInfo_Id
        /// </summary>
        /// <param name="choiceRepoistory"></param>
        public SRInternalNotifyController(IChoiceRepository choiceRepoistory)
        {
            _choiceRepoistory = choiceRepoistory;
        }

        /// <summary>
        /// Get All PartnerCenterInfo
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public ActionResult<SRInternalNotifyDTO> GetSRInternalNotify()
        {
            return Ok(_choiceRepoistory.GetSRInternalNotify());
        }


        /// <summary>
        /// Get SRInternalNotifyDTO by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns> 
        [Route("ID")]
        [HttpGet()]
        public ActionResult<SRInternalNotifyDTO> GetById(int ID)
        {
            return _choiceRepoistory.GetSRInternalNotify().FirstOrDefault(c => c.ID == ID);
        }

     

    }
}
