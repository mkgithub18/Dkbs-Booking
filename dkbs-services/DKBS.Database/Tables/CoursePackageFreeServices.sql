CREATE TABLE [dbo].CoursePackageFreeServices
(
	[CoursePackageFreeServiceID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CoursePackageID] INT NULL, 
    [Description] VARCHAR(MAX) NULL, 
    [SharepointID] VARCHAR(MAX) NULL, 
    CONSTRAINT [PK_Table] PRIMARY KEY ([CoursePackageFreeServiceID])
)
