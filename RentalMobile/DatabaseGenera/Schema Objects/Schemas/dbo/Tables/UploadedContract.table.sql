CREATE TABLE [dbo].[UploadedContract] (
    [UploadedImageId]   INT            IDENTITY (1, 1) NOT NULL,
    [UploadedImagePath] NVARCHAR (MAX) NOT NULL,
    [UploaderId]        INT            NOT NULL,
    [UploaderRole]      CHAR (10)      NOT NULL
);

