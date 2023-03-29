//Todo: Karthick Code Review

using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ShoppingCart.Store
{
    public interface IStockStore
    {
        List<StockPriceSummary> GetStocks();
        StockStoreInfo GetStockByProductId(long ProductId);

        StockStoreInfo AddStock(StockStoreInfo stockStoreInfo);

        StockStoreInfo UpdateStock(StockStoreInfo stockStoreInfo);

        void DeleteStock(long ProductId);

    }
    public class StockStore : IStockStore
    {
        private readonly IConfiguration _configuration;

        public StockStore(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<StockPriceSummary> GetStocks()
        {
            string Connection = _configuration.GetConnectionString("ShoppingDb");
            List<StockPriceSummary> stocks = new List<StockPriceSummary>();
            SqlConnection sqlConnection = new SqlConnection(Connection);
            string Query = "SP_StockSummary";
            SqlCommand sqlCommand = new SqlCommand(Query);
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            {
                while (sqlDataReader.Read())
                {
                    stocks.Add(new StockPriceSummary
                    {
                        StocktId = Convert.ToInt64(sqlDataReader["StocktId"]),
                        ProductId = Convert.ToInt64(sqlDataReader["ProductId"]),
                        ProductName = sqlDataReader["ProductName"].ToString(),
                        UnitPrice = Convert.ToDecimal(sqlDataReader["UnitPrice"]),
                        Quantity = Convert.ToInt16(sqlDataReader["Quantity"]),
                        TotalAmount = Convert.ToDecimal(sqlDataReader["TotalAmount"]),
                    });
                }
                sqlConnection.Close();
            }
            return stocks;
        }
        public StockStoreInfo GetStockByProductId(long ProductID)
        {
            string Connection = _configuration.GetConnectionString("ShoppingDb");
            StockStoreInfo stocks = new StockStoreInfo();
            SqlConnection sqlConnection = new SqlConnection(Connection);
            string Query = "sp_getstockbyproductid";
            SqlCommand sqlCommand = new SqlCommand(Query);
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ProductID", ProductID);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            {
                while (sqlDataReader.Read())
                {
                    stocks = new StockStoreInfo()
                    {
                        StocktId = Convert.ToInt64(sqlDataReader["StocktId"]),
                        ProductId = Convert.ToInt64(sqlDataReader["ProductId"]),
                        Quantity = Convert.ToInt16(sqlDataReader["Quantity"]),
                        CreatedBy = sqlDataReader["CreatedBy"].ToString(),
                        ModifiedBy = sqlDataReader["ModifiedBy"].ToString(),
                        CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]),
                        ModifiedDate = Convert.ToDateTime(sqlDataReader["ModifiedDate"])
                    };
                }
                sqlConnection.Close();
            }
            return stocks;
        }
        public StockStoreInfo AddStock(StockStoreInfo stockStoreInfo)
        {
            string Connection = _configuration.GetConnectionString("ShoppingDb");
            SqlConnection sqlConnection = new SqlConnection(Connection);
            string query = "sp_InsertStock";
            SqlCommand sqlCommand = new SqlCommand(query);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ProductId", stockStoreInfo.ProductId);
            sqlCommand.Parameters.AddWithValue("@Quantity", stockStoreInfo.Quantity);
            sqlCommand.Parameters.AddWithValue("@CreatedBy", stockStoreInfo.CreatedBy);
            sqlCommand.Parameters.AddWithValue("ModifiedBy", stockStoreInfo.ModifiedBy);
            sqlCommand.Parameters.AddWithValue("CreatedDate", stockStoreInfo.CreatedDate);
            sqlCommand.Parameters.AddWithValue("ModifiedDate", stockStoreInfo.ModifiedDate);
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader sqlDataReadersqlDataReader = sqlCommand.ExecuteReader();
            sqlDataReadersqlDataReader.Read();
            sqlConnection.Close();
            return stockStoreInfo;
        }
        public StockStoreInfo UpdateStock(StockStoreInfo stockStoreInfo)
        {
            string Connection = _configuration.GetConnectionString("ShoppingDb");
            SqlConnection sqlConnection = new SqlConnection(Connection);
            string Query = "sp_Upsert";
            SqlCommand sqlCommand = new SqlCommand(Query);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@StocktId", stockStoreInfo.StocktId);
            sqlCommand.Parameters.AddWithValue("@ProductId", stockStoreInfo.ProductId);
            sqlCommand.Parameters.AddWithValue("@Quantity", stockStoreInfo.Quantity);
            sqlCommand.Parameters.AddWithValue("@CreatedBy", stockStoreInfo.CreatedBy);
            sqlCommand.Parameters.AddWithValue("@ModifiedBy", stockStoreInfo.ModifiedBy);
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            sqlDataReader.Read();
            sqlConnection.Close();

            return stockStoreInfo;
        }
        public void DeleteStock(long StocktId)
        {
            string Connection = _configuration.GetConnectionString("ShoppingDb");
            SqlConnection sqlConnection = new SqlConnection(Connection);
            string Query = "sp_DeleteStock";
            SqlCommand sqlCommand = new SqlCommand(Query);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue(@"StockId", StocktId);
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            dataReader.Read();
            sqlConnection.Close();
        }
    }
}
