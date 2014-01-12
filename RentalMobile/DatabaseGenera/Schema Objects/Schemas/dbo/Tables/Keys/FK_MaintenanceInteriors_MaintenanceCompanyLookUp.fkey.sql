ALTER TABLE [dbo].[MaintenanceInteriors]
    ADD CONSTRAINT [FK_MaintenanceInteriors_MaintenanceCompanyLookUp] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[MaintenanceCompanyLookUp] ([CompanyId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

