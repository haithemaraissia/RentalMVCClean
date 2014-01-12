CREATE TABLE [dbo].[ProjectPhoto] (
    [ProjectID] INT            NOT NULL,
    [PhotoID]   INT            IDENTITY (1, 1) NOT NULL,
    [PhotoPath] NVARCHAR (MAX) NOT NULL
);

