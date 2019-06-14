CREATE TABLE [dbo].[PartnerInspirationCategoriesDK] (
    [PartnerInspirationCategoriesDKId]   INT            NOT NULL,
    [PartnerId]                          INT            NOT NULL,
    [Heading]                            NVARCHAR (50)  NULL,
    [Description]                        NVARCHAR (50)  NULL,
    [Price]                              INT            NULL,
    [ApprovalStatus]                     BIT            NULL,
    [PartnerInspirationCategoriesDKSpId] NVARCHAR (50)  NULL,
    [CreatedDate]                        DATETIME       NULL,
    [CreatedBy]                          NVARCHAR (255) NULL,
    [LastModified]                       DATETIME       NULL,
    [LastModifiedBY]                     NVARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([PartnerInspirationCategoriesDKId] ASC),
    CONSTRAINT [FK_PartnerInspirationCategoriesDK_Partner] FOREIGN KEY ([PartnerId]) REFERENCES [dbo].[Partner] ([PartnerId])
);





