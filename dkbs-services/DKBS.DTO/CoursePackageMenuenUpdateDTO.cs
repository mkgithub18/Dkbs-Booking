using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DKBS.DTO
{
   public class CoursePackageMenuenUpdateDTO
    {
        public int CoursePackageMenueID { get; set; }
        public int ServiceCatalogueID { get; set; }
        [Required(ErrorMessage = "CoursePackage ID  is required.")]
        public int CoursePackageID { get; set; }
        public string Description { get; set; }
        public bool Include { get; set; }
        public int Order { get; set; }
        public string SharepointID { get; set; }

    }
}
