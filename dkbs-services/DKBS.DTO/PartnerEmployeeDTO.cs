using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace DKBS.DTO
{
    public class PartnerEmployeeDTO
    {
        [JsonIgnore]
        public int PartnerEmployeeId { get; set; }

        public string FirstName { get; set; }
       
        public string LastName { get; set; }

        public string JobTitle { get; set; }
        public string TelePhoneNumber { get; set; }
        public string Email { get; set; }
        [Required]
        public string CrmPartnerAccountId { get; set; }
        public string MailGroup { get; set; }
        [Required]
        public string PESharePointId { get; set; }

        public bool EmailNotification { get; set; }

        public bool SMSNotification { get; set; }

        public string Identifier { get; set; }

        public bool DeactivatedUser { get; set; }

        public DateTime? LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
