using System;

namespace DKBS.Domain
{
    public class TableSet
    {
        public int TableSetId { get; set; }
        public string TableSetName { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
    }
}