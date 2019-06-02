CREATE TABLE [dbo].[Region]
(
	[RegionId] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(255),
	[CreatedDate] DATETIME NULL,
	[CreatedBy] nvarchar(100),
    [LastModified] DATETIME NULL, 
    [LastModifiedBy] NVARCHAR(100) NULL
)
