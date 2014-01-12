ALTER TABLE [dbo].[UnitInteriorAmenities]
    ADD CONSTRAINT [DF_UnitInteriorAmenities_Floor] DEFAULT ((1)) FOR [Floor];

