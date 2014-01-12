ALTER TABLE [dbo].[MaintenanceCompanySpecialization]
    ADD CONSTRAINT [DF_MaintenanceCompanySpecialization_CurrencyID] DEFAULT ((1)) FOR [CurrencyID];

