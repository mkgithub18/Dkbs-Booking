CREATE TABLE [dbo].[ParticipantType]
(
	[ParticipantTypeId] INT NOT NULL PRIMARY KEY IDENTITY,
	[ParticipantTypeName] NVARCHAR(255) NOT NULL,
	[CreatedDate] DATETIME NULL,
	[CreatedBy] NVARCHAR(100)NULL,
    [LastModified] DATETIME NULL, 
    [LastModifiedBy] NVARCHAR(100) NULL
)
