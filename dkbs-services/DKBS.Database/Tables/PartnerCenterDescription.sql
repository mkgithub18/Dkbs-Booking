CREATE TABLE [dbo].[PartnerCenterDescription]
(
	[PartnerCenterDescription_Id] INT NOT NULL PRIMARY KEY, 
    [PartnerId] INT NOT NULL, 
    [Rooms] NVARCHAR(50) NULL, 
    [Capacity] NVARCHAR(50) NULL, 
    [Facilities] NVARCHAR(50) NULL, 
    [Activities] NVARCHAR(50) NULL, 
    [ApprovalStatus] BIT NULL, 
    [TextforQuotationforEmail] NVARCHAR(50) NULL, 
    [Transportation] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(50) NULL,
	CONSTRAINT [FK_PartnerCenterDescription_Partner] FOREIGN KEY ([PartnerId]) REFERENCES [Partner]([PartnerId]),
)
