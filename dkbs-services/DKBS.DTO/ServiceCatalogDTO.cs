using System;
using System.Collections.Generic;

namespace DKBS.DTO
{
    public class ServiceCatalogueDTO
    {
        public int ServiceCatalogueID { get; set; }
        public string CoursePackageName { get; set; }
        public bool Offered { get; set; }
        public Decimal? Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string LastModifiedBY { get; set; }
        public List<CoursePackageMenueDTO> CoursePackageMenueList { get; set; }

    }
}
