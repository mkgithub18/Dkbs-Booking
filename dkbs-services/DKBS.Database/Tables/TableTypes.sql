﻿CREATE TABLE [dbo].[TableTypes]
(
	[TableTypeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TableTypeName] NVARCHAR(255) NULL,
	[CreatedDate] DATETIME NULL,
	[CreatedBy] nvarchar(100),
	[LastModified] DATETIME NULL, 
	[LastModifiedBy] NVARCHAR(100) NULL
)
