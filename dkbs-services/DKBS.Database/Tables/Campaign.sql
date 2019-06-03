﻿CREATE TABLE [dbo].[Campaign]
(
	[CampaignId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(255) NULL,
	[CreatedDate] DATETIME NULL,
	[CreatedBy] nvarchar(100),
	[LastModified] DATETIME NULL, 
	[LastModifiedBy] NVARCHAR(100) NULL
)
