﻿ALTER TABLE [dbo].[Unit]
    ADD CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED ([UnitId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

