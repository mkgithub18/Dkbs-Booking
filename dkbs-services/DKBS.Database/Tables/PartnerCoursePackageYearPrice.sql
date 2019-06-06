CREATE TABLE [dbo].[PartnerCoursePackageYearPrice] (
    [PartnerCoursePackageYearPriceID]    INT            IDENTITY (1, 1) NOT NULL,
    [ServiceCatalogueID]                 INT            NULL,
    [Year]                               VARCHAR (MAX)  NULL,
    [PartnerCoursePackageYearPrice_SPID] VARCHAR (MAX)  NULL,
    [PricePerPerson]                     DECIMAL (18)   NULL,
    [PartnerID]                          INT            NULL,
    [CreatedDate]                        DATETIME       NULL,
    [ModifiedDate]                       DATETIME       NULL,
    [createdBy]                          NVARCHAR (MAX) NULL,
    [ModifiedBy]                         NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([PartnerCoursePackageYearPriceID] ASC)
);

