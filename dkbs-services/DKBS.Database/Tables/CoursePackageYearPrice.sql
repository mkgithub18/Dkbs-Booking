CREATE TABLE [dbo].CoursePackageYearPrice
(
	[CoursePackageYearPriceID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CoursePackageID] INT NULL, 
    [Year] VARCHAR(MAX) NULL, 
    [SharepointID] VARCHAR(MAX) NULL, 
    [PricePerPerson] DECIMAL NULL
)
