CREATE TABLE [dbo].[MaintenanceProviderAcceptedJobs] (
    [MaintenanceProviderId] INT            IDENTITY (1, 1) NOT NULL,
    [TenantId]              INT            NULL,
    [TenantName]            NVARCHAR (256) NULL,
    [TenantEmailAddress]    NVARCHAR (256) NULL,
    [PropertyId]            INT            NULL,
    [StartDate]             DATETIME       NULL,
    [EndDate]               DATETIME       NULL
);

