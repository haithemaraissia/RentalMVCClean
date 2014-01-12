ALTER TABLE [dbo].[TenantSavedSearch]
    ADD CONSTRAINT [FK_TenantSavedSearch_Tenant] FOREIGN KEY ([TenantId]) REFERENCES [dbo].[Tenant] ([TenantId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

