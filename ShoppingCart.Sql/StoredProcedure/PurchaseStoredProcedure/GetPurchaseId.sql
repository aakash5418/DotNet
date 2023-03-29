--Todo: Karthick Code Review

GO
CREATE PROCEDURE sp_GETPURCHASEID
	@PurchaseID BIGINT
AS
BEGIN
SELECT 
	* 
FROM 
	Purchase 
WHERE 
	PurchaseID = @PurchaseID
END
GO