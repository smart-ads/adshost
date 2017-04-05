CREATE TABLE [acc].[Advertiser] (
    [Id] INT NOT NULL IDENTITY,
    [Name] VARCHAR(255) NOT NULL, 
    CONSTRAINT [PK_Advertiser] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Рекламодатель',
    @level0type = N'SCHEMA',
    @level0name = N'acc',
    @level1type = N'TABLE',
    @level1name = N'Advertiser',
    @level2type = NULL,
    @level2name = NULL
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Идентификатор',
    @level0type = N'SCHEMA',
    @level0name = N'acc',
    @level1type = N'TABLE',
    @level1name = N'Advertiser',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Имя',
    @level0type = N'SCHEMA',
    @level0name = N'acc',
    @level1type = N'TABLE',
    @level1name = N'Advertiser',
    @level2type = N'COLUMN',
    @level2name = N'Name'
GO

CREATE UNIQUE INDEX [UK_Advertiser#Name] ON [acc].[Advertiser] ([Name])
