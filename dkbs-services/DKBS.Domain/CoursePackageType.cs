using System;

namespace DKBS.Domain
{
    public class CoursePackageType
    {
        public int CoursePackageTypeId { get; set; }
        public string CoursePackageTypeTitle { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}