--Todo: Karthick Code Review

GO
CREATE PROCEDURE sp_GetAllProducts
	@ProductId BIGINT
AS
BEGIN
SELECT 
	*
FROM
	Product
WHERE
	ProductId = @ProductId
END
GO