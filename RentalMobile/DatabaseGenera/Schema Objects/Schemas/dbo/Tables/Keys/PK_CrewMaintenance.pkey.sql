﻿ALTER TABLE [dbo].[MaintenanceCrew]
    ADD CONSTRAINT [PK_CrewMaintenance] PRIMARY KEY CLUSTERED ([CrewID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

