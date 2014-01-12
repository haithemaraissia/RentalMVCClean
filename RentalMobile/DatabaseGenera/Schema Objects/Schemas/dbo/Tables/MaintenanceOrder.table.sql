CREATE TABLE [dbo].[MaintenanceOrder] (
    [MaintenanceID]   INT            IDENTITY (1, 1) NOT NULL,
    [UnitID]          INT            NOT NULL,
    [MaintenanceDate] DATETIME       NOT NULL,
    [UrgencyID]       INT            NOT NULL,
    [Description]     NVARCHAR (500) NULL,
    [ServiceTypeID]   INT            NOT NULL,
    [PetsinUnit]      BIT            NOT NULL,
    [TenantPresence]  BIT            NOT NULL
);

