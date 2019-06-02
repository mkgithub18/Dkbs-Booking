CREATE TABLE [dbo].[Refreshments]
(
	[RefreshmentId] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NULL, 
    [CreatedDate] DATETIME NULL, 
    [CreatedBy] NVARCHAR(50) NULL, 
    [LastModified] DATETIME NULL, 
    [LastModifiedBy] NVARCHAR(50) NULL
)
