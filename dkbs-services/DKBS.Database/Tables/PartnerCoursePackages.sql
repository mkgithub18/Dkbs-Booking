CREATE TABLE [dbo].[PartnerCoursePackages]
(
	[PartnerCoursePackages_Id] INT NOT NULL PRIMARY KEY, 
    [PartnerId] INT NOT NULL, 
    [ServiceCatalogId] INT NOT NULL, 
    [Offered] BIT NULL, 
    [Name] NVARCHAR(50) NULL, 
    [Price] NVARCHAR(50) NULL, 
    [Approval Status] BIT NULL,
	CONSTRAINT [FK_PartnerCoursePackages_Partner] FOREIGN KEY ([PartnerId]) REFERENCES [Partner]([PartnerId]),
		CONSTRAINT [FK_PartnerCoursePackages_ServiceCatalogue] FOREIGN KEY ([ServiceCatalogId]) REFERENCES [ServiceCatalog]([ServiceCatalogId]),

)
