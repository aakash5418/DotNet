
--Todo: Karthick Code Review
GO
CREATE PROCEDURE DELETERETURN
	@ReturnID BIGINT
AS 
BEGIN
IF EXISTS(SELECT
			PurchaseID 
		FROM 
			_Return 
		WHERE 
			ReturnID = @ReturnID)
DELETE FROM 
	_Return 
WHERE 
	ReturnID   = @ReturnID
END