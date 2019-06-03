CREATE TABLE [dbo].[CancellationReasons]
(
	[CancellationReasonId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CancellationReasonName] NVARCHAR(255) NULL,
	[CreatedDate] DATETIME NULL,
	[CreatedBy] nvarchar(100),
	[LastModified] DATETIME NULL, 
	[LastModifiedBy] NVARCHAR(100) NULL
)
