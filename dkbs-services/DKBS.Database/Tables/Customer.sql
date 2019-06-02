CREATE TABLE [dbo].[Customer]
(
	[CustomerId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](255) NOT NULL,
	[Address1] [nvarchar](255) NOT NULL,
	[Address2] [nvarchar](255) NULL,
	[Town] [nvarchar](200) NOT NULL,
	[PostNumber] [nvarchar](100) NOT NULL,
	[PhoneNumber] [nvarchar](255) NULL,
	[Country] [nvarchar](200) NULL,
	[StateAgreement] BIT NULL,
	[AccountId] NVARCHAR(255) UNIQUE NOT NULL,
	[IndustryCode] NVARCHAR(1000) NOT NULL,
	[SharePointId] INT NULL,
	[CreatedDate] DATETIME NULL,
	[CreatedBy] nvarchar(100),
	[LastModified] DATETIME NULL, 
	[LastModifiedBy] NVARCHAR(100) NULL
)
