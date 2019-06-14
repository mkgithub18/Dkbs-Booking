CREATE TABLE [dbo].[EmailConversation] (
    [PartnerId]           INT            NOT NULL,
    [EmailTitle]          VARCHAR (255)  NOT NULL,
    [Message]             VARCHAR (255)  NULL,
    [Sender]              VARCHAR (255)  NULL,
    [CC_adresses]         VARCHAR (255)  NULL,
    [Booking_ID]          VARCHAR (255)  NULL,
    [Message_id]          VARCHAR (255)  NULL,
    [to_Message]          VARCHAR (255)  NULL,
    [CreatedDate]         DATETIME       NOT NULL,
    [CreatedBy]           NVARCHAR (255) NOT NULL,
    [LastModified]        DATETIME       NOT NULL,
    [LastModifiedBY]      NVARCHAR (255) NOT NULL,
    [Sharepoint_ID]       INT            NULL,
    [EmailConversationID] INT            NULL
);

