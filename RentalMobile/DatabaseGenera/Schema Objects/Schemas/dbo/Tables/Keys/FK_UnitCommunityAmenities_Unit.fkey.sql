﻿ALTER TABLE [dbo].[UnitCommunityAmenities]
    ADD CONSTRAINT [FK_UnitCommunityAmenities_Unit] FOREIGN KEY ([UnitId]) REFERENCES [dbo].[Unit] ([UnitId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

