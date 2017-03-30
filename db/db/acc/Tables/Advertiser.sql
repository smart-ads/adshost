CREATE TABLE [acc].[Advertiser] (
    [Id] INT NOT NULL,
    CONSTRAINT [PK_Advertiser] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Advertiser_User] FOREIGN KEY ([Id]) REFERENCES [acc].[User] ([Id])
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