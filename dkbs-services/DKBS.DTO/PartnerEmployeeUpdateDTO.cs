using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKBS.DTO
{
    public class PartnerEmployeeUpdateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string TelePhoneNumber { get; set; }
        public string Email { get; set; }
        public string CrmPartnerAccountId { get; set; }
        public string MailGroup { get; set; }
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
