CREATE TABLE [dbo].[Refreshment]
(
	[RefreshmentId] INT NOT NULL PRIMARY KEY Identity,
	[Name] Nvarchar(255),
    [CreatedDate] DATETIME NULL,
	[CreatedBy] nvarchar(100),
	[LastModified] DATETIME NULL, 
	[LastModifiedBy] NVARCHAR(100) NULL
)
