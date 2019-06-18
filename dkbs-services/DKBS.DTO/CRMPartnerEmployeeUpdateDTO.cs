using System;
using System.Collections.Generic;
using System.Text;

namespace DKBS.DTO
{
    public class CRMPartnerEmployeeUpdateDTO
    {
        public string partner_contact_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string job_title { get; set; }
        public string telephone { get; set; }
        public string email_address { get; set; }
       // public string parent_customer_id { get; set; }
        public string mail_group { get; set; }
    }
}
