CREATE TABLE [dbo].[CenterTypes]
(
	[CenterTypeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CenterTypeTitle] NVARCHAR(255) NULL,
	[CreatedDate] DATETIME NULL,
	[CreatedBy] nvarchar(100),
	[LastModified] DATETIME NULL, 
	[LastModifiedBy] NVARCHAR(100) NULL
)
