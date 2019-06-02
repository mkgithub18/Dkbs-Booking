using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DKBS.Domain
{
    public class CoursePackageFreeServices
    {
        [Key]
        public int CoursePackageFreeServiceID { get; set; }
        public int CoursePackageID { get; set; }
        public string Description { get; set; }
        public string SharepointID { get; set; }



    }
}
