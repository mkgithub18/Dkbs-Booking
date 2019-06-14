CREATE TABLE [dbo].[Provision] (
    [ProvisionId]    INT             NOT NULL,
    [PartnerId]      INT             NOT NULL,
    [CustomerId]     INT             NOT NULL,
    [BookingId]      INT             NOT NULL,
    [Price]          DECIMAL (19, 4) NULL,
    [CreatedOn]      DATETIME        NULL,
    [DateofShipment] DATETIME        NULL,
    [Debtor]         NVARCHAR (255)  NULL,
    [ProvisionName]  NVARCHAR (MAX)  NULL,
    [UnitID]         INT             NOT NULL,
    [CreatedBy]      NVARCHAR (255)  NOT NULL,
    [ProvisionSpID]  INT             NOT NULL,
    [LastModified]   NVARCHAR (255)  NOT NULL,
    [LastModifiedBy] NVARCHAR (255)  NOT NULL,
    PRIMARY KEY CLUSTERED ([ProvisionId] ASC),
    CONSTRAINT [FK_Provision_Booking] FOREIGN KEY ([BookingId]) REFERENCES [dbo].[Booking] ([BookingId]),
    CONSTRAINT [FK_Provision_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([CustomerId]),
    CONSTRAINT [FK_Provision_Partners] FOREIGN KEY ([PartnerId]) REFERENCES [dbo].[Partner] ([PartnerId])
);


