using System;

namespace DKBS.DTO
{
    public class ServiceCatalogDTO
    {
        public int ServiceCatalogId { get; set; }
        public string CoursePackage { get; set; }
        public string CoursePackageEng { get; set; }
        public bool Offered { get; set; }
        public Decimal? Price { get; set; }
        // public CoursePackageTypeDTO CoursePackageTypeDTO { get; set; }
        public string CoursePackageType { get; set; }
        public bool CanBePurchased { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string LastModifiedBY { get; set; }        
     
    }
}
