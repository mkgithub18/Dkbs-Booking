﻿CREATE TABLE [dbo].[CRMPartner]
(
	[CRMPartnerId] INT NOT NULL PRIMARY KEY IDENTITY,
          AccountId NVARCHAR(100) UNIQUE NOT NULL,
          Partnertype NVARCHAR(100),
          MembershipType NVARCHAR(100),
          PartnerName NVARCHAR(200) NOT NULL,
          CVR NVARCHAR(255),
          Telefon NVARCHAR(50),
          Centertype NVARCHAR(255),
          Address1 NVARCHAR(500),
          Address2 NVARCHAR(500),
          Town NVARCHAR(200),
          PostNumber NVARCHAR(100),
          Land NVARCHAR(200),
          StateAgreement bit,
          Debitornummer NVARCHAR(100),
          Debitornummer2 NVARCHAR(100),
          Regions NVARCHAR(500),
          MembershipStartDate DateTime,
          [PublicURL] NVARCHAR(500) ,
          Email NVARCHAR(100),
          Website NVARCHAR(200),
          PanoramView NVARCHAR(200),
          RecommandedNPGRT60 bit,
          QualityAssuredNPSGRD30 bit,
		  SharePointId INT,
          LastModified datetime,
          LastModifiedBy NVARCHAR(100),
          CreatedDate datetime,
          CreatedBy NVARCHAR(100)
)
