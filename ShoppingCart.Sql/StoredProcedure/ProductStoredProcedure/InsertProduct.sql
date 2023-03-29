--Todo: Karthick Code Review

GO
CREATE PROCEDURE sp_InsertProduct(
	@ProductName VARCHAR(50),
	@UnitPrice DECIMAL(18,2),
	@UnitDiscount DECIMAL(18,2),
	@CreatedBy VARCHAR(50),
	@ModifiedBy VARCHAR(50),
	@CreatedDate DATETIME,
	@ModifiedDate DATETIME)
AS
BEGIN
INSERT INTO Product(
	ProductName,
	UnitPrice,
	UnitDiscount,
	CreatedBy,
	ModifiedBy,
	CreatedDate,
	ModifiedDate)
VALUES(
	@ProductName,
	@UnitPrice,
	@UnitDiscount,
	@CreatedBy,
	@ModifiedBy,
	@CreatedDate,
	@ModifiedDate)
END
GO