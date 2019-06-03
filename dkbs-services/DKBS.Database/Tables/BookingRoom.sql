CREATE TABLE [dbo].[BookingRoom]
(
	[BookingRoomId] INT NOT NULL PRIMARY KEY IDENTITY, 
	[BookingId] INT NOT NULL,
	[TablesetId] INT NOT NULL,
	[LocationAttraction] NVARCHAR(255) NULL,
	[NumberOfRooms] INT NOT NULL,
    [PerPerson] INT NULL, 
	[ToDate] DATETIME NULL,
	[FromDate] DATETIME NULL, 
    CONSTRAINT [FK_BookingRooms_Booking] FOREIGN KEY (BookingId) REFERENCES Booking(BookingId), 
    CONSTRAINT [FK_BookingRooms_TableSet] FOREIGN KEY (TablesetId) REFERENCES Tableset(TablesetId) 
    
)
