CREATE TABLE [dbo].[Flow]
(
	[FlowId] INT NOT NULL PRIMARY KEY IDENTITY,
	[FlowName] NVARCHAR(255),
	[CreatedDate] DATETIME NULL,
	[CreatedBy] nvarchar(100),
	[LastModified] DATETIME NULL, 
	[LastModifiedBy] NVARCHAR(100) NULL
)
