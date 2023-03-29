--Todo: Karthick Code Review

GO 
CREATE PROCEDURE sp_PURCHASESTORE 
AS

SELECT  PurchaseID ,
        Purchase.ProductID ,
        ProductName,
        quantity,
        UnitPrice= Product.UnitPrice,
        UnitDiscount=Product.UnitDiscount/100,
        TotalDiscount  = quantity*(Product.UnitPrice*Product.UnitDiscount),
        TotalAmount=(Quantity*Product.UnitPrice)-TotalDiscount,
		Purchase.PurchasedDate,
        Purchase.CreatedBy,
        Purchase.ModifiedBy,
        Purchase.CreatedDate,
        Purchase.ModifiedDate
FROM Purchase 
JOIN Product
ON Product.ProductID =Purchase.ProductID
