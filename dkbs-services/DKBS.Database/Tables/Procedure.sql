CREATE TABLE [dbo].[Procedure]
(
	[ProcedureId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProcedureName] VARCHAR(255) NOT NULL, 
    [BookingId] INT NOT NULL,
	[CRMPartnerId] INT NOT NULL,
	[CustomerId] INT NOT NULL,
	[CauseOfRemovalId] INT NOT NULL,
	[ProcedureReviewTypeId] INT NOT NULL,
    [LastModified] DATETIME NOT NULL, 
    [LastModifiedBY] NVARCHAR(255) NOT NULL, 
    CONSTRAINT [FK_Procedures_Booking] FOREIGN KEY (BookingId) REFERENCES Booking(BookingId), 
    CONSTRAINT [FK_Procedures_Partner] FOREIGN KEY (CRMPartnerId) REFERENCES Partner(CRMPartnerId), 
    CONSTRAINT [FK_Procedures_Customer] FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId), 
    CONSTRAINT [FK_Procedures_CauseOfRemoval] FOREIGN KEY (CauseOfRemovalId) REFERENCES CauseOfRemoval(CauseOfRemovalId), 
    CONSTRAINT [FK_Procedures_ProcedureReviewType] FOREIGN KEY (ProcedureReviewTypeId) REFERENCES ProcedureReviewType(ProcedureReviewTypeId)
)
