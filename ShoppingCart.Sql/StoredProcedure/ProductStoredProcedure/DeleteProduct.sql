--Todo: Karthick Code Review
GO
CREATE PROCEDURE sp_DeleteProduct
	@ProductId BIGINT
AS
BEGIN
DELETE FROM 
	Product
WHERE
	ProductId = @ProductId
END
GO