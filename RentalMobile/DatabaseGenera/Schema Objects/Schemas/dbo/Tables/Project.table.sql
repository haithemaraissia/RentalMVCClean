CREATE TABLE [dbo].[Project] (
    [ProjectID]     INT            IDENTITY (1, 1) NOT NULL,
    [ServiceTypeID] INT            NOT NULL,
    [Description]   NVARCHAR (500) NULL,
    [PrimaryPhoto]  NVARCHAR (MAX) NULL,
    [Address]       NVARCHAR (255) NULL,
    [GoogleMap]     NVARCHAR (MAX) NULL,
    [Country]       VARCHAR (128)  NULL,
    [State]         NVARCHAR (20)  NULL,
    [Region]        VARCHAR (128)  NULL,
    [City]          VARCHAR (128)  NULL,
    [Zip]           NVARCHAR (20)  NULL,
    [CountryCode]   VARCHAR (3)    NULL,
    [NumberofPhoto] INT            NULL,
    [Budget]        FLOAT          NULL,
    [Currency]      NVARCHAR (20)  NULL,
    [CurrencyCode]  INT            NULL,
    [DaysOnSite]    INT            NULL,
    [AvailableDate] SMALLDATETIME  NULL,
    [PosterRole]    CHAR (10)      NULL,
    [PosterID]      INT            NULL
);

