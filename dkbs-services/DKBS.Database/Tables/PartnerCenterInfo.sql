CREATE TABLE [dbo].[PartnerCenterInfo] (
    [PartnerCenterInfo_Id]       INT           NOT NULL,
    [Total_Rooms]                INT           NULL,
    [Group_Rooms]                INT           NULL,
    [Max_space_at_row_of_chairs] NVARCHAR (50) NULL,
    [Max_space_at_tables]        NVARCHAR (50) NULL,
    [State_agreement]            BIT           NULL,
    [Max_Accommodation]          NVARCHAR (50) NULL,
    [PartnerId]                  INT           NULL,
    PRIMARY KEY CLUSTERED ([PartnerCenterInfo_Id] ASC)
);


