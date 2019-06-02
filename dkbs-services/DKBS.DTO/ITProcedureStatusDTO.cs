using System;

namespace DKBS.DTO
{
    public class ITProcedureStatusDTO
    {
        public int ITProcedureStatusId { get; set; }
        public string ITProcedureStatusTitle { get; set; }
        public string  InternalName { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}