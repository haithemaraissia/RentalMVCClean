CREATE TABLE [dbo].[UnitPricing] (
    [UnitId]             INT           NOT NULL,
    [Rent]               FLOAT         NULL,
    [CurrencyId]         INT           NULL,
    [AvailableDate]      SMALLDATETIME NULL,
    [Deposit]            FLOAT         NULL,
    [ApplicationFee]     FLOAT         NULL,
    [Section 8 Eligible] BIT           NULL
);

