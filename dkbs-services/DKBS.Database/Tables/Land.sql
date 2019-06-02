CREATE TABLE [dbo].[Land]
(
	[LandId] INT NOT NULL PRIMARY KEY IDENTITY,
    [LandTitle] NVARCHAR(255) NULL,
	[CreatedDate] DATETIME NULL,
	[CreatedBy] nvarchar(100),
	[LastModified] DATETIME NULL, 
	[LastModifiedBy] NVARCHAR(100) NULL
)
