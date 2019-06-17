CREATE TABLE [dbo].[PartnerCoursePackageMenue ] (
    [PartnerCoursePackageMenueID]   INT            NOT NULL,
    [CRMPartnerId]                     INT            NOT NULL,
    [ServiceCatalogueID]            INT            NOT NULL,
    [Include]                       BIT            NULL,
    [CoursePackageMenueID]          INT            NULL,
    [PartnerCoursePakageMenue_SPID] NVARCHAR (MAX) NULL,
    [CreatedDate]                   DATETIME       NULL,
    [ModifiedDate]                  DATETIME       NULL,
    [createdBy]                     NVARCHAR (MAX) NULL,
    [ModifiedBy]                    NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([PartnerCoursePackageMenueID] ASC),
    CONSTRAINT [FK_PartnerCoursePackages_Partner] FOREIGN KEY ([CRMPartnerId]) REFERENCES [dbo].[Partner] ([CRMPartnerId]),
    CONSTRAINT [FK_PartnerCoursePackages_ServiceCatalogue] FOREIGN KEY ([ServiceCatalogueID]) REFERENCES [dbo].[ServiceCatalogue] ([ServiceCatalogueID])
);



