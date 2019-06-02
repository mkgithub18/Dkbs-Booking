CREATE TABLE [dbo].[ServiceRequestNote]
(
	[ServiceRequestNoteId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SRNotesTitle] NCHAR(10) NULL, 
    [BookingId] INT NOT NULL,	
    [Action] NCHAR(10) NULL, 
    [PlannedStart] NCHAR(10) NULL, 
	[PlannedEnd] NCHAR(10) NULL, 
    [CopyToCloseRemark] NCHAR(10) NULL, 
    [ScheduleAction] NCHAR(10) NULL, 
    [LastModified] DATETIME NULL, 
    [LastModifiedBY] NCHAR(10) NULL, 
    CONSTRAINT [FK_ServiceRequestNotes_Booking] FOREIGN KEY (BookingId) REFERENCES Booking(BookingId)
	
)
