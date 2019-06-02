CREATE TABLE [dbo].[PartnerCenterRoomInfo]
(
	[PartnerCenterRoomInfo_Id] INT NOT NULL PRIMARY KEY, 
    [Room Name] NVARCHAR(50) NULL, 
    [PartnerId] INT NOT NULL,
	CONSTRAINT [FK_PartnerCenterRoomInfo_Partner] FOREIGN KEY ([PartnerId]) REFERENCES [Partner]([PartnerId]),
)
