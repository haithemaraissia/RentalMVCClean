ALTER TABLE [dbo].[MaintenanceCrew]
    ADD CONSTRAINT [FK_CrewMaintenance_MaintenanceOrder] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[MaintenanceOrder] ([MaintenanceID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

