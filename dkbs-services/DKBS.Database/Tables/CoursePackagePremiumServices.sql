CREATE TABLE [dbo].CoursePackagePremiumServices
(
	[CoursePackagePremiumServiceID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CoursePackageID] INT NULL, 
    [Description] VARCHAR(MAX) NULL, 
    [SharepointID] VARCHAR(MAX) NULL, 
    [Price] DECIMAL NULL
)
