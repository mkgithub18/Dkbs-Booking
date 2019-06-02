using System;
using System.Collections.Generic;
using System.Text;

namespace DKBS.DTO
{
    public class PartnerCenterRoomInfoDTO
    {
        public int PartnerCenterRoomInfo_Id { get; set; }

        public string Room_Name { get; set; }

        public int PartnerId { get; set; }

        public string PartnerCenterRoomInfoSpId { get; set; }

        public int MaxPersonsAtMeetingTable { get; set; }

        public int MaxPersonsAtSchoolTable { get; set; }

        public int MaxPersonsAtRowOfChairs { get; set; }

        public int MaxPersonsAtIslands { get; set; }

        public int MaxPersonsAtUTable { get; set; }

        public string Remark { get; set; }

        public bool? IsRoomdividetosmallroom { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastModified { get; set; }

        public string LastModifiedBY { get; set; }

        //public int PartnerCenterRoomInfo_Id { get; set; }
        //public int PartnerId { get; set; }
        //public string Room_Name { get; set; }
        ////public DateTime LastModified { get; set; }
        ////public string LastModifiedBY { get; set; }
        //public string PartnerCenterRoomInfoSpId { get; set; }
    }
}
