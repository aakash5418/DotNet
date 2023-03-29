--Todo: Karthick Code Review

GO
CREATE PROCEDURE sp_GetReturnId
	@ReturnID BIGINT
AS
BEGIN
SELECT
	* 
FROM 
	_Return
WHERE 
	ReturnID = @ReturnID
END
GO