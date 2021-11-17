CREATE TABLE [dbo].[Joke] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [JokeQuestion] NVARCHAR (MAX) NOT NULL,
    [JokeAnswer]   NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Joke] PRIMARY KEY CLUSTERED ([ID] ASC)
);

