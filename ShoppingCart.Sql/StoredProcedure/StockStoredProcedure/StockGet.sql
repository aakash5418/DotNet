--Todo: Karthick Code Review

GO
CREATE PROCEDURE SP_StockSummary
AS
SELECT StocktID ,
       stock.ProductID ,
       ProductName,
       UnitPrice,
       Quantity,
       UnitPrice * Quantity AS Totalamount
       FROM Stock 
       JOIN Product 
       ON Product.ProductID=Stock.ProductID
