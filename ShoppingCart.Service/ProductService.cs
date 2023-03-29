
using Sample.Shopping.Store.productStore;
using ShoppingCart.Store;
using System.Collections;

namespace productService
{        //Todo: Karthick Code Review

    public interface IProductService
    {
        List<ProductServiceInfo> GetProducts();
        ArrayList AddProduct(ProductServiceInfo productServiceInfo);

        ProductServiceInfo GetProduct(long ProductId);

        ArrayList UpdateProduct(ProductServiceInfo productServiceInfo);

        void DeleteProduct(long ProductId);

    }

    public class ProductService : IProductService
    {
        private readonly IProductStore _ProductStore;

        public ProductService(IProductStore ProductStore)
        {
            _ProductStore = ProductStore;
        }
        public List<ProductServiceInfo> GetProducts()
        {
            var productStoreInfoList = _ProductStore.GetProducts();
            if (productStoreInfoList == null)
            {
                return null;
            }
            else
            {
                var productServiceInfoList = new List<ProductServiceInfo>();
                foreach (var productStoreInfo in productStoreInfoList)
                {
                    productServiceInfoList.Add(new ProductServiceInfo
                    {
                        ProductId = productStoreInfo.ProductId,
                        ProductName = productStoreInfo.ProductName,
                        UnitPrice = productStoreInfo.UnitPrice,
                        UnitDiscount = productStoreInfo.UnitDiscount,
                        CreatedBy = productStoreInfo.CreatedBy,
                        ModifiedBy = productStoreInfo.ModifiedBy,
                        CreatedDate = productStoreInfo.CreatedDate,
                        ModifiedDate = productStoreInfo.ModifiedDate
                    });
                }
                return productServiceInfoList;
            }
        }
        public ProductServiceInfo GetProduct(long ProductId)
        {
            var productStoreinfo = _ProductStore.GetProduct(ProductId);
            if (productStoreinfo == null)
            {
                return null;
            }
            else
            {
                return new ProductServiceInfo
                {
                    ProductId = productStoreinfo.ProductId,
                    ProductName = productStoreinfo.ProductName,
                    UnitPrice = productStoreinfo.UnitPrice,
                    UnitDiscount = productStoreinfo.UnitDiscount,
                    CreatedBy = productStoreinfo.CreatedBy,
                    ModifiedBy = productStoreinfo.ModifiedBy,
                    CreatedDate = productStoreinfo.CreatedDate,
                    ModifiedDate = productStoreinfo.ModifiedDate
                };
            }
        }
        public ArrayList AddProduct(ProductServiceInfo productServiceInfo)
        {
            var Productvalid = ValidateProduct(productServiceInfo);
            if (Productvalid.Count == 0)
            {
                var Productexist = IsProductExist(productServiceInfo.ProductName);
                if (Productexist.Count == 0)
                {
                    var productstoreinfo = new ProductStoreInfo();
                    productstoreinfo.ProductId = productServiceInfo.ProductId;
                    productstoreinfo.ProductName = productServiceInfo.ProductName;
                    productstoreinfo.UnitPrice = productServiceInfo.UnitPrice;
                    productstoreinfo.UnitDiscount = productServiceInfo.UnitDiscount;
                    productstoreinfo.CreatedBy = productServiceInfo.CreatedBy;
                    productstoreinfo.ModifiedBy = productServiceInfo.ModifiedBy;
                    productstoreinfo.CreatedDate = productServiceInfo.CreatedDate;
                    productstoreinfo.ModifiedDate = productServiceInfo.ModifiedDate;
                    _ProductStore.AddProduct(productstoreinfo);
                }
                else
                {
                    return Productexist;
                }
            }
            else
            {
                return Productvalid;
            }
            return Productvalid;
        }

        public ArrayList UpdateProduct(ProductServiceInfo productServiceInfo)

        {

            var Productvalid = ValidateProduct(productServiceInfo);
            if (Productvalid.Count == 0)
            {

                var productstoreinfo = new ProductStoreInfo();
                productstoreinfo.ProductId = productServiceInfo.ProductId;
                productstoreinfo.ProductName = productServiceInfo.ProductName;
                productstoreinfo.UnitPrice = productServiceInfo.UnitPrice;
                productstoreinfo.UnitDiscount = productServiceInfo.UnitDiscount;
                productstoreinfo.CreatedBy = productServiceInfo.CreatedBy;
                productstoreinfo.ModifiedBy = productServiceInfo.ModifiedBy;
                productstoreinfo.CreatedDate = DateTime.UtcNow;
                productstoreinfo.ModifiedDate = productServiceInfo.ModifiedDate;
                _ProductStore.UpdateProduct(productstoreinfo);
            }
            else
            {
                return Productvalid;
            }
            return Productvalid;
        }

        public void DeleteProduct(long ProductId)
        {
            _ProductStore.DeleteProduct(ProductId);
        }

        private ArrayList ValidateProduct(ProductServiceInfo productServiceInfo)
        {
            ArrayList ValidateProductlist = new ArrayList();
            if (string.IsNullOrEmpty(productServiceInfo.ProductName))
            {
                ValidateProductlist.Add("ProductName is Empty");
            }

            if (productServiceInfo.UnitPrice <= 0)
            {
                ValidateProductlist.Add("Enter Valid UnitPrice");
            }
            if (productServiceInfo.UnitDiscount <= 0)
            {
                ValidateProductlist.Add("Enter Valid UnitDiscount");
            }
            if (string.IsNullOrEmpty(productServiceInfo.CreatedBy))
            {
                ValidateProductlist.Add("CreatedBy is Empty");
            }
            if (string.IsNullOrEmpty(productServiceInfo.ModifiedBy))
            {
                ValidateProductlist.Add("ModifiedBy is Empty");
            }
            return ValidateProductlist;
        }

        private ArrayList IsProductExist(string productName)
        {
            var ProductExistList = new ArrayList();

            var products = _ProductStore.GetProducts();
            var ValidProduct = products.Any(p => productName.Contains(p.ProductName));
            if (ValidProduct)
            {
                ProductExistList.Add("ProductName Already Exists");
            }
            return ProductExistList;
        }
    }
}
