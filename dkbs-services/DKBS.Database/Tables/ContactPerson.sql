CREATE TABLE [dbo].[ContactPerson] (
    [ContactPersonId] INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]       NVARCHAR (255) NOT NULL,
    [LastName]        NVARCHAR (255) NOT NULL,
    [Email]           NVARCHAR (255) NOT NULL,
    [Telephone]       NVARCHAR (50)  NOT NULL,
    [MobilePhone]     NVARCHAR (50)  NOT NULL,
    [AccountId]       NVARCHAR (255) NOT NULL,
    [ContactId]       NVARCHAR (255) NOT NULL,
    [CreatedDate]     DATETIME       NULL,
    [CreatedBy]       NVARCHAR (100) NULL,
    [LastModified]    DATETIME       NULL,
    [LastModifiedBy]  NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([ContactPersonId] ASC),
    UNIQUE NONCLUSTERED ([ContactId] ASC)
);


