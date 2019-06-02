CREATE TABLE [dbo].[Provision]
(
	[ProvisionId] INT NOT NULL PRIMARY KEY,   
    [PartnerId] INT NOT NULL, 
    [CustomerId] INT NOT NULL, 
    [BookingId] INT NOT NULL,     
    [Price] DECIMAL(19, 4) NULL,     
    [LastModified] NVARCHAR(255) NOT NULL, 
    [LastModifiedBy] NVARCHAR(255) NOT NULL,
	CONSTRAINT [FK_Provision_Partners] FOREIGN KEY ([PartnerId]) REFERENCES [Partner]([PartnerId]),
	CONSTRAINT [FK_Provision_Booking] FOREIGN KEY ([BookingId]) REFERENCES [Booking]([BookingId]), 
    CONSTRAINT [FK_Provision_Customer] FOREIGN KEY (CustomerId) REFERENCES [Customer](CustomerId),
)
