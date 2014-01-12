ALTER TABLE [dbo].[UnitLuxuryAmenities]
    ADD CONSTRAINT [FK_UnitLuxuryAmenities_Unit] FOREIGN KEY ([UnitId]) REFERENCES [dbo].[Unit] ([UnitId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

