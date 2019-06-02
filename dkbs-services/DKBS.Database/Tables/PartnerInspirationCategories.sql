CREATE TABLE [dbo].[PartnerInspirationCategories]
(
	[PartnerInspirationCategories_Id] INT NOT NULL PRIMARY KEY, 
    [PartnerId] INT NOT NULL, 
    [Heading] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(50) NULL, 
    [Price] INT NULL, 
    [Approval Status] BIT NULL,
    CONSTRAINT [FK_PartnerInspirationCategories_Partner] FOREIGN KEY ([PartnerId]) REFERENCES [Partner](PartnerId),
)
