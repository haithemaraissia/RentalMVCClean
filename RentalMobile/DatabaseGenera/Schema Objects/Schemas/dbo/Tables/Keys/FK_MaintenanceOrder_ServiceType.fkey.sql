ALTER TABLE [dbo].[MaintenanceOrder]
    ADD CONSTRAINT [FK_MaintenanceOrder_ServiceType] FOREIGN KEY ([ServiceTypeID]) REFERENCES [dbo].[ServiceType] ([ServiceTypeID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

