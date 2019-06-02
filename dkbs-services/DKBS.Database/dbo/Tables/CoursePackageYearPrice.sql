CREATE TABLE [dbo].[CoursePackageYearPrice] (
    [CoursePackageYearPriceID] INT             NOT NULL,
    [CoursePackageID]          INT             NULL,
    [Year]                     VARCHAR (MAX)   NULL,
    [SharepointID]             VARCHAR (MAX)   NULL,
    [PricePerPerson]           DECIMAL (18, 2) NULL,
    PRIMARY KEY CLUSTERED ([CoursePackageYearPriceID] ASC)
);

