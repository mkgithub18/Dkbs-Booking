using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace DKBS.DTO
{
    public class PartnerEmployeeDTO
    {
        [JsonIgnore]
        public int PartnerEmployeeId { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string TelePhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string CrmPartnerAccountId { get; set; }
        [Required]
        public string MailGroup { get; set; }
        [Required]
        public string PESharePointId { get; set; }
        [Required]
        public bool EmailNotification { get; set; }
        [Required]
        public bool SMSNotification { get; set; }
        [Required]
        public string Identifier { get; set; }
        [Required]
        public bool DeactivatedUser { get; set; }
    }
}
