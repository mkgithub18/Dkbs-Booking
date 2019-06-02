using System;
using System.Collections.Generic;
using System.Text;

namespace DKBS.Domain
{
    public class SCPartnerCoursePackageMapping
    {
        public int ID { get; set; }
        public int ServiceCatalogueID { get; set; }
        public int CoursePackageID { get; set; }
        public int ParterID { get; set; }
        public int CoursePackageFreeServiceID { get; set; }
        public int CoursePackageYearPriceID { get; set; }
        public int CoursePackagePremiumServiceID { get; set; }
        public int CoursePackageMenueID { get; set; }
        public bool Offered { get; set; }
    }
}
