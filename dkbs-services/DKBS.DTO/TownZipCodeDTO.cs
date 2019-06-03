using System;

namespace DKBS.DTO
{
    public class TownZipCodeDTO
    {
        public int TownZipCodeId { get; set; }
        public string ZipPostalCode { get; set; }
        public string FullInfo { get; set; }
        public LandDTO LandDTO { get; set; }
        public string City { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBY { get; set; }
    }
}