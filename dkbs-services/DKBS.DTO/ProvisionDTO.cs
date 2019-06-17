﻿using System;

namespace DKBS.DTO
{
    public class ProvisionDTO
    {
        //public int ProvisionId { get; set; }
        //public decimal Price { get; set; }
        //public BookingDTO BookingDTO { get; set; }
        //public CustomerDTO CustomerDTO { get; set; }
        //public PartnerDTO PartnerDTO { get; set; }
        //public DateTime LastModified { get; set; }
        //public string LastModifiedBy { get; set; }

        public int ProvisionId { get; set; }
        public int CRMPartnerId { get; set; }
        public int CustomerId { get; set; }
        public int BookingId { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? DateofShipment { get; set; }
        public string Debtor { get; set; }
        public string ProvisionName { get; set; }
        public int UnitID { get; set; }
        public string CreatedBy { get; set; }
        public int ProvisionSpID { get; set; }
        public string LastModified { get; set; }
        public string LastModifiedBy { get; set; }

    }
}