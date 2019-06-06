using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DKBS.Domain
{
    public class CoursePackageMenue
    {
        [Key]
        public int CoursePackageMenueID { get; set; }
        public int ServiceCatalogueID { get; set; }
        public string Description { get; set; }
        public bool Include { get; set; }
        public int Order { get; set; }
       // public int CoursePackageID { get; set; }  
        public string CoursePackageMenue_SPID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModified { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBY { get; set; }

    }
}
