ALTER TABLE [dbo].[TenantFavorite]
    ADD CONSTRAINT [FK_TenantFavorite_Tenant] FOREIGN KEY ([TenantId]) REFERENCES [dbo].[Tenant] ([TenantId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

