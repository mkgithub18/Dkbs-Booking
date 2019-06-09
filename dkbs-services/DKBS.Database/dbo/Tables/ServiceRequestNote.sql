CREATE TABLE [dbo].[ServiceRequestNote] (
    [ServiceRequestNoteId] INT        IDENTITY (1, 1) NOT NULL,
    [SRNotesTitle]         NCHAR (10) NULL,
    [BookingId]            INT        NOT NULL,
    [Action]               NCHAR (10) NULL,
    [PlannedStart]         NCHAR (10) NULL,
    [PlannedEnd]           NCHAR (10) NULL,
    [CopyToCloseRemark]    NCHAR (10) NULL,
    [ScheduleAction]       NCHAR (10) NULL,
    [LastModified]         DATETIME   NULL,
    [LastModifiedBY]       NCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([ServiceRequestNoteId] ASC),
    CONSTRAINT [FK_ServiceRequestNotes_Bookings] FOREIGN KEY ([BookingId]) REFERENCES [dbo].[Booking] ([BookingId])
);

