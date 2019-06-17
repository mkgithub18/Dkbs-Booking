using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKBS.Domain
{
   public class PartnerCoursePackagePremiumServices
    {
        [Key]
        public int PartnerCoursePackagePremiumServiceID { get; set; }
        public int ServiceCatalogueID { get; set; }
        public string Description { get; set; }
        public string PartnerCoursePackagePremiumServices_SPID { get; set; }
        public decimal Price { get; set; }
        public int CRMPartnerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string createdBy { get; set; }
        public string ModifiedBy { get; set; }

    }
}
