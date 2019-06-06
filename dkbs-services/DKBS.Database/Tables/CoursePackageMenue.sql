CREATE TABLE [dbo].[CoursePackageMenue] (
    [CoursePackageMenueID]    INT           IDENTITY (1, 1) NOT NULL,
    [ServiceCatalogueID]      INT           NULL,
    [Description]             VARCHAR (MAX) NULL,
    [Include]                 BIT           NULL,
    [Order]                   INT           NULL,
    [CoursePackageMenue_SPID] VARCHAR (MAX) NULL,
    [CreatedDate]             DATETIME      NULL,
    [CreatedBy]               VARCHAR (MAX) NULL,
    [LastModified]            DATETIME      NULL,
    [LastModifiedBY]          VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([CoursePackageMenueID] ASC)
);



