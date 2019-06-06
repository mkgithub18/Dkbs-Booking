CREATE TABLE [dbo].[PartnerCoursePackagePremiumServices] (
    [PartnerCoursePackagePremiumServiceID]     INT            IDENTITY (1, 1) NOT NULL,
    [ServiceCatalogueID]                       INT            NULL,
    [Description]                              VARCHAR (MAX)  NULL,
    [PartnerCoursePackagePremiumServices_SPID] VARCHAR (MAX)  NULL,
    [Price]                                    DECIMAL (18)   NULL,
    [PartnerID]                                INT            NULL,
    [CreatedDate]                              DATETIME       NULL,
    [ModifiedDate]                             DATETIME       NULL,
    [createdBy]                                NVARCHAR (MAX) NULL,
    [ModifiedBy]                               NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([PartnerCoursePackagePremiumServiceID] ASC)
);

