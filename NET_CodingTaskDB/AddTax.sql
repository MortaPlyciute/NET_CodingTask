CREATE PROCEDURE [dbo].[AddTax]
	@municipality nvarchar(30) not null
	,@taxValue decimal(10,4) not null
	,@taxType int not null
	,@taxStartDate date not null
	,@taxEndtDate date
AS
	DECLARE @municipalityId int;
	DECLARE @newTaxId int;

	INSERT INTO Tax ([Value], [Type], StartDate, EndDate)
	VALUES (@taxValue, @taxType, @taxStartDate, @taxEndtDate);

	SELECT @newTaxId = SCOPE_IDENTITY();

	SELECT @municipalityId = M.Id
	FROM Municipality AS M
	WHERE M.[Name] = @municipality

	IF @municipalityId IS NULL
	BEGIN
		INSERT INTO Municipality([Name])
		VALUES (@municipalityId);

		SELECT @municipalityId = M.Id
		FROM Municipality AS M
		WHERE M.[Name] = @municipality
	END

	INSERT INTO TaxByMunicipality(TaxId, MunicipalityId)
	VALUES (@newTaxId, @municipalityId);
