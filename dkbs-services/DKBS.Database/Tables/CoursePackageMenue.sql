CREATE TABLE [dbo].CoursePackageMenue
(
	[CoursePackageMenueID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ServiceCatalogueID] INT NULL, 
    [CoursePackageID] INT NULL, 
    [Description] VARCHAR(MAX) NULL, 
    [Include] BIT NULL, 
    [Order] INT NULL, 
    [SharepointID] VARCHAR(MAX) NULL
)
