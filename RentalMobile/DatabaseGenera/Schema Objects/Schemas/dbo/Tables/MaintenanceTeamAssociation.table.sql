CREATE TABLE [dbo].[MaintenanceTeamAssociation] (
    [TeamAssociationID]     INT           IDENTITY (1, 1) NOT NULL,
    [TeamId]                INT           NOT NULL,
    [TeamName]              NVARCHAR (50) NULL,
    [MaintenanceProviderId] INT           NOT NULL,
    [SpecialistId]          INT           NOT NULL
);

