CREATE TABLE [dbo].[MailLanguages]
(
	[MailLanguageId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Language] NVARCHAR(255) NULL,
	[CreatedDate] DATETIME NULL,
	[CreatedBy] nvarchar(100),
	[LastModified] DATETIME NULL, 
	[LastModifiedBy] NVARCHAR(100) NULL

)
