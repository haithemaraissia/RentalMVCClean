ALTER TABLE [dbo].[MaintenanceCompanyLookUp]
    ADD CONSTRAINT [DF_CompanyLookUp_Role] DEFAULT ((0)) FOR [Role];

