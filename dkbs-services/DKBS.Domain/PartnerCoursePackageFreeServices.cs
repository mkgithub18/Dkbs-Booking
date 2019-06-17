using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKBS.Domain
{
   public class PartnerCoursePackageFreeServices
    {
        [Key]
        public int PartnerCoursePackageFreeServiceID { get; set; }
        public int ServiceCatalogueID { get; set; }
        public string Description { get; set; }
        public string PartnerCoursePackageFreeServices_SPID { get; set; }
        public int CRMPartnerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string createdBy { get; set; }
        public string ModifiedBy { get; set; }

    }
}
