CREATE TABLE [dbo].[CrmStatus]
(
	[CrmStatusId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CrmStatusTitle] NVARCHAR(255) NULL,
	[CreatedDate] DATETIME NULL,
	[CreatedBy] nvarchar(100),
	[LastModified] DATETIME NULL, 
	[LastModifiedBy] NVARCHAR(100) NULL
)
