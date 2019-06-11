using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKBS.DTO
{
   public class PartnerCoursePackageMenueDTO
    {
        public int PartnerCoursePackageMenueID { get; set; }
        public int ServiceCatalogueID { get; set; }
        public bool Include { get; set; }
        public int PartnerID { get; set; }
        public int CoursePackageMenueID { get; set; }
        public string PartnerCoursePakageMenue_SPID { get; set; } 
        public DateTime CreatedDate { get; set; }
        public string createdBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
    }
}
