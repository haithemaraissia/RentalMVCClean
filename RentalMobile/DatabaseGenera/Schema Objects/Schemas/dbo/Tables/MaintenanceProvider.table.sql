CREATE TABLE [dbo].[MaintenanceProvider] (
    [MaintenanceProviderId] INT              IDENTITY (1, 1) NOT NULL,
    [FirstName]             NVARCHAR (50)    NULL,
    [LastName]              NVARCHAR (50)    NULL,
    [Address]               NVARCHAR (255)   NULL,
    [EmailAddress]          NVARCHAR (50)    NULL,
    [Description]           NVARCHAR (300)   NULL,
    [GUID]                  UNIQUEIDENTIFIER NOT NULL,
    [VCard]                 NVARCHAR (100)   NULL,
    [Skype]                 NVARCHAR (100)   NULL,
    [Twitter]               NVARCHAR (100)   NULL,
    [LinkedIn]              NVARCHAR (100)   NULL,
    [GooglePlus]            NVARCHAR (100)   NULL,
    [Photo]                 NVARCHAR (MAX)   NULL,
    [GoogleMap]             NVARCHAR (MAX)   NULL,
    [Country]               VARCHAR (128)    NULL,
    [Region]                VARCHAR (128)    NULL,
    [City]                  VARCHAR (128)    NULL,
    [Zip]                   NVARCHAR (20)    NULL,
    [CountryCode]           VARCHAR (3)      NULL
);

