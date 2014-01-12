ALTER TABLE [dbo].[MaintenanceCompany]
    ADD CONSTRAINT [FK_MaintenanceCompany_MaintenanceCompanyLookUp] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[MaintenanceCompanyLookUp] ([CompanyId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

