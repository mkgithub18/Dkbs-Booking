CREATE TABLE [dbo].[chatcommunication] (
    [ChatTitle]                    VARCHAR (255)  NOT NULL,
    [Booking_ID]                   VARCHAR (255)  NULL,
    [Communications]               VARCHAR (255)  NULL,
    [From_MyIT]                    VARCHAR (255)  NULL,
    [Copy_to_close_remark]         VARCHAR (255)  NULL,
    [Procedure_ID]                 INT            NULL,
    [IsPartnerSideCommunication]   BIT            NULL,
    [Procedure_info_communication] BIT            NULL,
    [Message_id]                   VARCHAR (255)  NULL,
    [to_Message]                   VARCHAR (255)  NULL,
    [CreatedDate]                  DATETIME       NOT NULL,
    [CreatedBy]                    NVARCHAR (255) NOT NULL,
    [LastModified]                 DATETIME       NOT NULL,
    [LastModifiedBY]               NVARCHAR (255) NOT NULL,
    [Sharepoint_ID]                INT            NULL,
    [Chat_ID]                      INT            NULL
);

