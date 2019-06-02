using System;

namespace DKBS.Domain
{
    public class TableType
    {
        public int TableTypeId { get; set; }
        public string TableTypeName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBY { get; set; }
    }
}