CREATE TABLE [dbo].[UnitCommunityAmenities] (
    [UnitId]                    INT           NOT NULL,
    [Neighborhood Name]         VARCHAR (255) NULL,
    [Elementary School]         VARCHAR (255) NULL,
    [High School]               VARCHAR (255) NULL,
    [School District]           VARCHAR (255) NULL,
    [Middle School]             VARCHAR (255) NULL,
    [County Name]               VARCHAR (255) NULL,
    [Assisted Living Community] BIT           NOT NULL,
    [Over 55 Active Community]  BIT           NOT NULL,
    [Disability Access]         BIT           NOT NULL,
    [Controlled Access]         BIT           NOT NULL,
    [Community Pool]            BIT           NOT NULL
);

