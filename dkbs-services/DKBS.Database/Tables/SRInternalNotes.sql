CREATE TABLE [dbo].[SRInternalNotes] (
    [InternalNoteName]   VARCHAR (255)  NOT NULL,
    [BookingID]          VARCHAR (255)  NULL,
    [Notes]              VARCHAR (255)  NULL,
    [InternalNoteNotify] INT            NULL,
    [ScheduleAction]     BIT            NULL,
    [CopyToCloseRemark]  BIT            NULL,
    [PlannedStart]       DATETIME       NOT NULL,
    [PlannedEnd]         DATETIME       NOT NULL,
    [toMessage]          VARCHAR (255)  NULL,
    [CreatedDate]        DATETIME       NOT NULL,
    [CreatedBy]          NVARCHAR (255) NOT NULL,
    [LastModified]       DATETIME       NOT NULL,
    [LastModifiedBY]     NVARCHAR (255) NOT NULL,
    [SharepointID]       INT            NULL,
    [InternalNoteID]     INT            NULL
);



