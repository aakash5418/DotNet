--Todo: Karthick Code Review

GO
CREATE PROCEDURE sp_Upsert 
	@StocktId BIGINT,
	@ProductId BIGINT,
	@Quantity INT,
	@CreatedBy VARCHAR(50),
	@ModifiedBy VARCHAR(50)
AS  
BEGIN  
IF  EXISTS (SELECT * FROM Stock  WHERE StocktID = @StocktId)  
UPDATE
	dbo.Stock  
SET
	ProductID = @ProductId,
	Quantity = Quantity +  @Quantity,
	ModifiedBy = @ModifiedBy,
	ModifiedDate = GETDATE()
WHERE 
	StocktID = @StocktId  
ELSE  
INSERT INTO Stock(
	ProductID,
	Quantity,
	CreatedBy,
	CreatedDate) 
VALUES
	(@ProductId,
	@quantity,
	@CreatedBy,
	GETDATE())
END
GO