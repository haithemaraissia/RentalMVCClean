CREATE TABLE [dbo].[UnitInteriorAmenities] (
    [UnitId]                    INT NOT NULL,
    [CoolingTypeId]             INT NOT NULL,
    [HeatingTypeId]             INT NOT NULL,
    [Fireplace]                 BIT NOT NULL,
    [Hot Tub/Spa]               BIT NOT NULL,
    [Cable Ready]               BIT NOT NULL,
    [Attic]                     BIT NOT NULL,
    [BasementTypeId]            INT NOT NULL,
    [Double Pane/Storm Windows] BIT NOT NULL,
    [FloorCoveringId]           INT NOT NULL,
    [FoundationTypeId]          INT NOT NULL,
    [Kitchen Island]            BIT NOT NULL,
    [Vaulted Ceiling]           BIT NOT NULL,
    [Ceiling Fan]               BIT NOT NULL,
    [Jetted Tub]                BIT NOT NULL,
    [Floor]                     INT NOT NULL
);

