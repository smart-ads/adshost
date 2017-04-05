CREATE TABLE [acc].[WebMaster]
(
	[Id] INT NOT NULL IDENTITY, 
    [Name] VARCHAR(255) NOT NULL, 
    CONSTRAINT [PK_WebMaster] PRIMARY KEY ([Id])
)

GO

CREATE UNIQUE INDEX [UK_WebMaster#Name] ON [acc].[WebMaster] ([Name])

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Идентификатор',
    @level0type = N'SCHEMA',
    @level0name = N'acc',
    @level1type = N'TABLE',
    @level1name = N'WebMaster',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Имя',
    @level0type = N'SCHEMA',
    @level0name = N'acc',
    @level1type = N'TABLE',
    @level1name = N'WebMaster',
    @level2type = N'COLUMN',
    @level2name = N'Name'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Веб мастер',
    @level0type = N'SCHEMA',
    @level0name = N'acc',
    @level1type = N'TABLE',
    @level1name = N'WebMaster',
    @level2type = NULL,
    @level2name = NULL