CREATE TABLE [dbo].[SpecialistPendingTeamInvitation] (
    [PendingTeamInvitationID] INT           IDENTITY (1, 1) NOT NULL,
    [TeamId]                  INT           NOT NULL,
    [TeamName]                NVARCHAR (50) NULL,
    [MaintenanceProviderId]   INT           NOT NULL,
    [SpecialistID]            INT           NOT NULL
);

