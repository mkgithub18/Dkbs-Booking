using System;

namespace DKBS.DTO
{
    public class CampaignDTO
    {
        public int CampaignId { get; set; }
        public string Name { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}