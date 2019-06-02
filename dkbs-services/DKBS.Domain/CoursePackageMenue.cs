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
        public int CoursePackageID { get; set; }
        public string Description { get; set; }
        public bool Include { get; set; }
        public int Order { get; set; }
        public string SharepointID { get; set; }
    }
}
