CREATE TABLE [dbo].[Employees] (
    [Id]    INT           IDENTITY (1, 1) NOT NULL,
    [FName] NVARCHAR (15) NOT NULL,
    [LName] NVARCHAR (15) NOT NULL,
    [Title] NVARCHAR(50)           NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([Id] ASC)
);

