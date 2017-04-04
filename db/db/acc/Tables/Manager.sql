CREATE TABLE [acc].[Manager]
(
	[Id] INT NOT NULL IDENTITY, 
    [Name] VARCHAR(255) NOT NULL, 
    CONSTRAINT [PK_Manager] PRIMARY KEY ([Id]) 
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Менеджер',
    @level0type = N'SCHEMA',
    @level0name = N'acc',
    @level1type = N'TABLE',
    @level1name = N'Manager',
    @level2type = NULL,
    @level2name = NULL
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Имя',
    @level0type = N'SCHEMA',
    @level0name = N'acc',
    @level1type = N'TABLE',
    @level1name = N'Manager',
    @level2type = N'COLUMN',
    @level2name = 'Name'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Идентификатор',
    @level0type = N'SCHEMA',
    @level0name = N'acc',
    @level1type = N'TABLE',
    @level1name = N'Manager',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO

CREATE UNIQUE INDEX [IX_Manager#Name] ON [acc].[Manager] ([Name])
