﻿CREATE TABLE [dbo].[OwnerRejectedApplication] (
    [ApplicationId]                    INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]                        NVARCHAR (255) NULL,
    [LastName]                         NVARCHAR (255) NULL,
    [MiddleName]                       NVARCHAR (255) NULL,
    [DateofBirth]                      DATE           NULL,
    [SocialSecurityNumber]             VARCHAR (12)   NULL,
    [DriverLicense]                    VARCHAR (20)   NULL,
    [Phone]                            VARCHAR (32)   NULL,
    [CellPhone]                        VARCHAR (32)   NULL,
    [EmailAddress]                     NVARCHAR (255) NULL,
    [CoSignerName]                     NVARCHAR (255) NULL,
    [CoSignerAddress]                  NVARCHAR (255) NULL,
    [CoSignerCity]                     VARCHAR (50)   NULL,
    [CoSignerState]                    VARCHAR (30)   NULL,
    [CoSignerZipcode]                  VARCHAR (20)   NULL,
    [CoSignerPhone]                    VARCHAR (32)   NULL,
    [CoSignerRelationShip]             VARCHAR (50)   NULL,
    [CoSignerEmailAddress]             NVARCHAR (255) NULL,
    [OtherOccupant1Name]               NVARCHAR (50)  NULL,
    [IsOccupant1Adult]                 BIT            NULL,
    [RelationshipOccupant1ToApplicant] VARCHAR (50)   NULL,
    [OtherOccupant2Name]               NVARCHAR (50)  NULL,
    [IsOccupant2Adult]                 BIT            NULL,
    [RelationshipOccupant2ToApplicant] VARCHAR (50)   NULL,
    [OtherOccupant3Name]               NVARCHAR (50)  NULL,
    [IsOccupant3Adult]                 BIT            NULL,
    [RelationshipOccupant3ToApplicant] VARCHAR (50)   NULL,
    [OtherOccupant4Name]               NVARCHAR (50)  NULL,
    [IsOccupant4Adult]                 BIT            NULL,
    [RelationshipOccupant4ToApplicant] VARCHAR (50)   NULL,
    [EmployerName]                     NVARCHAR (255) NULL,
    [Income]                           NVARCHAR (50)  NULL,
    [WorkStartDate]                    DATE           NULL,
    [WorkEndDate]                      DATE           NULL,
    [EmployerAddress]                  NVARCHAR (255) NULL,
    [EmployerCity]                     VARCHAR (50)   NULL,
    [EmployerState]                    VARCHAR (30)   NULL,
    [EmployerZipcode]                  VARCHAR (20)   NULL,
    [EmployerPhone]                    VARCHAR (32)   NULL,
    [EmployerFax]                      VARCHAR (32)   NULL,
    [CurrentLandloard]                 NVARCHAR (255) NULL,
    [CurrentLandLoardPhone]            VARCHAR (32)   NULL,
    [CurrentLandLoardFax]              VARCHAR (32)   NULL,
    [CurrentAddress]                   NVARCHAR (255) NULL,
    [CurrentAddressCity]               VARCHAR (50)   NULL,
    [CurrentAddressState]              VARCHAR (30)   NULL,
    [CurrentAddressZip]                VARCHAR (20)   NULL,
    [Rent]                             VARCHAR (30)   NULL,
    [CurrentRentStartDate]             DATE           NULL,
    [CurrentRentEndDate]               DATE           NULL,
    [PreviousLandloard]                NVARCHAR (255) NULL,
    [PreviousLandLoardPhone]           VARCHAR (32)   NULL,
    [PreviousLandLoardFax]             VARCHAR (32)   NULL,
    [PreviousAddress]                  NVARCHAR (255) NULL,
    [PreviousAddressCity]              VARCHAR (50)   NULL,
    [PreviousAddressState]             VARCHAR (30)   NULL,
    [PreviousAddressZip]               VARCHAR (20)   NULL,
    [PreviousRent]                     VARCHAR (30)   NULL,
    [PreviousRentStartDate]            DATE           NULL,
    [PreviousRentEndDate]              DATE           NULL,
    [EmergencyContactName]             NVARCHAR (255) NULL,
    [EmergencyContactRelationShip]     VARCHAR (50)   NULL,
    [EmergencyContactPhone]            VARCHAR (32)   NULL,
    [EmergencyContactAddress]          NVARCHAR (255) NULL,
    [EmergencyContactCity]             VARCHAR (50)   NULL,
    [EmergencyContactState]            VARCHAR (30)   NULL,
    [EmergencyContactZipCode]          VARCHAR (20)   NULL,
    [Pets]                             BIT            NULL,
    [PetsNumber]                       INT            NULL,
    [Pet1Brand]                        NVARCHAR (50)  NULL,
    [Pet1Age]                          INT            NULL,
    [Pet1Weight]                       VARCHAR (20)   NULL,
    [Pet2Brand]                        NVARCHAR (50)  NULL,
    [Pet2Age]                          INT            NULL,
    [Pet2Weight]                       VARCHAR (20)   NULL,
    [Vehicle1Make]                     VARCHAR (50)   NULL,
    [Vehicle1Model]                    NVARCHAR (50)  NULL,
    [Vehicle1Year]                     INT            NULL,
    [Vehicle1Color]                    VARCHAR (50)   NULL,
    [Vehicle1LicensePlate]             VARCHAR (20)   NULL,
    [Vehicle2Make]                     VARCHAR (50)   NULL,
    [Vehicle2Model]                    NVARCHAR (50)  NULL,
    [Vehicle2Year]                     INT            NULL,
    [Vehicle2Color]                    VARCHAR (50)   NULL,
    [Vehicle2LicensePlate]             VARCHAR (20)   NULL,
    [Vehicle3Make]                     VARCHAR (50)   NULL,
    [Vehicle3Model]                    NVARCHAR (50)  NULL,
    [Vehicle3Year]                     INT            NULL,
    [Vehicle3Color]                    VARCHAR (50)   NULL,
    [Vehicle3LicensePlate]             VARCHAR (20)   NULL,
    [Vehicle4Make]                     VARCHAR (50)   NULL,
    [Vehicle4Model]                    NVARCHAR (50)  NULL,
    [Vehicle4Year]                     INT            NULL,
    [Vehicle4Color]                    VARCHAR (50)   NULL,
    [Vehicle4LicensePlate]             VARCHAR (20)   NULL,
    [Bankruptcy]                       BIT            NULL,
    [LeaseDefaulted]                   BIT            NULL,
    [RefusedtoPayRent]                 BIT            NULL,
    [EvictedFromRental]                BIT            NULL,
    [ConvictedofFelony]                BIT            NULL,
    [TenantId]                         INT            NULL,
    [OwnerId]                          INT            NOT NULL
);

