﻿CREATE TABLE [dbo].[Application] (
    [Id]           INT          NOT NULL,
    [Name]         VARCHAR (50) NOT NULL UNIQUE,
    [CreationDate] DATETIME     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Module] (
    [Id]           INT          NOT NULL,
    [Name]         VARCHAR (50) NOT NULL UNIQUE,
    [CreationDate] DATETIME     NOT NULL,
    [Parent]       INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Parent]) REFERENCES [dbo].[Application] ([Id])
);

CREATE TABLE [dbo].[Subscription] (
    [Id]           INT          NOT NULL,
    [Name]         VARCHAR (50) NOT NULL UNIQUE,
    [CreationDate] DATETIME     NOT NULL,
    [Parent]       INT          NOT NULL,
    [Event]        VARCHAR (50) NOT NULL,
    [Endpoint]     VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Parent]) REFERENCES [dbo].[Module] ([Id])
);

CREATE TABLE [dbo].[Data] (
    [Id]           INT          NOT NULL,
    [Content]      VARCHAR (50) NOT NULL,
    [CreationDate] DATETIME     NOT NULL,
    [Parent]       INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Parent]) REFERENCES [dbo].[Module] ([Id])
);