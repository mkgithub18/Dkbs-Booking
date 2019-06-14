CREATE TABLE [dbo].[Customer] (
    [CustomerId]     INT             IDENTITY (1, 1) NOT NULL,
    [CompanyName]    NVARCHAR (255)  NULL,
    [Address1]       NVARCHAR (255)  NULL,
    [Address2]       NVARCHAR (255)  NULL,
    [Town]           NVARCHAR (1000) NULL,
    [PostNumber]     NVARCHAR (100)  NULL,
    [PhoneNumber]    NVARCHAR (200)  NULL,
    [Country]        NVARCHAR (200)  NULL,
    [StateAgreement] NVARCHAR (200)  NULL,
    [AccountId]      DATETIME        NOT NULL,
    [IndustryCode]   DATETIME        NOT NULL,
    [LastModifiedBY] NVARCHAR (255)  NOT NULL,
    [MapId]          INT             NULL,
    PRIMARY KEY CLUSTERED ([CustomerId] ASC)
);


