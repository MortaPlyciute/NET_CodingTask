CREATE TABLE [dbo].[TaxByMunicipality]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [MunicipalityId] INT NOT NULL, 
    [TaxId] INT NOT NULL, 
    CONSTRAINT [FK_TaxByMunicipality_Tax] FOREIGN KEY ([TaxId]) REFERENCES [Tax]([Id]),
	CONSTRAINT [FK_TaxByMunicipality_Municipality] FOREIGN KEY ([MunicipalityId]) REFERENCES [Municipality]([Id])
)
