CREATE TABLE [dbo].[PartnerTypes]
(
	[PartnerTypeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PartnerTypeTitle] NVARCHAR(255) NULL,
	[CreatedDate] DATETIME NULL,
	[CreatedBy] nvarchar(100),
	[LastModified] DATETIME NULL, 
	[LastModifiedBy] NVARCHAR(100) NULL
)
