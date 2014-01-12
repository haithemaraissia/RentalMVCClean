CREATE TABLE [dbo].[MaintenancePhoto] (
    [MaintenanceID] INT            NOT NULL,
    [PhotoID]       INT            IDENTITY (1, 1) NOT NULL,
    [PhotoPath]     NVARCHAR (MAX) NOT NULL
);

