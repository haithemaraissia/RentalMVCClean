ALTER TABLE [dbo].[MaintenanceUtilities]
    ADD CONSTRAINT [FK_MaintenanceUtilities_MaintenanceCompanyLookUp] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[MaintenanceCompanyLookUp] ([CompanyId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

