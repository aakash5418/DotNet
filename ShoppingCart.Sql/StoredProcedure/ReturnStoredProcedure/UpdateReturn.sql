--Todo: Karthick Code Review

GO
CREATE PROCEDURE sp_UpsertPurchase 
	@ReturnID BIGINT,
	@PurchaseID BIGINT,
	@ProductId BIGINT,
	@ReturnedQuantity INT,
	@ReturnedTotalDiscount DECIMAL(18,2),
	@ReturnedTotalAmount DECIMAL(18,2),
	@ReturnedDate DATETIME,
	@CreatedBy VARCHAR(50),
	@ModifiedBy VARCHAR(50),
	@CreatedDate DATETIME,
	@ModifiedDate DATETIME
AS  
BEGIN  
IF  EXISTS (SELECT * FROM _Return  WHERE ReturnID = @ReturnID)  
UPDATE _Return 
SET 
	PurchaseID = @PurchaseID,
	ProductID =@ProductId,
	ReturnedQuantity = @ReturnedQuantity,
	ReturnedTotalDiscount = @ReturnedTotalDiscount,
	ReturnedTotalAmount = @ReturnedTotalAmount,
	ReturnedDate = GETDATE(),
	CreatedBy = @CreatedBy,
	ModifiedBy = @ModifiedBy,
	CreatedDate = GETDATE(),
	ModifiedDate = GETDATE()
WHERE
	PurchaseID = @PurchaseID 
ELSE  
INSERT INTO _Return(
	ReturnID,
	PurchaseID,
	ProductID,
	ReturnedQuantity,
	ReturnedTotalDiscount,
	ReturnedTotalAmount,
	ReturnedDate,
	CreatedBy,
	ModifiedBy,
	CreatedDate,
	ModifiedDate) 
VALUES(
	@ReturnID,
	@PurchaseID,
	@ProductId,
	@ReturnedQuantity,
	@ReturnedTotalDiscount,
	@ReturnedTotalAmount,
	GETDATE(),
	@CreatedBy,
	@ModifiedBy,
	GETDATE(),
	GETDATE())
END
GO