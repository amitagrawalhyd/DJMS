
CREATE PROCEDURE [dbo].[usp_GetDistricts]
AS
BEGIN	
	SET NOCOUNT ON;

    SELECT
		D.Id,
		D.StateId,
		D.Abbreviation,
		CONCAT(D.Name,'-',S.Name,'-',C.Name) AS Name
	FROM Countrys C (NOLOCK)
	JOIN States S (NOLOCK) ON S.CountryId = C.Id
	JOIN Districts D (NOLOCK) ON D.StateId = S.Id
END
