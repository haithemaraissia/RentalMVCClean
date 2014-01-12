CREATE TABLE [dbo].[UnitGallery] (
    [UnitGalleryId] INT            IDENTITY (1, 1) NOT NULL,
    [Path]          NVARCHAR (MAX) NOT NULL,
    [Caption]       NVARCHAR (30)  NOT NULL,
    [Rank]          INT            NOT NULL,
    [UnitId]        INT            NOT NULL
);

