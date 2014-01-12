ALTER TABLE [dbo].[MaintenanceCompanySpecialization]
    ADD CONSTRAINT [DF_MaintenanceCompanySpecialization_Currency] DEFAULT (N'U.S') FOR [Currency];

