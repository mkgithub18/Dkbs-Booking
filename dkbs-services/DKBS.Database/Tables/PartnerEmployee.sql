CREATE TABLE [dbo].[PartnerEmployee]
(
	[PartnerEmployeeId] INT NOT NULL PRIMARY KEY IDENTITY,
    [FirstName] NVARCHAR(255) NOT NULL,
	[LastName] NVARCHAR(255) NOT NULL,
	[JobTitle] NVARCHAR(255) NOT NULL,
	[TelePhoneNumber] NVARCHAR(255) NOT NULL,
	[Email] NVARCHAR(255) NOT NULL,
	[PESharePointId] NVARCHAR(255) NOT NULL,
    [CrmPartnerAccountId] NVARCHAR(100)  NOT NULL,
	[MailGroup] NVARCHAR(255) NOT NULL,		
	[EmailNotification] bit NOT NULL,
	[SMSNotification] bit NOT NULL, 
    [Identifier] NVARCHAR(255) NOT NULL, 
	[DeactivatedUser] bit NOT NULL, 
	[CreatedDate] DATETIME NULL,
	[CreatedBy] nvarchar(100),
	[LastModified] DATETIME NULL, 
	[LastModifiedBy] NVARCHAR(100) NULL
    CONSTRAINT [FK_PartnerEmployee_CRMPartner] FOREIGN KEY ([CrmPartnerAccountId]) REFERENCES [CRMPartner]([AccountId]),
    
)
