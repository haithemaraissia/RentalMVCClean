CREATE TABLE [dbo].[TenantSavedSearch] (
    [SearchId]   INT            NOT NULL,
    [TenantId]   INT            NOT NULL,
    [Search]     NVARCHAR (MAX) NOT NULL,
    [SearchDate] DATE           NOT NULL
);

