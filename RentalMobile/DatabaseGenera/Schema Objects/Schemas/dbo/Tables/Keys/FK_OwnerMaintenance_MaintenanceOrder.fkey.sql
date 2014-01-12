ALTER TABLE [dbo].[OwnerMaintenance]
    ADD CONSTRAINT [FK_OwnerMaintenance_MaintenanceOrder] FOREIGN KEY ([MaintenanceID]) REFERENCES [dbo].[MaintenanceOrder] ([MaintenanceID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

