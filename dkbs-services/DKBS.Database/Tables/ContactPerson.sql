CREATE TABLE [dbo].[ContactPerson] (
    [ContactPersonId] INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]       NVARCHAR (255) NULL,
    [LastName]        NVARCHAR (255) NULL,
    [Position]        NVARCHAR (255) NULL,
    [Email]           NVARCHAR (255) NULL,
    [Telephone]       NVARCHAR (50)  NULL,
    [MobilePhone]     INT            NULL,
    [MapId]           INT            NULL,
    [CreatedDate]     DATETIME       NULL,
    [CreatedBy]       NVARCHAR (100) NULL,
    [LastModified]    DATETIME       NULL,
    [LastModifiedBy]  NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([ContactPersonId] ASC)
);


