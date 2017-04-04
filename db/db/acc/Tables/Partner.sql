CREATE TABLE [acc].[Partner] (
    [Id] INT NOT NULL IDENTITY,
    [Name] VARCHAR(255) NOT NULL, 
    CONSTRAINT [PK_Partner] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO


CREATE UNIQUE INDEX [IX_Partner#Name] ON [acc].[Partner] ([Name])

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Имя',
    @level0type = N'SCHEMA',
    @level0name = N'acc',
    @level1type = N'TABLE',
    @level1name = N'Partner',
    @level2type = N'COLUMN',
    @level2name = N'Name'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Идентификатор',
    @level0type = N'SCHEMA',
    @level0name = N'acc',
    @level1type = N'TABLE',
    @level1name = N'Partner',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Партнер',
    @level0type = N'SCHEMA',
    @level0name = N'acc',
    @level1type = N'TABLE',
    @level1name = N'Partner',
    @level2type = NULL,
    @level2name = NULL