CREATE TABLE [dbo].[PartnerInspirationCategoriesUK] (
    [PartnerInspirationCategoriesUKId] INT           NOT NULL,
    [PartnerId]                        INT           NOT NULL,
    [Heading]                          NVARCHAR (50) NULL,
    [Description]                      NVARCHAR (50) NULL,
    [Price]                            INT           NULL,
    [ApprovalStatus]                   BIT           NULL,
    [PartnerInspirationCategoriesSpId] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([PartnerInspirationCategoriesUKId] ASC),
    CONSTRAINT [FK_PartnerInspirationCategoriesUK_Partner] FOREIGN KEY ([PartnerId]) REFERENCES [dbo].[Partner] ([PartnerId])
);

