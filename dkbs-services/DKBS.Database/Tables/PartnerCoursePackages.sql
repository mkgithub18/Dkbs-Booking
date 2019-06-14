CREATE TABLE [dbo].[PartnerCoursePackages]
(
	[PartnerCoursePackagesId] INT NOT NULL PRIMARY KEY, 
    [PartnerId] INT NOT NULL, 
    [ServiceCatalogId] INT NOT NULL, 
    [Offered] BIT NULL, 
    [Name] NVARCHAR(50) NULL, 
    [Price] NVARCHAR(50) NULL, 
    [Approval Status] BIT NULL,
	[PartnerCoursePackagesSpId] NVARCHAR(50) NULL, 
	[CreatedDate]                  DATETIME       NULL,
    [CreatedBy]                    NVARCHAR (255) NULL,
    [LastModified]                 DATETIME       NULL,
    [LastModifiedBY]               NVARCHAR (255) NULL,
    CONSTRAINT [FK_PartnerCoursePackages_Partner] FOREIGN KEY ([PartnerId]) REFERENCES [Partner]([PartnerId]),
		CONSTRAINT [FK_PartnerCoursePackages_ServiceCatalogue] FOREIGN KEY ([ServiceCatalogId]) REFERENCES [ServiceCatalog]([ServiceCatalogId]),

)
