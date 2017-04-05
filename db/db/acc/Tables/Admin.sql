CREATE TABLE [acc].[Admin]
(
	[Id] INT NOT NULL, 
    [Name] VARCHAR(255) NOT NULL, 
    [IsSuper] BIT NOT NULL constraint DF_Admin#Name DEFAULT 0, 
    CONSTRAINT [PK_Admin] PRIMARY KEY ([Id]) 
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Идентификатор',
    @level0type = N'SCHEMA',
    @level0name = N'acc',
    @level1type = N'TABLE',
    @level1name = N'Admin',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Администратор',
    @level0type = N'SCHEMA',
    @level0name = N'acc',
    @level1type = N'TABLE',
    @level1name = N'Admin',
    @level2type = NULL,
    @level2name = NULL
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Имя',
    @level0type = N'SCHEMA',
    @level0name = N'acc',
    @level1type = N'TABLE',
    @level1name = N'Admin',
    @level2type = N'COLUMN',
    @level2name = N'Name'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Супер-администратор',
    @level0type = N'SCHEMA',
    @level0name = N'acc',
    @level1type = N'TABLE',
    @level1name = N'Admin',
    @level2type = N'COLUMN',
    @level2name = N'IsSuper'
GO

CREATE UNIQUE INDEX [UK_Admin#Name] ON [acc].[Admin] ([Name])
