--Todo: Karthick Code Review

CREATE TABLE _Return(
                    ReturnID BIGINT IDENTITY(100001,1) ,
                    PurchaseID BIGINT  ,
                    ProductID  BIGINT  ,
                    ReturnedQuantity INT,
                    ReturnedTotalDiscount  DECIMAL(18,2),    
                    ReturnedTotalAmount  DECIMAL(18,2),
                    ReturnedDate DATETIME,
                    CreatedBy VARCHAR(50),
                    ModifiedBy VARCHAR(50),
                    CreatedDate DATETIME,
                    ModifiedDate DATETIME
                  ,constraint PK__Return_ReturnID PRIMARY KEY(ReturnID)
                  ,constraint FK__Return_Product foreign key (ProductID) REFERENCES Product(ProductID)
                  ,constraint FK__Return_Purchase foreign key (ProductID) REFERENCES Product(ProductID))
