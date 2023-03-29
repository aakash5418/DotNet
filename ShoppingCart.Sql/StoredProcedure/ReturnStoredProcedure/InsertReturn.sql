--Todo: Karthick Code Review

GO
CREATE PROCEDURE SP_ADDRETURN (
	@PurchaseID BIGINT,
	@ProductID BIGINT,
	@Quantity INT,
	@CreatedBy VARCHAR(50))
AS
BEGIN
DECLARE  
	@ExistProductID BIGINT,
	@ExistQuantity INT,
	@TotalDiscount DECIMAL(18,2)
 SELECT
	@ExistProductID = ProductID,
	@ExistQuantity = Quantity,
	@TotalDiscount = TotalDiscount
 FROM 
	Purchase  
 WHERE 
	PurchaseID = @PurchaseID
DECLARE
	@UnitPrice DECIMAL(18,2),
	@UnitDiscount DECIMAL(18,2)
SELECT
	@UnitPrice = UnitPrice,
	@UnitDiscount = UnitDiscount
FROM 
	Product 
WHERE 
	ProductID = @ProductID
DECLARE
	@ReturnedTotalDiscount DECIMAL(18,2),
	@ReturnedTotalAmount DECIMAL (18,2)
SET 
	@ReturnedTotalDiscount = @Quantity * (@UnitPrice * @UnitDiscount)
SET 
	@ReturnedTotalAmount = ((@Quantity * @UnitPrice) - @TotalDiscount)
INSERT INTO _Return 
	(PurchaseID,
	ProductID,
	ReturnedQuantity,
	ReturnedTotalDiscount,
	ReturnedTotalAmount,
	ReturnedDate,
	CreatedBy,
	CreatedDate)
VALUES
	(@PurchaseID,
	@ProductID,
	@Quantity,
	@UnitPrice,
	@UnitDiscount,
	@ReturnedTotalDiscount,
	@ReturnedTotalAmount,
	GETDATE(),
	@CreatedBy,
	GETDATE())
END
GO