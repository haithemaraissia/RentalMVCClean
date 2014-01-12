ALTER TABLE [dbo].[MaintenanceOrder]
    ADD CONSTRAINT [FK_MaintenanceOrder_UrgencyType] FOREIGN KEY ([UrgencyID]) REFERENCES [dbo].[UrgencyType] ([UrgencyTypeID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

