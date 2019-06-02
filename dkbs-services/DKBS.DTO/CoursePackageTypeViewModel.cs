using System;

namespace DKBS.DTO
{
    public class CoursePackageTypeViewModel
    {
        public string CoursePackageTypeTitle { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}