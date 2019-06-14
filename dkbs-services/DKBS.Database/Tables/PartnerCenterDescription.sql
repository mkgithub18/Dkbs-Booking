CREATE TABLE [dbo].[PartnerCenterDescription] (
    [PartnerCenterDescriptionId]  INT            NOT NULL,
    [PartnerId]                    INT            NOT NULL,
    [Rooms]                        NVARCHAR (50)  NULL,
    [Capacity]                     NVARCHAR (50)  NULL,
    [Facilities]                   NVARCHAR (50)  NULL,
    [Activities]                   NVARCHAR (50)  NULL,
    [ApprovalStatus]               BIT            NULL,
    [TextforQuotationforEmail]     NVARCHAR (50)  NULL,
    [Transportation]               NVARCHAR (50)  NULL,
    [Description]                  NVARCHAR (50)  NULL,
    [PartnerCenterDescriptionSpId] NVARCHAR (50)  NULL,
    [CreatedDate]                  DATETIME       NOT NULL,
    [CreatedBy]                    NVARCHAR (255) NOT NULL,
    [LastModified]                 DATETIME       NOT NULL,
    [LastModifiedBY]               NVARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([PartnerCenterDescriptionId] ASC),
    CONSTRAINT [FK_PartnerCenterDescription_Partner] FOREIGN KEY ([PartnerId]) REFERENCES [dbo].[Partner] ([PartnerId])
);




