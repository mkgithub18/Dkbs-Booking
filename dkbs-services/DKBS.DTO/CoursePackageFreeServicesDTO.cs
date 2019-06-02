using System;
using System.Collections.Generic;
using System.Text;

namespace DKBS.DTO
{
   public class CoursePackageFreeServicesDTO
    {
        public int CoursePackageFreeServiceID { get; set; }
        public int CoursePackageID { get; set; }
        public string Description { get; set; }
        public string SharepointID { get; set; }      
     
    }
}