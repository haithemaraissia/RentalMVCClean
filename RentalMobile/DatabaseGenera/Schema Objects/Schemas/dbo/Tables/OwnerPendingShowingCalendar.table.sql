CREATE TABLE [dbo].[OwnerPendingShowingCalendar] (
    [EventID]            INT            IDENTITY (1, 1) NOT NULL,
    [EventTitle]         NVARCHAR (100) NULL,
    [StartDate]          DATETIME       NULL,
    [EndDate]            DATETIME       NULL,
    [IsAllDay]           BIT            NULL,
    [OwnerId]            INT            NOT NULL,
    [UnitId]             INT            NOT NULL,
    [RequesterName]      NVARCHAR (256) NULL,
    [RequesterEmail]     NVARCHAR (256) NULL,
    [RequesterTelephone] NVARCHAR (22)  NULL
);

