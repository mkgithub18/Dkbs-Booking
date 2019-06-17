using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKBS.DTO
{
    public class DKBSPartnerDetailsDTO
    {
        public List<PartnerCenterInfoDTO> PartnerCenterInfoList { get; set; }
        public List<PartnerCenterRoomInfoDTO> PartnerCenterRoomInfoList { get; set; }
        public List<PartnerCenterDescriptionDTO> PartnerCenterDescriptionList { get; set; }
        public List<PartnerCoursePackagesDTO> PartnerCoursePackagesList { get; set; }
        public List<PartnerEmployeeDTO> PartnerEmployeeList { get; set; }
        public List<PartnerInspirationCategoriesDKDTO> PartnerInspirationCategoriesDK { get; set; }
        public List<PartnerInspirationCategoriesUKDTO> PartnerInspirationCategoriesUK { get; set; }

    }
}
