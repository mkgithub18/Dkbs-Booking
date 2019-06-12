using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DKBS.Domain
{
    public class PartnerCenterInfo
    {
        //[Key]
        //public int PartnerCenterInfo_Id { get; set; }
        //public int Total_Rooms { get; set; }
        //public int Group_Rooms { get; set; }
        //public DateTime LastModified { get; set; }
        //public string Max_space_at_row_of_chairs { get; set; }
        //public string Maxspace_at_tables { get; set; }
        //public Boolean State_agreement { get; set; }
        //public int MaxAccommodation { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime CreatedDate { get; set; }

        //[Key]
        //public int PartnerCenterInfo_Id { get; set; }
        //public int Total_Rooms { get; set; }
        //public int Group_Rooms { get; set; }
        ////  public DateTime LastModified { get; set; }
        //public string Max_space_at_row_of_chairs { get; set; }
        //public string Maxspace_at_tables { get; set; }
        //public Boolean State_agreement { get; set; }
        //public string MaxAccommodation { get; set; }
        //public int PartnerId { get; set; }
        //public string PartnerCenfoInfoSPId { get; set; }

        [Key]
        public int PartnerCenterInfoId { get; set; }

        public int? TotalRooms { get; set; }

        public int? GroupRooms { get; set; }

        public string MaxSpaceAtRowOfChairs { get; set; }

        public string MaxspaceAtTables { get; set; }

        public bool? StateAgreement { get; set; }

        public string MaxAccommodation { get; set; }

        public int? PartnerId { get; set; }

        public string PartnerCenfoInfoSPId { get; set; }

        public int? NumberOfSingleRooms { get; set; }

        public int? NumberOfDoubleRooms { get; set; }

        public int? Suite { get; set; }

        public int? DistanceToAddtiionalAccommodation { get; set; }

        public int? Chamber { get; set; }

        public int? HandicapRooms { get; set; }

        public int? MaximumNumberOfVisitors { get; set; }

        public int? MaxDiningPlacesInRestaurant { get; set; }

        public int? MaxDiningPlacesInRoom { get; set; }

        public int? MaxSpaceInAuditorium { get; set; }

        public int? MinParticipants { get; set; }

        public int? AirportDistance { get; set; }

        public int? StationDdistance { get; set; }

        public int? DistanceToBus { get; set; }

        public int? DistanceToMotorway { get; set; }

        public int? NumberOfFreeParkingSpaces { get; set; }

        public int? DistanceToFreeParking { get; set; }

        public int? NumberOfParkingSpaces { get; set; }

        public int? DistanceToPayParking { get; set; }

        public bool? EnvironmentalCertificate { get; set; }

        public bool? AgreementForEmployees { get; set; }

        public bool? Handicapfriendly { get; set; }

        public bool? RegionsAgreement { get; set; }

        public bool? Bar { get; set; }

        public bool? Lounge { get; set; }

        public bool? BilliardsDartTableTennis { get; set; }        

        public bool? Spa { get; set; }

        public bool? Pool { get; set; }

        public bool? FitnessRoom { get; set; }

        public bool? Casino { get; set; }

        public int? DiningArea { get; set; }

        public bool? GreenArea { get; set; }

        public bool? Golf { get; set; }

        public bool? AirCondition { get; set; }

        public bool? CookingSchool { get; set; }

        public int? NoOfRooms { get; set; }

        public int? Auditoriums { get; set; }

        public bool? ApprovalStatus { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastModified { get; set; }

        public string LastModifiedBY { get; set; }


    }
}
