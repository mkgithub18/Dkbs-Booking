CREATE TABLE [dbo].[IndustryCode]
(
	[IndustryCodeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IsNewBranch] BIT NULL, 
    [IndustryCodeTitle] NVARCHAR(255) NULL,
	[CreatedDate] DATETIME NULL,
	[CreatedBy] nvarchar(100),
	[LastModified] DATETIME NULL, 
	[LastModifiedBy] NVARCHAR(100) NULL
)
