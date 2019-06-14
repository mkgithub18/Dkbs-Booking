CREATE TABLE [dbo].[ProcedureReply]
(
	[ProcedureReplyId] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(200) NULL,
	[CreatedDate] DATETIME NULL,
	[CreatedBy] nvarchar(100),
	[LastModified] DATETIME NULL, 
	[LastModifiedBy] NVARCHAR(100) NULL
)
