--Todo: Karthick Code Review

GO
CREATE PROCEDURE sp_DeletePurchaseAndUpdateStock (@PurchaseID INT)
AS
BEGIN
    DECLARE @ProductID INT, @Quantity INT

    SELECT @ProductID = ProductID, @Quantity = Quantity
    FROM Purchase
    WHERE PurchaseID = @PurchaseID

    DELETE FROM Purchase
    WHERE PurchaseID = @PurchaseID

    UPDATE Stock
    SET Quantity = Quantity + @Quantity
    WHERE ProductID = @ProductID
END
GO