ALTER TABLE [dbo].[MaintenancePhoto]
    ADD CONSTRAINT [FK_MaintenancePhoto_MaintenanceOrder] FOREIGN KEY ([MaintenanceID]) REFERENCES [dbo].[MaintenanceOrder] ([MaintenanceID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

