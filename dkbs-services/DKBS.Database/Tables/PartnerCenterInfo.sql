CREATE TABLE [dbo].[PartnerCenterInfo] (
    [PartnerCenterInfoId]               INT            IDENTITY (1, 1) NOT NULL,
    [TotalRooms]                        INT            NULL,
    [GroupRooms]                        INT            NULL,
    [MaxSpaceAtRowOfChairs]             NVARCHAR (50)  NULL,
    [MaxspaceAtTables]                  NVARCHAR (50)  NULL,
    [StateAgreement]                    BIT            NULL,
    [MaxAccommodation]                  NVARCHAR (50)  NULL,
    [PartnerId]                         INT            NULL,
    [PartnerCenfoInfoSPId]              NVARCHAR (50)  NULL,
    [NumberOfSingleRooms]               INT            NULL,
    [NumberOfDoubleRooms]               INT            NULL,
    [Suite]                             INT            NULL,
    [DistanceToAddtiionalAccommodation] INT            NULL,
    [Chamber]                           INT            NULL,
    [HandicapRooms]                     INT            NULL,
    [MaximumNumberOfVisitors]           INT            NULL,
    [MaxDiningPlacesInRestaurant]       INT            NULL,
    [MaxDiningPlacesInRoom]             INT            NULL,
    [MaxSpaceInAuditorium]              INT            NULL,
    [MinParticipants]                   INT            NULL,
    [AirportDistance]                   INT            NULL,
    [StationDdistance]                  INT            NULL,
    [DistanceToBus]                     INT            NULL,
    [DistanceToMotorway]                INT            NULL,
    [NumberOfFreeParkingSpaces]         INT            NULL,
    [DistanceToFreeParking]             INT            NULL,
    [NumberOfParkingSpaces]             INT            NULL,
    [DistanceToPayParking]              INT            NULL,
    [EnvironmentalCertificate]          BIT            NULL,
    [AgreementForEmployees]             BIT            NULL,
    [Handicapfriendly]                  BIT            NULL,
    [RegionsAgreement]                  BIT            NULL,
    [Bar]                               BIT            NULL,
    [Lounge]                            BIT            NULL,
    [BilliardsDartTableTennis]          BIT            NULL,
    [Spa]                               BIT            NULL,
    [Pool]                              BIT            NULL,
    [FitnessRoom]                       BIT            NULL,
    [Casino]                            BIT            NULL,
    [DiningArea]                        INT            NULL,
    [GreenArea]                         BIT            NULL,
    [Golf]                              BIT            NULL,
    [AirCondition]                      BIT            NULL,
    [CookingSchool]                     BIT            NULL,
    [NoOfRooms]                         INT            NULL,
    [Auditoriums]                       INT            NULL,
    [ApprovalStatus]                    INT            NULL,
    [CreatedDate]                       DATETIME       NOT NULL,
    [CreatedBy]                         NVARCHAR (255) NOT NULL,
    [LastModified]                      DATETIME       NOT NULL,
    [LastModifiedBY]                    NVARCHAR (255) NOT NULL,
    [PartnerCenterRoomInfospID]         INT            NULL,
    PRIMARY KEY CLUSTERED ([PartnerCenterInfoId] ASC)
);










