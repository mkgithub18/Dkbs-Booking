CREATE TABLE [dbo].[Customer_old] (
    [CustomerId]       INT             IDENTITY (1, 1) NOT NULL,
    [CustomerName]     NVARCHAR (255)  NULL,
    [EmailId]          NVARCHAR (255)  NULL,
    [PhoneNumber]      NVARCHAR (255)  NULL,
    [IndustryCode]     NVARCHAR (1000) NULL,
    [ZipCode]          NVARCHAR (100)  NULL,
    [Country]          NVARCHAR (200)  NULL,
    [City]             NVARCHAR (200)  NULL,
    [CreatedBy]        NVARCHAR (200)  NULL,
    [CreatedDate]      DATETIME        NOT NULL,
    [LastModifiedDate] DATETIME        NOT NULL,
    [LastModifiedBY]   NVARCHAR (255)  NOT NULL,
    [MapId]            INT             NULL,
    PRIMARY KEY CLUSTERED ([CustomerId] ASC)
);

