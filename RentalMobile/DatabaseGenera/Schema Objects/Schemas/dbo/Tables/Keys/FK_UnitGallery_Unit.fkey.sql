﻿ALTER TABLE [dbo].[UnitGallery]
    ADD CONSTRAINT [FK_UnitGallery_Unit] FOREIGN KEY ([UnitId]) REFERENCES [dbo].[Unit] ([UnitId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

