using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DKBS.Domain
{
    public class PartnerInspirationCategoriesUK
    {


        //public int PartnerInspirationCategories_Id { get; set; }
        //public int CRMPartnerId { get; set; }
        //public string Room_Name { get; set; }
        //public int Price { get; set; }
        //public Boolean Approval_Status { get; set; }
        //public DateTime LastModified { get; set; }
        //public string LastModifiedBY { get; set; }


        [Key]
        public int PartnerInspirationCategoriesUKId { get; set; }

        public int CRMPartnerId { get; set; }

        public string Heading { get; set; }

        public string Description { get; set; }

        public int? Price { get; set; }

        public bool? ApprovalStatus { get; set; }

        public string PartnerInspirationCategoriesSpId { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastModified { get; set; }

        public string LastModifiedBY { get; set; }


    }
}
