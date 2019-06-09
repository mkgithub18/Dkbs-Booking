CREATE TABLE [dbo].[PartnerCenterRoomInfo] (
    [PartnerCenterRoomInfo_Id]  INT            NOT NULL,
    [Room_Name]                 NVARCHAR (50)  NULL,
    [PartnerId]                 INT            NOT NULL,
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
    PRIMARY KEY CLUSTERED ([PartnerCenterRoomInfo_Id] ASC),
    CONSTRAINT [FK_PartnerCenterRoomInfo_Partner] FOREIGN KEY ([PartnerId]) REFERENCES [dbo].[Partner] ([PartnerId])
);


