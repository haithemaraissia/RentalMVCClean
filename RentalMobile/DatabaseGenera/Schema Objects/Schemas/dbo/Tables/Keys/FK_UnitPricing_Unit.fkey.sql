﻿ALTER TABLE [dbo].[UnitPricing]
    ADD CONSTRAINT [FK_UnitPricing_Unit] FOREIGN KEY ([UnitId]) REFERENCES [dbo].[Unit] ([UnitId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

