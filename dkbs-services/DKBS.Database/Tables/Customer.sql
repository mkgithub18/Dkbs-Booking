CREATE TABLE [dbo].[Customer] (
    [CustomerId]     INT             IDENTITY (1, 1) NOT NULL,
    [CompanyName]    NVARCHAR (255)  NOT NULL,
    [Address1]       NVARCHAR (255)  NOT NULL,
    [Address2]       NVARCHAR (255)  NOT NULL,
    [Town]           NVARCHAR (200)  NOT NULL,
    [PostNumber]     NVARCHAR (100)  NOT NULL,
    [PhoneNumber]    NVARCHAR (255)  NOT NULL,
    [Country]        NVARCHAR (200)  NOT NULL,
    [StateAgreement] BIT             NOT NULL,
    [AccountId]      NVARCHAR (255)  NOT NULL,
    [IndustryCode]   NVARCHAR (1000) NOT NULL,
    [CreatedDate]    DATETIME        NULL,
    [CreatedBy]      NVARCHAR (100)  NULL,
    [LastModified]   DATETIME        NULL,
    [LastModifiedBy] NVARCHAR (100)  NULL,
    PRIMARY KEY CLUSTERED ([CustomerId] ASC),
    UNIQUE NONCLUSTERED ([AccountId] ASC)
);


