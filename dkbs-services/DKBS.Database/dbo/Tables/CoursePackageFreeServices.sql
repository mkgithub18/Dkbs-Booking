CREATE TABLE [dbo].[CoursePackageFreeServices] (
    [CoursePackageFreeServiceID] INT           IDENTITY (1, 1) NOT NULL,
    [CoursePackageID]            INT           NULL,
    [Description]                VARCHAR (MAX) NULL,
    [SharepointID]               VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([CoursePackageFreeServiceID] ASC)
);

