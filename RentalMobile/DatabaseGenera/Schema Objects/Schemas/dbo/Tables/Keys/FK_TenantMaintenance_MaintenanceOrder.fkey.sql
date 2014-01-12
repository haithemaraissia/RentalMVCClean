ALTER TABLE [dbo].[TenantMaintenance]
    ADD CONSTRAINT [FK_TenantMaintenance_MaintenanceOrder] FOREIGN KEY ([MaintenanceID]) REFERENCES [dbo].[MaintenanceOrder] ([MaintenanceID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

