CREATE TABLE [dbo].[CenterMatchings]
(
	[CenterMatchingId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MatchingCenter] NVARCHAR(255) NULL,
	[CreatedDate] DATETIME NULL,
	[CreatedBy] nvarchar(100),
	[LastModified] DATETIME NULL, 
	[LastModifiedBy] NVARCHAR(100) NULL
)
