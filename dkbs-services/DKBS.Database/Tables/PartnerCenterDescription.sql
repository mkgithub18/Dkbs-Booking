CREATE TABLE [dbo].[PartnerCenterDescription] (
    [PartnerCenterDescription_Id]  INT            NOT NULL,
    [CRMPartnerId]                    INT            NOT NULL,
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
    PRIMARY KEY CLUSTERED ([PartnerCenterDescription_Id] ASC),
    CONSTRAINT [FK_PartnerCenterDescription_Partner] FOREIGN KEY ([CRMPartnerId]) REFERENCES [dbo].[Partner] ([CRMPartnerId])
);




