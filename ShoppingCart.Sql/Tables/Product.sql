--Todo: Karthick Code Review

CREATE TABLE Product(
                    ProductID BIGINT IDENTITY(101,1),
                    ProductName VARCHAR(50),
                    UnitPrice DECIMAL (18,2),
                    UnitDiscount DECIMAL(18,2),
                    CreatedBy VARCHAR(50),
                    ModifiedBy VARCHAR(50),
                    CreatedDate DATETIME,
                    ModifiedDate DATETIME
                    ,constraint PK_Product_ProductID PRIMARY KEY(ProductID))
