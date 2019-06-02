CREATE TABLE [dbo].[BookingAndStatuses]
(
	[BookingAndStatusId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [BookingerIncidentTitle] NVARCHAR(255) NOT NULL, 
    [SLACount] BIT NULL, 
    [ClosedStatus] BIT NULL, 
    [InformUserByEmail] NCHAR(10) NULL, 
    [LastModified] DATETIME NOT NULL, 
    [LastModifiedBY] NCHAR(10) NOT NULL
)
