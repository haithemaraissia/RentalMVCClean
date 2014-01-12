CREATE TABLE [dbo].[MaintenanceTeam] (
    [TeamId]                INT           IDENTITY (1, 1) NOT NULL,
    [TeamName]              NVARCHAR (50) NULL,
    [MaintenanceProviderId] INT           NOT NULL
);

