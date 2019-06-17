using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKBS.DTO
{
   public class PartnerCoursePackagesDTO
    {

        public int ID { get; set; }
        public int CRMPartnerId {get; set; }
        public int ServiceCatalogueID { get; set; }
        public bool Offered { get; set; }
        public decimal Price { get; set; }
        public string PartnerCoursePackage_SPID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public List<PartnerCoursePackageMenueDTO> PartnerCoursePackageMenueList { get; set; }
        public List<PartnerCoursePackageFreeServicesDTO> PartnerCoursePackageFreeServicesList { get; set; }
        public List<PartnerCoursePackagePremiumServicesDTO> PartnerCoursePackagePremiumServicesList { get; set; }
        public List<PartnerCoursePackageYearPriceDTO> PartnerCoursePackageYearPriceList { get; set; }
    }
}
