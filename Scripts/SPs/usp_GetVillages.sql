CREATE PROCEDURE [dbo].[usp_GetVillages]
AS
BEGIN	
	SET NOCOUNT ON;

    SELECT
		V.Id,
		V.DistrictId,
		CONCAT(V.Name,'-',D.Name,'-',S.Name,'-',C.Name) AS Name
	FROM Countrys C (NOLOCK)
	JOIN States S (NOLOCK) ON S.CountryId = C.Id
	JOIN Districts D (NOLOCK) ON D.StateId = S.Id
	JOIN Villages V (NOLOCK) ON V.DistrictId = D.Id
END
