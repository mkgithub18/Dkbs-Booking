CREATE TABLE [dbo].[PartnerEmployee] (
    [PartnerEmployeeId] INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeName]      NVARCHAR (255) NOT NULL,
    [JobTitle]          NVARCHAR (255) NOT NULL,
    [TelePhoneNumber]   NVARCHAR (255) NOT NULL,
    [Email]             NVARCHAR (255) NOT NULL,
    [PartnerId]         INT            NOT NULL,
    [MailGroupId]       INT            NOT NULL,
    [PartnerTypeId]     INT            NOT NULL,
    [ParticipantTypeId] INT            NOT NULL,
    [LastModified]      DATETIME       NOT NULL,
    [LastModifiedBY]    NVARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([PartnerEmployeeId] ASC),
    CONSTRAINT [FK_PartnerEmployee_MailGroup] FOREIGN KEY ([MailGroupId]) REFERENCES [dbo].[MailGroup] ([MailGroupId]),
    CONSTRAINT [FK_PartnerEmployee_ParticipantType] FOREIGN KEY ([ParticipantTypeId]) REFERENCES [dbo].[ParticipantType] ([ParticipantTypeId]),
    CONSTRAINT [FK_PartnerEmployee_Partner] FOREIGN KEY ([PartnerId]) REFERENCES [dbo].[Partner] ([PartnerId]),
    CONSTRAINT [FK_PartnerEmployee_PartnerType] FOREIGN KEY ([PartnerTypeId]) REFERENCES [dbo].[PartnerType] ([PartnerTypeId])
);


