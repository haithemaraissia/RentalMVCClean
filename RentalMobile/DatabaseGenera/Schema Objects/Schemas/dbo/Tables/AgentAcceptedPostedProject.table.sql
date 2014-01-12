CREATE TABLE [dbo].[AgentAcceptedPostedProject] (
    [ID]            INT           IDENTITY (1, 1) NOT NULL,
    [ProjectID]     INT           NOT NULL,
    [AgentId]       INT           NULL,
    [SpecialistId]  INT           NULL,
    [ServiceTypeID] INT           NOT NULL,
    [Budget]        FLOAT         NULL,
    [Currency]      NVARCHAR (20) NULL,
    [CurrencyCode]  INT           NULL,
    [Date]          SMALLDATETIME NULL
);

