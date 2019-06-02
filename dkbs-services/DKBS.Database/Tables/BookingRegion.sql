CREATE TABLE [dbo].[BookingRegion]
(
	[BookingRegionId] INT NOT NULL PRIMARY KEY IDENTITY, 
	[BookingId] INT NOT NULL,
	[RegionId] INT NOT NULL, 
    CONSTRAINT [FK_BookingRegions_Booking] FOREIGN KEY ([BookingId]) REFERENCES Booking([BookingId]), 
    CONSTRAINT [FK_BookingRegions_Region] FOREIGN KEY (RegionId) REFERENCES Region(RegionId)
)
