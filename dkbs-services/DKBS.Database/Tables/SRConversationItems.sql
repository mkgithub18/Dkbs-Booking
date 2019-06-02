CREATE TABLE [dbo].[SRConversationItems]
(
	[SRConversationItemsId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SRConversationTitle] NVARCHAR(255) NOT NULL, 
    [ConversationMessage] NVARCHAR(255) NULL, 
    [Sender] NVARCHAR(255) NOT NULL, 
    [CcAddress] NVARCHAR(255) NULL,
	[BookingId] INT NOT NULL,
    [ConversationMessageId] NVARCHAR(255) NULL, 
    [Reciever] NVARCHAR(255) NULL, 
    [LastModified] DATETIME NOT NULL, 
    [LastModifiedBY] NCHAR(10) NOT NULL, 
    CONSTRAINT [FK_SRConversationItems_Booking] FOREIGN KEY (BookingId) REFERENCES Booking(BookingId) 
	
)
