ALTER TABLE [dbo].[MaintenanceCompanySpecialization]
    ADD CONSTRAINT [DF_MaintenanceCompanySpecialization_Rate] DEFAULT ((0)) FOR [Rate];

