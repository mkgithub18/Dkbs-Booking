CREATE TABLE [dbo].[BookingReference]
(
	[BookingReferenceId] INT NOT NULL PRIMARY KEY IDENTITY, 
	[BookingId] INT NOT NULL,
	[ContactPersonId] INT NOT NULL,
	[Other] NVARCHAR(255) NULL,
	[LeadOfOriginId] INT NOT NULL, 
    CONSTRAINT [FK_BookingReference_Booking] FOREIGN KEY ([BookingId]) REFERENCES Booking([BookingId]), 
    CONSTRAINT [FK_BookingReference_ContactPerson] FOREIGN KEY ([ContactPersonId]) REFERENCES [ContactPerson]([ContactPersonId]), 
    CONSTRAINT [FK_BookingReference_LeadOfOrigin] FOREIGN KEY (LeadOfOriginId) REFERENCES LeadOfOrigin(LeadOfOriginId),    
    
)
