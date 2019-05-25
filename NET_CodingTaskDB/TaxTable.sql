CREATE TABLE [dbo].[TaxTable]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [MunicipalityId] INT NOT NULL, 
    [TaxId] INT NOT NULL, 
    CONSTRAINT [FK_TaxTable_Tax] FOREIGN KEY ([TaxId]) REFERENCES [Tax]([Id]),
--	CONSTRAINT [FK_TaxTable_Municipality] FOREIGN KEY ([MunicipalityId]) REFERENCES [Municipality]([Id])
	--FOREIGN KEY([MunicipalityId]) REFERENCES [Municipality]([Id])
)
