﻿ALTER TABLE [dbo].[UnitFeature]
    ADD CONSTRAINT [FK_UnitFeature_Unit] FOREIGN KEY ([UnitId]) REFERENCES [dbo].[Unit] ([UnitId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

