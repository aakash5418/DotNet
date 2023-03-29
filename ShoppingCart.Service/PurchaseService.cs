
using Sample.Shopping.Store.productStore;
using ShoppingCart.Store;
using System.Collections;
//Todo: Karthick Code Review
namespace ShoppingCart.Service
{
    public interface IPurchaseService
    {
        List<PurchaseGet> GetPurchase();

        PurchaseServiceInfo GetPurchaseId(long PurchaseID);

        ArrayList AddPurchase(PurchaseServiceInfo purchaseServiceInfo);

        void UpdatePurchase(PurchaseServiceInfo purchaseServiceInfo);

        void DeletePurchase(long PurchaseID);
    }

    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseStore _purchaseStore;

        private readonly IStockStore _stockStore;

        private readonly IProductStore _productStore;

        public PurchaseService(IPurchaseStore purchaseStore, IStockStore stockStore,IProductStore productStore)
        {
            _purchaseStore = purchaseStore;
            _stockStore = stockStore;
            _productStore = productStore;
        }


        public List<PurchaseGet> GetPurchase()
        {
            var purchaseStoreInfo = _purchaseStore.GetPurchase();
            if (purchaseStoreInfo == null)
            {
                return null;
            }
            else
            {
                var purchaseLst = new List<PurchaseGet>();
                foreach (var storeInfo in purchaseStoreInfo)
                {
                    purchaseLst.Add(new PurchaseGet
                    {
                        ProductID = storeInfo.ProductID,
                        ProductName = storeInfo.ProductName,
                        PurchaseID= storeInfo.PurchaseID,
                        PurchasedDate = storeInfo.PurchasedDate,
                        Quantity = storeInfo.Quantity,
                        UnitPrice= storeInfo.UnitPrice,
                        UnitDiscount= storeInfo.UnitDiscount,
                        TotalDiscount = storeInfo.TotalDiscount,
                        TotalAmount = storeInfo.TotalAmount,
                        
                    });
                }
                return purchaseLst;
            }
        }

        public PurchaseServiceInfo GetPurchaseId(long PurchaseID)
        {
            var purchaseStoreInfo = _purchaseStore.GetPurchaseId(PurchaseID);
            if (purchaseStoreInfo == null)
            {
                return null;
            }
            else
            {
                return new PurchaseServiceInfo
                {
                    PurchaseID = purchaseStoreInfo.PurchaseID,
                    ProductID = purchaseStoreInfo.ProductID,
                    Quantity = purchaseStoreInfo.Quantity,
                    UnitPrice = purchaseStoreInfo.UnitPrice,
                    UnitDiscount = purchaseStoreInfo.UnitDiscount,
                    TotalDiscount = purchaseStoreInfo.TotalDiscount,
                    TotalAmount = purchaseStoreInfo.TotalAmount,
                    PurchasedDate = purchaseStoreInfo.PurchasedDate,
                    CreatedBy = purchaseStoreInfo.CreatedBy,
                    ModifiedBy = purchaseStoreInfo.ModifiedBy,
                    CreatedDate = purchaseStoreInfo.CreatedDate,
                    ModifiedDate = purchaseStoreInfo.ModifiedDate,
                };
            }
        }
        public ArrayList AddPurchase(PurchaseServiceInfo purchaseServiceInfo)
        {
            var validPurchase = ValidatePurchase(purchaseServiceInfo);
            if (validPurchase.Count == 0)
            {
                var purchaseList = IsPurchaseExist(purchaseServiceInfo);
                if (purchaseList.Count == 0)
                {
                    var purchaseStoreInfo = new PurchaseStoreInfo();
                    purchaseStoreInfo.PurchaseID = purchaseServiceInfo.PurchaseID;
                    purchaseStoreInfo.ProductID = purchaseServiceInfo.ProductID;
                    purchaseStoreInfo.Quantity = purchaseServiceInfo.Quantity;
                    purchaseStoreInfo.UnitPrice = purchaseServiceInfo.UnitPrice;
                    purchaseStoreInfo.UnitDiscount = purchaseServiceInfo.UnitDiscount;
                    purchaseStoreInfo.TotalDiscount = purchaseServiceInfo.TotalDiscount;
                    purchaseStoreInfo.TotalAmount = purchaseServiceInfo.TotalAmount;
                    purchaseStoreInfo.PurchasedDate = purchaseServiceInfo.PurchasedDate;
                    purchaseStoreInfo.CreatedBy = purchaseServiceInfo.CreatedBy;
                    purchaseStoreInfo.ModifiedBy = purchaseServiceInfo.ModifiedBy;
                    purchaseStoreInfo.CreatedDate = purchaseServiceInfo.CreatedDate;
                    purchaseStoreInfo.ModifiedDate = purchaseServiceInfo.ModifiedDate;

                    _purchaseStore.AddPurchase(purchaseStoreInfo);
                }
                else
                {
                    return purchaseList;
                }
            }
            else
            {
                return validPurchase;
            }
            return validPurchase;
        }

