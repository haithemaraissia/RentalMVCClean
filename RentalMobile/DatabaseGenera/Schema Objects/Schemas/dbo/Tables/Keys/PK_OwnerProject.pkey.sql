﻿ALTER TABLE [dbo].[OwnerProject]
    ADD CONSTRAINT [PK_OwnerProject] PRIMARY KEY CLUSTERED ([ProjectID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

