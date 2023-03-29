//Todo: Karthick Code Review

using Microsoft.Extensions.Configuration;
using ShoppingCart.Store;
using System.Data;
using System.Data.SqlClient;

namespace Sample.Shopping.Store.productStore
{
    public interface IProductStore
    {

        List<ProductStoreInfo> GetProducts();
        ProductStoreInfo GetProduct(long ProductId);

        ProductStoreInfo AddProduct(ProductStoreInfo productStoreInfo);

        ProductStoreInfo UpdateProduct(ProductStoreInfo productStoreInfo);

        void DeleteProduct(long ProductId);

    }
    public class ProductStore : IProductStore
    {
        private readonly IConfiguration _configuration;

        public ProductStore(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<ProductStoreInfo> GetProducts()
        {
            string Connection = _configuration.GetConnectionString("ShoppingDb");
            List<ProductStoreInfo> products = new List<ProductStoreInfo>();
            SqlConnection sqlConnection = new SqlConnection(Connection);
            string Query = "select * from Product";
            SqlCommand sqlCommand = new SqlCommand(Query);
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            {
                while (sqlDataReader.Read())
                {
                    products.Add(new ProductStoreInfo
                    {
                        ProductId = Convert.ToInt64(sqlDataReader["ProductId"]),
                        ProductName = sqlDataReader["ProductName"].ToString(),
                        UnitPrice = Convert.ToDecimal(sqlDataReader["UnitPrice"]),
                        UnitDiscount = Convert.ToDecimal(sqlDataReader["UnitDiscount"]),
                        CreatedBy = sqlDataReader["CreatedBy"].ToString(),
                        ModifiedBy = sqlDataReader["ModifiedBy"].ToString(),
                        CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]),
                        ModifiedDate = Convert.ToDateTime(sqlDataReader["ModifiedDate"])
                    });
                }
                sqlConnection.Close();
            }
            return products;
        }
        public ProductStoreInfo GetProduct(long ProductId)
        {
            string Connection = _configuration.GetConnectionString("ShoppingDb");
            ProductStoreInfo products = new ProductStoreInfo();
            SqlConnection sqlConnection = new SqlConnection(Connection);
            string Query = "sp_GetAllProducts";
            SqlCommand sqlCommand = new SqlCommand(Query);
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ProductId", ProductId);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            {
                while (sqlDataReader.Read())
                {
                    products = new ProductStoreInfo()
                    {
                        ProductId = Convert.ToInt64(sqlDataReader["ProductId"]),
                        ProductName = sqlDataReader["ProductName"].ToString(),
                        UnitPrice = Convert.ToDecimal(sqlDataReader["UnitPrice"]),
                        UnitDiscount = Convert.ToDecimal(sqlDataReader["UnitDiscount"]),
                        CreatedBy = sqlDataReader["CreatedBy"].ToString(),
                        ModifiedBy = sqlDataReader["ModifiedBy"].ToString(),
                        CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]),
                        ModifiedDate = Convert.ToDateTime(sqlDataReader["ModifiedDate"])
                    };
                }
                sqlConnection.Close();
            }
            return products;
        }
        public ProductStoreInfo AddProduct(ProductStoreInfo productStoreInfo)
        {
            string Connection = _configuration.GetConnectionString("ShoppingDb");
            SqlConnection sqlConnection = new SqlConnection(Connection);
            string query = "sp_InsertProduct";
            SqlCommand sqlCommand = new SqlCommand(query);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ProductName", productStoreInfo.ProductName);
            sqlCommand.Parameters.AddWithValue("@UnitPrice", productStoreInfo.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@UnitDiscount", productStoreInfo.UnitDiscount);
            sqlCommand.Parameters.AddWithValue("@CreatedBy", productStoreInfo.CreatedBy);
            sqlCommand.Parameters.AddWithValue("ModifiedBy", productStoreInfo.ModifiedBy);
            sqlCommand.Parameters.AddWithValue("CreatedDate", productStoreInfo.CreatedDate);
            sqlCommand.Parameters.AddWithValue("ModifiedDate", productStoreInfo.ModifiedDate);
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            sqlDataReader.Read();
            sqlConnection.Close();
            return productStoreInfo;
        }

        public ProductStoreInfo UpdateProduct(ProductStoreInfo productStoreInfo)
        {
            string Connection = _configuration.GetConnectionString("ShoppingDb");
            SqlConnection sqlConnection = new SqlConnection(Connection);
            string Query = "sp_UpdateProduct";
            SqlCommand sqlCommand = new SqlCommand(Query);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ProductId", productStoreInfo.ProductId);
            sqlCommand.Parameters.AddWithValue("@ProductName", productStoreInfo.ProductName);
            sqlCommand.Parameters.AddWithValue("@UnitPrice", productStoreInfo.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@UnitDiscount", productStoreInfo.UnitDiscount);
            sqlCommand.Parameters.AddWithValue("ModifiedBy", productStoreInfo.ModifiedBy);
            sqlCommand.Parameters.AddWithValue("ModifiedDate", productStoreInfo.ModifiedDate);
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            sqlDataReader.Read();
            sqlConnection.Close();
            return productStoreInfo;
        }


        public void DeleteProduct(long ProductId)
        {
            string Connection = _configuration.GetConnectionString("ShoppingDb");
            SqlConnection sqlConnection = new SqlConnection(Connection);
            string Query = "sp_DeleteProduct";
            SqlCommand sqlCommand = new SqlCommand(Query);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue(@"ProductId", ProductId);
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            dataReader.Read();
            sqlConnection.Close();
        }
    }

}