        public void UpdatePurchase(PurchaseServiceInfo purchaseServiceInfo)
        {
            var purchaseStoreInfo = new PurchaseStoreInfo();
            purchaseStoreInfo.TotalAmount = purchaseServiceInfo.TotalAmount;
            purchaseStoreInfo.PurchasedDate = purchaseServiceInfo.PurchasedDate;
            purchaseStoreInfo.PurchaseID = purchaseServiceInfo.PurchaseID;
            purchaseStoreInfo.ProductID = purchaseServiceInfo.ProductID;
            purchaseStoreInfo.Quantity = purchaseServiceInfo.Quantity;
            purchaseStoreInfo.UnitPrice = purchaseServiceInfo.UnitPrice;
            purchaseStoreInfo.UnitDiscount = purchaseServiceInfo.UnitDiscount;
            purchaseStoreInfo.TotalDiscount = purchaseServiceInfo.TotalDiscount;
            purchaseStoreInfo.CreatedBy = purchaseServiceInfo.CreatedBy;
            purchaseStoreInfo.ModifiedBy = purchaseServiceInfo.ModifiedBy;
            purchaseStoreInfo.CreatedDate = purchaseServiceInfo.CreatedDate;
            purchaseStoreInfo.ModifiedDate = purchaseServiceInfo.ModifiedDate;

            _purchaseStore.UpdatePurchase(purchaseStoreInfo);
        }

        public void DeletePurchase(long PurchaseID)
        {
            _purchaseStore.DeletePurchase(PurchaseID);
        }

        private ArrayList ValidatePurchase(PurchaseServiceInfo purchaseServiceInfo)
        {
            ArrayList purchaseList = new ArrayList();

            if (purchaseServiceInfo.ProductID <= 0)
            {
                purchaseList.Add("ProductId Does Not Exists");
            }
            if (purchaseServiceInfo.Quantity <= 0)
            {
                purchaseList.Add("Purchase Quantity Does Not Exists");
            }
            if (string.IsNullOrEmpty(purchaseServiceInfo.CreatedBy))
            {
                purchaseList.Add(" Purchase CreatedBy Does Not Exists");
            }

            return purchaseList;
        }

        

        private ArrayList IsPurchaseExist(PurchaseServiceInfo  purchaseServiceInfo)
        {
            ArrayList purchaseList = new ArrayList();
            var purchase = _productStore.GetProduct(purchaseServiceInfo.ProductID);
           // var purchaseExists = purchase.Any(p => p.ProductID == purchaseServiceInfo.ProductID);
            if (purchase == null)
            {
                purchaseList.Add("ProductID not Exists");
            }
            if(purchase.ProductId != purchaseServiceInfo.ProductID)
            {
                purchaseList.Add("ProductId MissMacted");
            }
            var stockQuantity = _stockStore.GetStockByProductId(purchaseServiceInfo.ProductID);
            if(purchaseServiceInfo.Quantity > stockQuantity.Quantity) 
            {
                purchaseList.Add("PurchaseQuantity is Greater than Stock Quantity");
            }
            return purchaseList;
        }
    }
}
