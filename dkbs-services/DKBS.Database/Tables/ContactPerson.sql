CREATE TABLE [dbo].[ContactPerson]
(
	[ContactPersonId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](255) NOT NULL,
	[LastName] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Telephone] [nvarchar](50) NOT NULL,
	[MobilePhone] NVARCHAR(50) NULL, 
    [AccountId] NVARCHAR(255) NOT NULL, 
    [ContactId] NVARCHAR(255) UNIQUE NOT NULL,
	[SharePointId] INT NULL,
	[CreatedDate] DATETIME NULL,
	[CreatedBy] nvarchar(100),
	[LastModified] DATETIME NULL, 
	[LastModifiedBy] NVARCHAR(100) NULL
)
