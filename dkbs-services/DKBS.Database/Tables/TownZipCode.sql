CREATE TABLE [dbo].[TownZipCode]
(
	[TownZipCodeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ZipPostalCode] NVARCHAR(255) NOT NULL, 
    [FullInfo] NVARCHAR(255) NULL,
	[LandId] INT NULL, 
    [City] NVARCHAR(255) NULL, 
    [LastModified] DATETIME NOT NULL, 
    [LastModifiedBY] NVARCHAR(255) NOT NULL,
	CONSTRAINT [FK_TownZipCodes_Land] FOREIGN KEY ([LandId]) REFERENCES Land([LandId]) 
)
