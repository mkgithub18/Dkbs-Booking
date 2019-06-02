using System;

namespace DKBS.Domain
{
    public class ContactPerson
    {
        public int ContactPersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string MobilePhone { get; set; }
        public string AccountId { get; set; }
        public string ContactId { get; set; }
        public int? SharePointId { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}