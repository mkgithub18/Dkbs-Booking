using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DKBS.Domain
{
   public class CoursePackagePremiumServices
    {
        [Key]
        public int CoursePackagePremiumServiceID { get; set; }
        public int CoursePackageID { get; set; }
        public string Description { get; set; }
        public string SharepointID { get; set; }
        public decimal Price { get; set; }
    }
}
