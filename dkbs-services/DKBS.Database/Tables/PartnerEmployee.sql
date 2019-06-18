CREATE TABLE [dbo].[PartnerEmployee]
(
	[PartnerEmployeeId] INT NOT NULL PRIMARY KEY IDENTITY,
    [FirstName] NVARCHAR(255) NULL,
	[LastName] NVARCHAR(255) NULL,
	[JobTitle] NVARCHAR(255) NULL,
	[TelePhoneNumber] NVARCHAR(255) NULL,
	[Email] NVARCHAR(255) NULL,
	[PESharePointId] NVARCHAR(255) NOT NULL,
    [CrmPartnerAccountId] NVARCHAR(100)  NOT NULL,
	[MailGroup] NVARCHAR(255) NULL,		
	[EmailNotification] bit NULL,
	[SMSNotification] bit NULL, 
    [Identifier] NVARCHAR(255) NULL, 
	[DeactivatedUser] bit NULL, 
	[CreatedDate] DATETIME NULL,
	[CreatedBy] nvarchar(100),
	[LastModified] DATETIME NULL, 
	[LastModifiedBy] NVARCHAR(100) NULL
    CONSTRAINT [FK_PartnerEmployee_CRMPartner] FOREIGN KEY ([CrmPartnerAccountId]) REFERENCES [CRMPartner]([AccountId]),
    
)
