//Todo: Karthick Code Review
using ShoppingCart.Store;
using System.Collections;

namespace ShoppingCart.Service
{

    public interface IReturnService
    {
        List<ReturnView> GetReturns();
        ArrayList AddReturn(ReturnServiceInfo returnServiceInfo);

        ReturnServiceInfo GetReturn(long ReturnID);

        void UpdateReturn(ReturnServiceInfo returnServiceInfo);

        void DeleteReturn(long ReturnID);
    }

    public class ReturnService : IReturnService
    {
        private readonly IReturnStore _returnStore;

        private readonly IPurchaseStore _purchaseStore;


        public ReturnService(IReturnStore returnStore, IPurchaseStore purchaseStore)
        {
            _returnStore = returnStore;
            _purchaseStore = purchaseStore;
        }


        public List<ReturnView> GetReturns()
        {
            var returnStoreInfo = _returnStore.GetReturns();

            if (returnStoreInfo == null)
            {
                return null;
            }
            else
            {
                var returnLst = new List<ReturnView>();
                foreach (var storeInfo in returnStoreInfo)
                {
                    returnLst.Add(new ReturnView
                    {
                        PurchaseID = storeInfo.PurchaseID,
                        ProductID = storeInfo.ProductID,
                        ProductName = storeInfo.ProductName,
                        ReturnedQuantity = storeInfo.ReturnedQuantity,
                        ReturnedTotalDiscount = storeInfo.ReturnedTotalDiscount,
                        ReturnedTotalAmount = storeInfo.ReturnedTotalAmount,
                        ReturnedDate = storeInfo.ReturnedDate,
                        UnitPrice = storeInfo.UnitPrice,
                        UnitDiscount = storeInfo.UnitDiscount,
                    });
                }
                return returnLst;
            }
        }
        public ReturnServiceInfo GetReturn(long ReturnID)
        {
            var returnStoreInfo = _returnStore.GetReturn(ReturnID);
            if (returnStoreInfo == null)
            {
                return null;
            }
            else
            {
                return new ReturnServiceInfo
                {
                    ReturnID = returnStoreInfo.ReturnID,
                    PurchaseID = returnStoreInfo.PurchaseID,
                    ProductID = returnStoreInfo.ProductID,
                    ReturnedQuantity = returnStoreInfo.ReturnedQuantity,
                    ReturnedTotalDiscount = returnStoreInfo.ReturnedTotalDiscount,
                    ReturnedTotalAmount = returnStoreInfo.ReturnedTotalAmount,
                    ReturnedDate = returnStoreInfo.ReturnedDate,
                    CreatedBy = returnStoreInfo.CreatedBy,
                    ModifiedBy = returnStoreInfo.ModifiedBy,
                    CreatedDate = returnStoreInfo.CreatedDate,
                    ModifiedDate = returnStoreInfo.ModifiedDate,

                };
            }
        }
        public ArrayList AddReturn(ReturnServiceInfo returnServiceInfo)
        {
            var returnValid = ValidatePurchaseReturn(returnServiceInfo);
            if (returnValid.Count == 0)
            {
                var returnExist = IsPurchaseReturnExist(returnServiceInfo);
                if (returnExist.Count == 0)
                {
                    var returnStoreInfo = new ReturnStoreInfo();
                    returnStoreInfo.ReturnID = returnServiceInfo.ReturnID;
                    returnStoreInfo.PurchaseID = returnServiceInfo.PurchaseID;
                    returnStoreInfo.ProductID = returnServiceInfo.ProductID;
                    returnStoreInfo.ReturnedQuantity = returnServiceInfo.ReturnedQuantity;
                    returnStoreInfo.ReturnedTotalDiscount = returnServiceInfo.ReturnedTotalDiscount;
                    returnStoreInfo.ReturnedTotalAmount = returnServiceInfo.ReturnedTotalAmount;
                    returnStoreInfo.ReturnedDate = returnServiceInfo.ReturnedDate;
                    returnStoreInfo.CreatedBy = returnServiceInfo.CreatedBy;
                    returnStoreInfo.ModifiedBy = returnServiceInfo.ModifiedBy;
                    returnStoreInfo.CreatedDate = returnServiceInfo.CreatedDate;
                    returnStoreInfo.ModifiedDate = returnServiceInfo.ModifiedDate;

                    _returnStore.AddReturn(returnStoreInfo);
                }
                else
                {
                    return returnExist;
                }
            }
            else
            {
                return returnValid;
            }
            return returnValid;
        }

        public void UpdateReturn(ReturnServiceInfo returnServiceInfo)
        {
            var returnStoreInfo = new ReturnStoreInfo();
            returnStoreInfo.ReturnID = returnServiceInfo.ReturnID;
            returnStoreInfo.PurchaseID = returnServiceInfo.PurchaseID;
            returnStoreInfo.ProductID = returnServiceInfo.ProductID;
            returnStoreInfo.ReturnedQuantity = returnServiceInfo.ReturnedQuantity;
            returnStoreInfo.ReturnedTotalDiscount = returnServiceInfo.ReturnedTotalDiscount;
            returnStoreInfo.ReturnedTotalAmount = returnServiceInfo.ReturnedTotalAmount;
            returnStoreInfo.ReturnedDate = returnServiceInfo.ReturnedDate;
            returnStoreInfo.CreatedBy = returnServiceInfo.CreatedBy;
            returnStoreInfo.ModifiedBy = returnServiceInfo.ModifiedBy;
            returnStoreInfo.CreatedDate = returnServiceInfo.CreatedDate;
            returnStoreInfo.ModifiedDate = returnServiceInfo.ModifiedDate;
            _returnStore.UpdateReturn(returnStoreInfo);
        }

        public void DeleteReturn(long ReturnID)
        {
            _returnStore.DeleteReturn(ReturnID);
        }
        public ArrayList ValidateDeleteReturn(ReturnServiceInfo returnServiceInfo)
        {
            ArrayList returnList = new ArrayList();
            var validReturn = _purchaseStore.GetPurchaseId(returnServiceInfo.PurchaseID);

            if (validReturn == null)
            {
                returnList.Add("ReturnID Is Not Exists");
                return returnList;
            }
            if (validReturn.PurchaseID != returnServiceInfo.PurchaseID)
            {
                returnList.Add("PurchaseID Is Not Exists");
            }
            return returnList;
        }

        private ArrayList ValidatePurchaseReturn(ReturnServiceInfo returnServiceInfo)
        {
            ArrayList returnList = new ArrayList();

            if (returnServiceInfo.PurchaseID <= 0)
            {
                returnList.Add("PurchaseID does not Exists");
            }
            if (returnServiceInfo.ProductID <= 0)
            {
                returnList.Add("ProductID Does Not Exists");
            }
            if (returnServiceInfo.ReturnedQuantity <= 0)
            {
                returnList.Add("ReturnedQuantity Does Not Exists");
            }
            return returnList;
        }

        private ArrayList IsPurchaseReturnExist(ReturnServiceInfo returnServiceInfo)
        {
            ArrayList returnList = new ArrayList();
            var PurchaseDetails = _purchaseStore.GetPurchaseId(returnServiceInfo.PurchaseID);
            if (PurchaseDetails == null)
            {
                returnList.Add("PurchaseID Is Not Exists");
                return returnList;
            }

            if (PurchaseDetails.ProductID != returnServiceInfo.ProductID)
            {
                returnList.Add("ProductId Not Exists");
            }
            if (returnServiceInfo.ReturnedQuantity > PurchaseDetails.Quantity)
            {
                returnList.Add("ReturnedQuantity MissMatched");
            }
            return returnList;
        }
    }
}
