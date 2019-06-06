CREATE TABLE [dbo].[ServiceCatalogue] (
    [ServiceCatalogueID] INT             IDENTITY (1, 1) NOT NULL,
    [CoursePackageName]  NVARCHAR (255)  NULL,
    [Offered]            BIT             NULL,
    [Price]              DECIMAL (18, 2) NULL,
    [CreatedDate]        DATETIME        NULL,
    [CreatedBy]          NVARCHAR (100)  NULL,
    [LastModifiedBY]     VARCHAR (MAX)     NULL,
    [LastModified]       DATETIME        NULL,
    PRIMARY KEY CLUSTERED ([ServiceCatalogueID] ASC)
);

