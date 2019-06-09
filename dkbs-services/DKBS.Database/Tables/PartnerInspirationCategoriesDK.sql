CREATE TABLE [dbo].[PartnerInspirationCategoriesDK] (
    [PartnerInspirationCategoriesDKId]   INT           NOT NULL,
    [PartnerId]                          INT           NOT NULL,
    [Heading]                            NVARCHAR (50) NULL,
    [Description]                        NVARCHAR (50) NULL,
    [Price]                              INT           NULL,
    [ApprovalStatus]                     BIT           NULL,
    [PartnerInspirationCategoriesDKSpId] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([PartnerInspirationCategoriesDKId] ASC),
    CONSTRAINT [FK_PartnerInspirationCategoriesDK_Partner] FOREIGN KEY ([PartnerId]) REFERENCES [dbo].[Partner] ([PartnerId])
);



