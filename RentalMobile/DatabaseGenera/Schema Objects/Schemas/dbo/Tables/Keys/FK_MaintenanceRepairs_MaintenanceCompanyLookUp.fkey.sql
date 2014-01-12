ALTER TABLE [dbo].[MaintenanceRepairs]
    ADD CONSTRAINT [FK_MaintenanceRepairs_MaintenanceCompanyLookUp] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[MaintenanceCompanyLookUp] ([CompanyId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

