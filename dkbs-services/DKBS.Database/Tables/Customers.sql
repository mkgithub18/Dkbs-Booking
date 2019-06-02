CREATE TABLE [dbo].[Customers]
(
	[CustomerId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CustomerName] NVARCHAR(255) NULL,      
    [EmailId] NVARCHAR(255) NULL, 
    [PhoneNumber] NVARCHAR(255) NULL, 
	[IndustryCodeId] INT NOT NULL,
	[Country] NVARCHAR(200) NOT NULL,
	[City] NVARCHAR(200) NOT NULL,
	[CreatedBy] NVARCHAR(200) NOT NULL,	
	[CreatedDate] DATETIME NOT NULL,  
	[LastModifiedDate] DATETIME NOT NULL, 
	[LastModifiedBY] NVARCHAR(255) NOT NULL
	

)
