--Todo: Karthick Code Review

GO
CREATE PROCEDURE sp_InsertPurchase(
	@ProductId BIGINT,
	@Quantity DECIMAL(18,2),
	@UnitPrice DECIMAL(18,2),
	@UnitDiscount DECIMAL(18,2),
	@TotalDiscount DECIMAL(18,2),
	@TotalAmount DECIMAL(18,2),
	@PurchasedDate DATETIME,
	@CreatedBy VARCHAR(50),
	@ModifiedBy VARCHAR(50),
	@CreatedDate DATETIME,
	@ModifiedDate DATETIME)
AS
BEGIN
INSERT INTO Purchase(
	ProductID,
	Quantity,
	UnitPrice,
	UnitDiscount,
	TotalDiscount,
	TotalAmount,
	PurchasedDate,
	CreatedBy,
	ModifiedBy,
	CreatedDate,
	ModifiedDate)
VALUES(
	@ProductId,
	@Quantity,
	@UnitPrice,
	@UnitDiscount,
	@TotalDiscount,
	@TotalAmount,
	@PurchasedDate,
	@CreatedBy,
	@ModifiedBy,
	@CreatedDate,
	@ModifiedDate)
END
GO