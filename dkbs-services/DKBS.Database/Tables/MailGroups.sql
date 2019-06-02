CREATE TABLE [dbo].[MailGroups]
(
	[MailGroupId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MailGroupsTitle] NVARCHAR(255) NOT NULL, 
    [InternalName] NVARCHAR(255) NULL, 
    [IncludeInPartnerEmail] BIT NULL, 
    [CreatedDate] DATETIME NULL,
	[CreatedBy] nvarchar(100),
	[LastModified] DATETIME NULL, 
	[LastModifiedBy] NVARCHAR(100) NULL
)
