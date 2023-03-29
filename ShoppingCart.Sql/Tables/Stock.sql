--Todo: Karthick Code Review

CREATE TABLE Stock(
                  StocktID BIGINT IDENTITY(1001,1),
                  ProductID BIGINT,
                  Quantity INT,
                  CreatedBy VARCHAR(50),
                  ModifiedBy VARCHAR(50),
                  CreatedDate DATETIME,
                  ModifiedDate DATETIME
                  ,constraint PK_Stock_StocktID PRIMARY KEY(StocktID)
                  ,constraint FK_Stock_Product foreign key (ProductID) REFERENCES Product(ProductID))
