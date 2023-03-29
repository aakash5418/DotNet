--Todo: Karthick Code Review

create TABLE Purchase(
                    PurchaseID  BIGINT IDENTITY(10001,1),
                    ProductID BIGINT ,
                    Quantity INT,
                    UnitPrice DECIMAL (18,2),
                    UnitDiscount DECIMAL(18,2),
                    TotalDiscount DECIMAL (18,2),
                    TotalAmount DECIMAL (18,2),
                    PurchasedDate DATETIME,
                    CreatedBy VARCHAR(50),
                    ModifiedBy VARCHAR(50), 
                    CreatedDate DATETIME,
                    ModifiedDate DATETIME
                  ,constraint PK_Purchase_PurchaseID PRIMARY KEY(PurchaseID)
                  ,constraint FK_Purchase_Product foreign key (ProductID) REFERENCES Product(ProductID))

