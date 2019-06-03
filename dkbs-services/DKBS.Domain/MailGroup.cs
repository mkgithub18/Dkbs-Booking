using System;

namespace DKBS.Domain
{
    public class MailGroup
    {
        public int MailGroupId { get; set; }
        public string MailGroupsTitle { get; set; }
        public string InternalName { get; set; }
        public bool IncludeInPartnerEmail { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
    }
}