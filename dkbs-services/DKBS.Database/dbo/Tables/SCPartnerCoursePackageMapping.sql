CREATE TABLE [dbo].[SCPartnerCoursePackageMapping] (
    [Id]                            INT NOT NULL,
    [ServiceCatalogueID]            INT NULL,
    [CoursePackageID]               INT NULL,
    [ParterID]                      INT NULL,
    [CoursePackageFreeServiceID]    INT NULL,
    [CoursePackageYearPriceID]      INT NULL,
    [CoursePackagePremiumServiceID] INT NULL,
    [CoursePackageMenueID]          INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

