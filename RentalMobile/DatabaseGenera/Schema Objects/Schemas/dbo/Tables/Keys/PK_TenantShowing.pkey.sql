﻿ALTER TABLE [dbo].[TenantShowing]
    ADD CONSTRAINT [PK_TenantShowing] PRIMARY KEY CLUSTERED ([ShowingId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

