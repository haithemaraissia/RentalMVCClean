﻿ALTER TABLE [dbo].[TenantFavorite]
    ADD CONSTRAINT [PK_TenantFavorite] PRIMARY KEY CLUSTERED ([FavoriteId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

