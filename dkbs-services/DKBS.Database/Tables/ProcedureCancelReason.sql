CREATE TABLE [dbo].[ProcedureCancelReason]
(
	[ProcedureCancelReasonId] INT NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(200) NULL,
	[CreatedDate] DATETIME NULL,
	[CreatedBy] nvarchar(100),
	[LastModified] DATETIME NULL, 
	[LastModifiedBy] NVARCHAR(100) 
)
