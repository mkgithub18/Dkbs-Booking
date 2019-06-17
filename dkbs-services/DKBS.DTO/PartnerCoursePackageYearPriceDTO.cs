using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKBS.DTO
{
  public  class PartnerCoursePackageYearPriceDTO
    {
        public int PartnerCoursePackageYearPriceID { get; set; }
        public int ServiceCatalogueID { get; set; }
        public string Year { get; set; }
        public string PartnerCoursePackageYearPrice_SPID { get; set; }
        public decimal PricePerPerson { get; set; }
        public int CRMPartnerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string createdBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
