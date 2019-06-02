using System;

namespace DKBS.DTO
{
    public class ServiceCatalogViewModel
    {
        public string CoursePackage { get; set; }
        public bool Offered { get; set; }
        public Decimal? Price { get; set; }
        public CoursePackageTypeViewModel CoursePackageTypeViewModel { get; set; }
        public DateTime? LastModified { get; set; }
        public string LastModifiedBY { get; set; }
    }
}