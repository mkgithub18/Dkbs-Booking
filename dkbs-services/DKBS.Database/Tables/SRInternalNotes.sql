CREATE TABLE [dbo].[SRInternalNotes] (
    [InternalNoteName]     VARCHAR (255)  NOT NULL,
    [Booking_ID]           VARCHAR (255)  NULL,
    [Notes]                VARCHAR (255)  NULL,
    [InternalNoteNotify]   INT            NULL,
    [Schedule_action]      BIT            NULL,
    [Copy_to_close_remark] BIT            NULL,
    [Planned_start]        DATETIME       NOT NULL,
    [Planned_end]          DATETIME       NOT NULL,
    [to_Message]           VARCHAR (255)  NULL,
    [CreatedDate]          DATETIME       NOT NULL,
    [CreatedBy]            NVARCHAR (255) NOT NULL,
    [LastModified]         DATETIME       NOT NULL,
    [LastModifiedBY]       NVARCHAR (255) NOT NULL,
    [Sharepoint_ID]        INT            NULL,
    [InternalNote ID]      INT            NULL
);

