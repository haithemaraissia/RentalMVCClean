ALTER TABLE [dbo].[MaintenanceNewConstruction]
    ADD CONSTRAINT [FK_MaintenanceNewConstruction_MaintenanceCompanyLookUp] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[MaintenanceCompanyLookUp] ([CompanyId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

