--Todo: Karthick Code Review

GO
CREATE PROCEDURE sp_UpdateProduct(
	@ProductId BIGINT,
	@ProductName VARCHAR(50),
	@UnitPrice DECIMAL(18,2),
	@UnitDiscount DECIMAL(18,2),
	@ModifiedBy VARCHAR(50),
	@ModifiedDate DATETIME)
AS
BEGIN
UPDATE 
	Product 
SET 
	ProductName = @ProductName,
	UnitPrice = @UnitPrice,
	UnitDiscount = @UnitDiscount,
	ModifiedBy = @ModifiedBy,
	ModifiedDate = GETDATE()
WHERE 
	ProductID = @ProductId
END