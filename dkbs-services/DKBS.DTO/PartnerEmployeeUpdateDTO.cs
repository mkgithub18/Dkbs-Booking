using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKBS.DTO
{
    public class PartnerEmployeeUpdateDTO
    {
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
        public Boolean EmailNotification { get; set; }
        [Required]
        public Boolean SMSNotification { get; set; }
        [Required]
        public string Identifier { get; set; }
        [Required]
        public bool DeactivatedUser { get; set; }
    }
}
