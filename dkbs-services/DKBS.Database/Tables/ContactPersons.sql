CREATE TABLE [dbo].[ContactPersons]
(
	[ContactPersonId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(255) NULL, 
    [Department] NVARCHAR(255) NULL, 
    [Position] NVARCHAR(255) NULL, 
    [Email] NVARCHAR(255) NULL, 
    [Telephone] NVARCHAR(50) NULL, 
    [Mobile] NVARCHAR(50) NULL,
	[CreatedDate] DATETIME NULL,
	[CreatedBy] nvarchar(100),
	[LastModified] DATETIME NULL, 
	[LastModifiedBy] NVARCHAR(100) NULL
)
