CREATE TABLE [dbo].[Partners]
(
	[PartnerId] INT NOT NULL PRIMARY KEY, 
    [PartnerName] VARCHAR(255) NOT NULL,
    [EmailId] VARCHAR(255) NULL, 
	[CenterTypeId] INT NULL,
	[PartnerTypeId] INT NULL,
	[PhoneNumber] VARCHAR(255) NULL,
	[LastModified] DATETIME NOT NULL, 
    [LastModifiedBY] NVARCHAR(255) NOT NULL, 
    CONSTRAINT [FK_Partners_CenterType] FOREIGN KEY (CenterTypeId) REFERENCES CenterTypes(CenterTypeId), 
    CONSTRAINT [FK_Partners_PartnerType] FOREIGN KEY (PartnerTypeId) REFERENCES PartnerTypes(PartnerTypeId)   
)
