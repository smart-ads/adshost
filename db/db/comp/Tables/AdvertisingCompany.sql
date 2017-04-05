CREATE TABLE [comp].[AdvertisingCompany]
(
	[Id] INT NOT NULL, 
    [Name] VARCHAR(255) NOT NULL, 
    [CreationDate] DATETIMEOFFSET NOT NULL, 
    [IsActive] BIT NOT NULL, 
    [CreatedBy] INT NOT NULL, 
    CONSTRAINT [PK_AdvertisingCompany] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_AdvertisingCompany_Advertizer] FOREIGN KEY (CreatedBy) REFERENCES acc.Advertiser([Id]) 
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Рекламная компания',
    @level0type = N'SCHEMA',
    @level0name = N'comp',
    @level1type = N'TABLE',
    @level1name = N'AdvertisingCompany',
    @level2type = NULL,
    @level2name = NULL
GO

CREATE UNIQUE INDEX [UK_AdvertisingCompany#Name] ON [comp].[AdvertisingCompany] ([Name])

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Идентификатор',
    @level0type = N'SCHEMA',
    @level0name = N'comp',
    @level1type = N'TABLE',
    @level1name = N'AdvertisingCompany',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Наименование',
    @level0type = N'SCHEMA',
    @level0name = N'comp',
    @level1type = N'TABLE',
    @level1name = N'AdvertisingCompany',
    @level2type = N'COLUMN',
    @level2name = N'Name'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Дата создания',
    @level0type = N'SCHEMA',
    @level0name = N'comp',
    @level1type = N'TABLE',
    @level1name = N'AdvertisingCompany',
    @level2type = N'COLUMN',
    @level2name = N'CreationDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Активная',
    @level0type = N'SCHEMA',
    @level0name = N'comp',
    @level1type = N'TABLE',
    @level1name = N'AdvertisingCompany',
    @level2type = N'COLUMN',
    @level2name = N'IsActive'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Кем создана',
    @level0type = N'SCHEMA',
    @level0name = N'comp',
    @level1type = N'TABLE',
    @level1name = N'AdvertisingCompany',
    @level2type = N'COLUMN',
    @level2name = N'CreatedBy'