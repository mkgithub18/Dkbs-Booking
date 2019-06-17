CREATE TABLE [dbo].[PartnerCoursePackageFreeServices] (
    [PartnerCoursePackageFreeServiceID]     INT            IDENTITY (1, 1) NOT NULL,
    [ServiceCatalogueID]                    INT            NULL,
    [Description]                           VARCHAR (MAX)  NULL,
    [PartnerCoursePackageFreeServices_SPID] VARCHAR (MAX)  NULL,
    [CRMPartnerId]                             INT            NULL,
    [CreatedDate]                           DATETIME       NULL,
    [ModifiedDate]                          DATETIME       NULL,
    [createdBy]                             NVARCHAR (MAX) NULL,
    [ModifiedBy]                            NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([PartnerCoursePackageFreeServiceID] ASC)
);

