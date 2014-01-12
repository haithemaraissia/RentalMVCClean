ALTER TABLE [dbo].[Specialist]
    ADD CONSTRAINT [DF_Specialist_PercentageofCompletion] DEFAULT ((0)) FOR [PercentageofCompletion];

