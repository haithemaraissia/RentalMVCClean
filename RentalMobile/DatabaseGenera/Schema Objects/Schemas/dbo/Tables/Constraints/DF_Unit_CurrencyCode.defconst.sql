ALTER TABLE [dbo].[Unit]
    ADD CONSTRAINT [DF_Unit_CurrencyCode] DEFAULT ((0)) FOR [CurrencyCode];

