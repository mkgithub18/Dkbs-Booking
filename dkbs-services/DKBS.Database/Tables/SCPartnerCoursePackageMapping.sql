CREATE TABLE [dbo].SCPartnerCoursePackageMapping
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ServiceCatalogueID] INT NULL, 
    [CoursePackageID] NCHAR(10) NULL, 
    [ParterID] INT NULL, 
    [CoursePackageFreeServiceID] INT NULL, 
    [CoursePackageYearPriceID] INT NULL, 
    [CoursePackagePremiumServiceID] INT NULL, 
    [CoursePackageMenueID] INT NULL
)
