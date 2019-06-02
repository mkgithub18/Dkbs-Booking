CREATE TABLE [dbo].[ProcedureInfo]
(
	[ProcedureInfoId] INT NOT NULL PRIMARY KEY IDENTITY,
	[ProcedureId] INT NOT NULL,
	[PartnerId] INT NOT NULL,
	[CenterTypeId] INT NOT NULL,
    [EmailOffer] NVARCHAR(255) NOT NULL,
	[Reply] NVARCHAR(255) NOT NULL,
	[Comment] NVARCHAR(255) NOT NULL,
	[Price] NVARCHAR(255) NOT NULL,
   	[Chat] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_ProcedureInfo_Procedure] FOREIGN KEY (ProcedureId) REFERENCES [Procedure](ProcedureId), 
    CONSTRAINT [FK_ProcedureInfo_Partner] FOREIGN KEY (PartnerId) REFERENCES [Partner](PartnerId), 
    CONSTRAINT [FK_ProcedureInfo_CenterType] FOREIGN KEY (CenterTypeId) REFERENCES CenterType(CenterTypeId) 
)
