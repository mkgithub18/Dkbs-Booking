using System;

namespace DKBS.Domain
{
    public class PartnerEmployee
    {      
        public int PartnerEmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string TelePhoneNumber { get; set; }
        public string Email { get; set; }
        public string Partner { get; set; }
        public string MailGroup { get; set; }

        public string PESharePointId { get; set; }
        //public PartnerType PartnerType  { get; set; }
        //public ParticipantType ParticipantType { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }

        public DateTime LastModified { get; set; }
        public string LastModifiedBY { get; set; }

        public DateTime ModifiedOn { get; set; }
        public string ModifiedBY { get; set; }
        public Boolean EmailNotification { get; set; }
        public Boolean SMSNotification { get; set; }
        public string Identifier { get; set; }
        public bool DeactivatedUser { get; set; }
    }

 }
