using System;
using System.Collections.Generic;
using System.Text;

namespace DKBS.DTO
{
    public class PartnerInspirationCategoriesUKDTO
    {
        //public int PartnerInspirationCategories_Id { get; set; }
        //public int PartnerId { get; set; }
        //public string Room_Name { get; set; }
        //public int Price { get; set; }
        //public Boolean Approval_Status { get; set; }
        //public DateTime LastModified { get; set; }

        public int PartnerInspirationCategoriesUK_Id { get; set; }

        public int PartnerId { get; set; }

        public string Heading { get; set; }

        public string Description { get; set; }

        public int? Price { get; set; }

        public string PartnerInspirationCategoriesSpId { get; set; }
        public bool? ApprovalStatus { get; set; }

    }
}
