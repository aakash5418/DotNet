--Todo: Karthick Code Review

GO 
CREATE PROCEDURE RETURNSTORE 
AS
SELECT ReturnID,
       _Return.ProductID,
       ProductName,
       _Return.PurchaseID,
       ReturnedDate,
       ReturnedQuantity,
       UnitPrice =Product.UnitPrice,
       UnitDiscount = (Product.UnitDiscount/ 100),
       ReturnedTotalDiscount = Quantity * (Product.UnitPrice  * Product.UnitDiscount),
       ReturnedTotalAmount = ((Quantity * Product.UnitPrice) - TotalDiscount)
       FROM _Return 
       JOIN Product 
       ON Product.ProductID=_Return.ProductID 
       JOIN Purchase 
       ON Purchase.ProductID=Product.ProductID
	   GO