CREATE TABLE [dbo].[CoursePackageMenue] (
    [CoursePackageMenueID] INT           IDENTITY (1, 1) NOT NULL,
    [ServiceCatalogueID]   INT           NULL,
    [CoursePackageID]      INT           NULL,
    [Description]          VARCHAR (MAX) NULL,
    [Include]              BIT           NULL,
    [Order]                INT           NULL,
    [SharepointID]         VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([CoursePackageMenueID] ASC)
);

