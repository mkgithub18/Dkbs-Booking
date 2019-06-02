CREATE TABLE [dbo].[BookingArrangementTypes]
(
	[BookingArrangementTypeId] INT NOT NULL PRIMARY KEY IDENTITY, 
	[BookingId] INT NOT NULL,
	[ServiceCatalogId] INT NOT NULL,
	[NumberOfParticipants] INT NOT NULL,
    [ToDate] DATETIME NULL,
	[FromDate] DATETIME NULL, 
    CONSTRAINT [FK_BookingArrangementType_Booking] FOREIGN KEY (BookingId) REFERENCES Booking(BookingId), 
    
)
