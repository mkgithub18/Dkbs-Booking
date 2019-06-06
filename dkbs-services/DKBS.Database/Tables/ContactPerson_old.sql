CREATE TABLE [dbo].[ContactPerson_old] (
    [ContactPersonId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (255) NULL,
    [Department]      NVARCHAR (255) NULL,
    [Position]        NVARCHAR (255) NULL,
    [Email]           NVARCHAR (255) NULL,
    [Telephone]       NVARCHAR (50)  NULL,
    [CustomerId]      INT            NULL,
    [MapId]           INT            NULL,
    [CreatedDate]     DATETIME       NULL,
    [CreatedBy]       NVARCHAR (100) NULL,
    [LastModified]    DATETIME       NULL,
    [LastModifiedBy]  NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([ContactPersonId] ASC)
);

