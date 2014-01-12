ALTER TABLE [dbo].[UnitInteriorAmenities]
    ADD CONSTRAINT [FK_UnitInteriorAmenities_Unit] FOREIGN KEY ([UnitId]) REFERENCES [dbo].[Unit] ([UnitId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

