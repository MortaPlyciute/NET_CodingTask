CREATE PROCEDURE [dbo].[FindTaxes]
	@municipality nvarchar(30) not null
AS
	SELECT	[Name] AS MunicipalityName
			,[Value] AS TaxValue
			,[Type] AS TaxType
			,StartDate AS TaxStartDate
			,EndDate AS TaxEndDate
	FROM	--Tax
			--,Municipality AS M
			TaxByMunicipality AS T
			INNER JOIN Tax ON T.TaxId = Tax.Id
			INNER JOIN Municipality ON T.MunicipalityId = Municipality.Id
	WHERE	--Tax.Id = T.TaxId
			--AND M.Id = T.MunicipalityId
			T.MunicipalityId = @municipality
