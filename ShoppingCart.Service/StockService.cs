//Todo: Karthick Code Review

using ShoppingCart.Store;
using System.Collections;

namespace ShoppingCart.Service
{
    public interface IStockService
    {
        List<StockPriceSummary> GetStocks();

        ArrayList AddStock(StockServiceInfo stockServiceInfo);

        StockServiceInfo GetStockByProductId(long ProductID);

        ArrayList UpdateStock(StockServiceInfo stockServiceInfo);

        void DeleteStock(long StockId);
    }

    public class StockService : IStockService
    {
        private readonly IStockStore _stockStore;

        public StockService(IStockStore stockStore)
        {
            _stockStore = stockStore;
        }

        public List<StockPriceSummary> GetStocks()
        {
            var stockStoreInfolst = _stockStore.GetStocks();

            if (stockStoreInfolst == null)
            {
                return null;
            }
            else
            {
                var stockServiceinfolst = new List<StockPriceSummary>();
                foreach (var storeInfo in stockStoreInfolst)
                {
                    stockServiceinfolst.Add(new StockPriceSummary
                    {
                        StocktId = storeInfo.StocktId,
                        ProductId = storeInfo.ProductId,
                        ProductName = storeInfo.ProductName,
                        UnitPrice = storeInfo.UnitPrice,
                        Quantity = storeInfo.Quantity,
                        TotalAmount = storeInfo.TotalAmount,
                    });
                }
                return stockServiceinfolst;
            }
        }

        public StockServiceInfo GetStockByProductId(long ProductID)
        {
            var stockStoreInfo = _stockStore.GetStockByProductId(ProductID);
            if (stockStoreInfo == null)
            {
                return null;
            }
            else
            {
                return new StockServiceInfo
                {
                    StocktId = stockStoreInfo.StocktId,
                    ProductId = stockStoreInfo.ProductId,
                    Quantity = stockStoreInfo.Quantity,
                    CreatedBy = stockStoreInfo.CreatedBy,
                    ModifiedBy = stockStoreInfo.ModifiedBy,
                    CreatedDate = stockStoreInfo.CreatedDate,
                    ModifiedDate = stockStoreInfo.ModifiedDate,
                };
            }
        }
        public ArrayList AddStock(StockServiceInfo stockServiceInfo)
        {
            var valid = ValidatePurchas(stockServiceInfo);
            if (valid.Count == 0)
            {
                var exist = IsStockExist(stockServiceInfo.ProductId);
                if (exist.Count == 0)
                {
                    var stockstoreinfo = new StockStoreInfo();
                    stockstoreinfo.ProductId = stockServiceInfo.ProductId;
                    stockstoreinfo.Quantity = stockServiceInfo.Quantity;
                    stockstoreinfo.CreatedBy = stockServiceInfo.CreatedBy;
                    stockstoreinfo.ModifiedBy = stockServiceInfo.ModifiedBy;
                    stockstoreinfo.CreatedDate = stockServiceInfo.CreatedDate;
                    stockstoreinfo.ModifiedDate = stockServiceInfo.ModifiedDate;
                    _stockStore.AddStock(stockstoreinfo);
                }
                else
                {
                    return exist;
                }
            }
            else
            {
                return valid;
            }

            return valid;
        }

        public ArrayList UpdateStock(StockServiceInfo stockServiceInfo)
        {
            var exist = ValidatePurchas(stockServiceInfo);
            if (exist.Count == 0)
            {
                var stockstoreinfo = new StockStoreInfo();
                stockstoreinfo.StocktId = stockServiceInfo.StocktId;
                stockstoreinfo.ProductId = stockServiceInfo.ProductId;
                stockstoreinfo.Quantity = stockServiceInfo.Quantity;
                stockstoreinfo.CreatedBy = stockServiceInfo.CreatedBy;
                stockstoreinfo.ModifiedBy = stockServiceInfo.ModifiedBy;
                _stockStore.UpdateStock(stockstoreinfo);
            }
            else
            {
                return exist;
            }
            return exist;
        }

        public void DeleteStock(long StockId)
        {
            _stockStore.DeleteStock(StockId);
        }

        private ArrayList ValidatePurchas(StockServiceInfo stockServiceInfo)
        {
            ArrayList list = new ArrayList();

            if (stockServiceInfo.ProductId <= 0)
            {
                list.Add("ProductId Does Not Exists");
            }
            if (stockServiceInfo.Quantity <= 0)
            {
                list.Add("Stock Quantity Does Not Exists");
            }
            return list;
        }
        private ArrayList IsStockExist(long productId)
        {
            ArrayList list = new ArrayList();
            var stocks = _stockStore.GetStocks();
            var result = stocks.Any(s => s.ProductId == productId);
            if (result)
            {
                list.Add("ProductId Already Exists");
            }
            return list;
        }
    }
}

