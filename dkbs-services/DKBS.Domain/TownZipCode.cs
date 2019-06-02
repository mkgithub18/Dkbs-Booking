using System;

namespace DKBS.Domain
{
    public class TownZipCode
    {
        public int TownZipCodeId { get; set; }
        public string ZipPostalCode { get; set; }
        public string FullInfo { get; set; }
        public Land Land { get; set; }
        public string City { get; set; }
        public DateTime LastModified { get; set; }       
        public string LastModifiedBY { get; set; }
    }
}