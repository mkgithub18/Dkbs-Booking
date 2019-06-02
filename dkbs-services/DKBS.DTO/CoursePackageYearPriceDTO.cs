using System;
using System.Collections.Generic;
using System.Text;

namespace DKBS.DTO
{
    public class CoursePackageYearPriceDTO
    {
        public int CoursePackageYearPriceID { get; set; }
        public int CoursePackageID { get; set; }
        public string Year { get; set; }
        public string SharepointID { get; set; }
        public decimal PricePerPerson { get; set; }      
        
    }
}
