using System;

namespace DKBS.Domain
{
    public class ServiceCatalogue
    {
        public int ServiceCatalogueID { get; set; }
        public string CoursePackageName { get; set; }
        public bool Offered { get; set; }
        public Decimal? Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string LastModifiedBY { get; set; }

    }

}
