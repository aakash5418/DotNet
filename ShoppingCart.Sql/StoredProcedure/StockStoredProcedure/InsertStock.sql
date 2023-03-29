--Todo: Karthick Code Review

GO
CREATE PROCEDURE sp_InsertStock(
@ProductId BIGINT,
@Quantity DECIMAL(18,2),
@CreatedBy VARCHAR(50),
@ModifiedBy VARCHAR(50),
@CreatedDate DATETIME,
@ModifiedDate DATETIME)
AS
BEGIN
INSERT INTO Stock(
ProductID,
Quantity,
CreatedBy,
ModifiedBy,
CreatedDate,
ModifiedDate)
VALUES(
@ProductId,
@Quantity,
@CreatedBy,
@ModifiedBy,
@CreatedDate,
@ModifiedDate)
END
GO