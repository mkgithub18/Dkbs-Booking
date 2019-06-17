CREATE TABLE [dbo].[SCPartnerCoursePackageMapping] (
    [Id]                            INT   IDENTITY (1, 1) NOT NULL,
    [ServiceCatalogueID]            INT   NULL,
    [CRMPartnerId]                     INT   NULL,
    [CoursePackageFreeServiceID]    INT   NULL,
    [CoursePackageYearPriceID]      INT   NULL,
    [CoursePackagePremiumServiceID] INT   NULL,
    [CoursePackageMenueID]          INT   NULL,
    [Offered]                       BIT   NULL,
    [Price]                         MONEY NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);



