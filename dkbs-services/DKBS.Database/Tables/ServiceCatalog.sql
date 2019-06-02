CREATE TABLE [dbo].[ServiceCatalog]
(
	[ServiceCatalogId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CoursePackage] NVARCHAR(255) NULL, 
	[CoursePackageEng] NVARCHAR(255) NULL, 
    [Offered] BIT NULL,
	[Price] DECIMAL(18, 2) NULL,
	[CoursePackageType] nvarchar(200),
	[CanBePurchased] BIT,
 	[CreatedDate] DATETIME NULL,
	[CreatedBy] nvarchar(100),
	[LastModified] DATETIME NULL, 
	[LastModifiedBy] NVARCHAR(100) NULL
)
