//Todo: Karthick Code Review

namespace ShoppingCart.Store
{
    public class ReturnStoreInfo
    {
        public long ReturnID { get; set; }

        public long PurchaseID { get; set; }

        public long ProductID { get; set; }

        public Int16 ReturnedQuantity { get; set; }

        public decimal ReturnedTotalDiscount { get; set; }

        public decimal ReturnedTotalAmount { get; set; }

        public DateTime ReturnedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
    public class ReturnView
    {
        public long ProductID { get; set; }

        public string ProductName { get; set; }

        public long PurchaseID { get; set; }

        public DateTime ReturnedDate { get; set; }

        public Int16 ReturnedQuantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal UnitDiscount { get; set; }

        public decimal ReturnedTotalDiscount { get; set; }

        public decimal ReturnedTotalAmount { get; set; }

    }
    public class ReturnList
    {
        public long ProductID { get; set; }

        public string ProductName { get; set; }

        public Int32 Quantity { get; set; }

        public DateTime PurchasedDate { get; set; }

        public decimal TotalDiscount { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime ReturnedDate { get; set; }

        public decimal ReturnedQuantity { get; set; }

        public decimal ReturnedTotalDiscount { get; set; }

        public decimal ReturnedTotalAmount { get; set; }

    }
}
