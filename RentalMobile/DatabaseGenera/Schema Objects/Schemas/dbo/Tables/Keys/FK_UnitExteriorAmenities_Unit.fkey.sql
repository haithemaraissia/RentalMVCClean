ALTER TABLE [dbo].[UnitExteriorAmenities]
    ADD CONSTRAINT [FK_UnitExteriorAmenities_Unit] FOREIGN KEY ([UnitId]) REFERENCES [dbo].[Unit] ([UnitId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

