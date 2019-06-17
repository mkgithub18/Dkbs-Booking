CREATE TABLE [dbo].[PartnerCenterRoomInfo] (
    [PartnerCenterRoomInfoId]   INT            NOT NULL,
    [RoomName]                  NVARCHAR (50)  NULL,
    [CRMPartnerId]                 INT            NOT NULL,
    [PartnerCenterRoomInfoSpId] NVARCHAR (50)  NULL,
    [MaxPersonsAtMeetingTable]  INT            NOT NULL,
    [MaxPersonsAtSchoolTable]   INT            NOT NULL,
    [MaxPersonsAtRowOfChairs]   INT            NOT NULL,
    [MaxPersonsAtIslands]       INT            NOT NULL,
    [MaxPersonsAtUTable]        INT            NOT NULL,
    [Remark]                    NVARCHAR (50)  NULL,
    [IsRoomdividetosmallroom]   BIT            NULL,
    [CreatedDate]               DATETIME       NOT NULL,
    [CreatedBy]                 NVARCHAR (255) NOT NULL,
    [LastModified]              DATETIME       NOT NULL,
    [LastModifiedBY]            NVARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([PartnerCenterRoomInfoId] ASC),
    CONSTRAINT [FK_PartnerCenterRoomInfo_Partner] FOREIGN KEY ([CRMPartnerId]) REFERENCES [dbo].[Partner] ([CRMPartnerId])
);




