CREATE TABLE [dbo].[BookingAlternativeService]
(
	[BookingAlternativeServiceId] INT NOT NULL PRIMARY KEY IDENTITY, 
	[BookingId] INT NOT NULL,
	[NumberOfPieces] INT NOT NULL,
    [Description] NVARCHAR(255) NULL, 
	[CreatedDate] DATETIME NULL,
	[CreatedBy] nvarchar(100),
    [LastModified] DATETIME NULL, 
    [LastModifiedBy] NVARCHAR(100) NULL, 
    CONSTRAINT [FK_AlternativeService_Booking] FOREIGN KEY (BookingId) REFERENCES Booking(BookingId) 
)
