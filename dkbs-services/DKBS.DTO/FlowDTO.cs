using System;

namespace DKBS.DTO
{
    public class FlowDTO
    {
        public int FlowId { get; set; }
        public string FlowName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
    }
}