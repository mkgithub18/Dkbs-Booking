CREATE TABLE [dbo].[CoursePackageType]
(
	[CoursePackageTypeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CoursePackageTypeTitle] NVARCHAR(255) NULL,
	[CreatedDate] DATETIME NULL,
	[CreatedBy] nvarchar(100),
	[LastModified] DATETIME NULL, 
	[LastModifiedBy] NVARCHAR(100) NULL
)
