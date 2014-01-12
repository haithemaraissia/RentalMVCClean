ALTER TABLE [dbo].[UnitAppliance]
    ADD CONSTRAINT [FK_UnitAppliance_Unit] FOREIGN KEY ([UnitId]) REFERENCES [dbo].[Unit] ([UnitId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

