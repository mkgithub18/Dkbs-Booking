using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DKBS.DTO
{
   public class PartnerInspirationCategoriesDKDTO
    {

        [Key]
        public int PartnerInspirationCategoriesDKId { get; set; }

        public int PartnerId { get; set; }

        public string Heading { get; set; }

        public string Description { get; set; }

        public int? Price { get; set; }

        public bool? ApprovalStatus { get; set; }

        public string PartnerInspirationCategoriesDKSpId { get; set; }

    }
}
