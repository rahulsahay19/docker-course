CREATE TABLE [dbo].[Movies] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (MAX) NULL,
    [DirectorName] NVARCHAR (MAX) NULL,
    [ReleaseYear]  NVARCHAR (MAX) NULL,
    [Genre]        NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED ([Id] ASC)
);

