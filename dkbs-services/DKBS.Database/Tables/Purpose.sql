CREATE TABLE [dbo].[Purpose]
(
	[PurposeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PurposeName] NVARCHAR(255) NULL,
	[CreatedDate] DATETIME NULL,
	[CreatedBy] nvarchar(100),
	[LastModified] DATETIME NULL, 
	[LastModifiedBy] NVARCHAR(100) NULL
)
