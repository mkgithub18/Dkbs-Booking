CREATE TABLE [dbo].[ITProcedureStatus]
(
	[ITProcedureStatusId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ITProcedureStatusTitle] NVARCHAR(100) NULL, 
    [InternalName] NVARCHAR(255) NULL,
	[CreatedDate] DATETIME NULL,
	[CreatedBy] nvarchar(100),
	[LastModified] DATETIME NULL, 
	[LastModifiedBy] NVARCHAR(100) NULL
)
