﻿ALTER TABLE [dbo].[MaintenanceCompanyLookUp]
    ADD CONSTRAINT [PK_CompanyLookUp] PRIMARY KEY CLUSTERED ([CompanyId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

