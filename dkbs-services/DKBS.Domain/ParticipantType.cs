using System;

namespace DKBS.Domain
{
    public class ParticipantType
    {
        public int ParticipantTypeId { get; set; }
        public string ParticipantTypeName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string  CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
    }    
}