CREATE TABLE [dbo].[ProcedureReviewType]
(
	[ProcedureReviewTypeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProcedureReviewTypeTitle] NVARCHAR(255) NOT NULL, 
    [CreatedDate] DATETIME NULL,
	[CreatedBy] nvarchar(100),
    [LastModified] DATETIME NULL, 
    [LastModifiedBy] NVARCHAR(100) NULL
)
