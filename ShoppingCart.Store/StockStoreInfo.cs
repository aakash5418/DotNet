//Todo: Karthick Code Review

namespace ShoppingCart.Store
{
    public class StockStoreInfo
    {
        public long StocktId { get; set; }

        public long ProductId { get; set; }

        public Int16 Quantity { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

    }
    public class StockPriceSummary
    {
        public long StocktId { get; set; }

        public long ProductId { get; set; }

        public Int16 Quantity { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
