CREATE TABLE [dbo].[PartnerServiceCatalogue] (
    [Id]                 INT   IDENTITY (1, 1) NOT NULL,
    [ServiceCatalogueID] INT   NULL,
    [PartnerID]          INT   NULL,
    [Offered]            BIT   NULL,
    [Price]              MONEY NULL,
    [Status]             BIT   NULL,
    CONSTRAINT [PK_PartnerServiceCatalogue] PRIMARY KEY CLUSTERED ([Id] ASC)
);

