using System;

namespace DKBS.Domain
{
    public class MailLanguage
    {
        public int MailLanguageId { get; set; }
        public string Language { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
    }
}