ALTER TABLE [dbo].[MaintenanceExteriors]
    ADD CONSTRAINT [FK_MaintenanceExteriors_MaintenanceCompanyLookUp] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[MaintenanceCompanyLookUp] ([CompanyId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

