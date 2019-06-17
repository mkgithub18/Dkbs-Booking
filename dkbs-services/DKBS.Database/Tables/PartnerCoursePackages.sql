CREATE TABLE [dbo].[PartnerCoursePackages] (
    [ID]                        INT           IDENTITY (1, 1) NOT NULL,
    [CRMPartnerId]                 INT           NULL,
    [ServiceCatalogueID]        INT           NULL,
    [Offered]                   BIT           NULL,
    [Price]                     MONEY         NULL,
    [PartnerCoursePackage_SPID] VARCHAR (50)  NULL,
    [CreatedDate]               DATETIME      NULL,
    [ModifiedDate]              DATETIME      NULL,
    [CreatedBy]                 NVARCHAR (50) NULL,
    [ModifiedBy]                NVARCHAR (50) NULL,
    CONSTRAINT [PK_PartnerCoursePackages] PRIMARY KEY CLUSTERED ([ID] ASC)
);




