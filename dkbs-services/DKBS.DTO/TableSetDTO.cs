using System;

namespace DKBS.DTO
{
    public class TableSetDTO
    {
        public int TableSetId { get; set; }
        public string TableSetName { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
    }
}