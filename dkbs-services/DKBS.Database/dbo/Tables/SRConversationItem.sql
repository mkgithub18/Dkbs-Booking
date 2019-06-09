CREATE TABLE [dbo].[SRConversationItem] (
    [SRConversationItemId]  INT            IDENTITY (1, 1) NOT NULL,
    [SRConversationTitle]   NVARCHAR (255) NOT NULL,
    [ConversationMessage]   NVARCHAR (255) NULL,
    [Sender]                NVARCHAR (255) NOT NULL,
    [CcAddress]             NVARCHAR (255) NULL,
    [BookingId]             INT            NOT NULL,
    [ConversationMessageId] NVARCHAR (255) NULL,
    [Reciever]              NVARCHAR (255) NULL,
    [LastModified]          DATETIME       NOT NULL,
    [LastModifiedBY]        NCHAR (10)     NOT NULL,
    PRIMARY KEY CLUSTERED ([SRConversationItemId] ASC),
    CONSTRAINT [FK_SRConversationItems_Bookingss] FOREIGN KEY ([BookingId]) REFERENCES [dbo].[Booking] ([BookingId])
);

