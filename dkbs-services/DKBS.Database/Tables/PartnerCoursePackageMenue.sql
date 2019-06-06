CREATE TABLE [dbo].[PartnerCoursePackageMenue ] (
    [PartnerCoursePackageMenueID]   INT            NOT NULL,
    [PartnerId]                     INT            NOT NULL,
    [ServiceCatalogueID]            INT            NOT NULL,
    [Include]                       BIT            NULL,
    [CoursePackageMenueID]          INT            NULL,
    [PartnerCoursePakageMenue_SPID] NVARCHAR (MAX) NULL,
    [CreatedDate]                   DATETIME       NULL,
    [ModifiedDate]                  DATETIME       NULL,
    [createdBy]                     NVARCHAR (MAX) NULL,
    [ModifiedBy]                    NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([PartnerCoursePackageMenueID] ASC),
    CONSTRAINT [FK_PartnerCoursePackages_Partner] FOREIGN KEY ([PartnerId]) REFERENCES [dbo].[Partner] ([PartnerId]),
    CONSTRAINT [FK_PartnerCoursePackages_ServiceCatalogue] FOREIGN KEY ([ServiceCatalogueID]) REFERENCES [dbo].[ServiceCatalogue] ([ServiceCatalogueID])
);



