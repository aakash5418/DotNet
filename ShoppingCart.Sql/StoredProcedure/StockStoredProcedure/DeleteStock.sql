--Todo: Karthick Code Review

GO
CREATE PROCEDURE sp_DeleteStock
	@StockId BIGINT
AS
BEGIN
DELETE FROM 
	Stock 
WHERE 
	StocktID = @StockId
END
GO