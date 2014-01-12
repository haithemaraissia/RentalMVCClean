ALTER TABLE [dbo].[TenantShowing]
    ADD CONSTRAINT [FK_TenantShowing_Tenant] FOREIGN KEY ([TenantId]) REFERENCES [dbo].[Tenant] ([TenantId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

