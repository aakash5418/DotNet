//Todo: Karthick Code Review

using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ShoppingCart.Store
{
    public interface IReturnStore
    {

        List<ReturnView> GetReturns();
        ReturnStoreInfo GetReturn(long ReturnID);

        ReturnStoreInfo AddReturn(ReturnStoreInfo returnStoreInfo);

        ReturnStoreInfo UpdateReturn(ReturnStoreInfo returnStoreInfo);

        void DeleteReturn(long ReturnID);


        public class _ReturnStore : IReturnStore
        {
            private readonly IConfiguration _configuration;

            public _ReturnStore(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public List<ReturnView> GetReturns()
            {
                string Connection = _configuration.GetConnectionString("ShoppingDb");
                List<ReturnView> purchases = new List<ReturnView>();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "RETURNSTORE";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                {
                    while (sqlDataReader.Read())
                    {
                        purchases.Add(new ReturnView
                        {
                            PurchaseID = Convert.ToInt64(sqlDataReader["PurchaseID"]),
                            ProductID = Convert.ToInt64(sqlDataReader["ProductID"]),
                            ProductName = sqlDataReader["ProductName"].ToString(),
                            ReturnedQuantity = Convert.ToInt16(sqlDataReader["ReturnedQuantity"]),
                            ReturnedTotalDiscount = Convert.ToDecimal(sqlDataReader["ReturnedTotalDiscount"]),
                            ReturnedTotalAmount = Convert.ToDecimal(sqlDataReader["ReturnedTotalAmount"]),
                            ReturnedDate = Convert.ToDateTime(sqlDataReader["ReturnedDate"]),
                            UnitPrice = Convert.ToDecimal(sqlDataReader["UnitPrice"]),
                            UnitDiscount = Convert.ToDecimal(sqlDataReader["UnitDiscount"]),
                        }); ;
                    }
                    sqlConnection.Close();
                }
                return purchases;

            }
            public ReturnStoreInfo GetReturn(long ReturnID)
            {
                string Connection = _configuration.GetConnectionString("ShoppingDb");
                ReturnStoreInfo purchases = new ReturnStoreInfo();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "sp_GetReturnId";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ReturnID", ReturnID);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                {
                    while (sqlDataReader.Read())
                    {
                        purchases = new ReturnStoreInfo()
                        {
                            ReturnID = Convert.ToInt64(sqlDataReader["ReturnID"]),
                            PurchaseID = Convert.ToInt64(sqlDataReader["PurchaseID"]),
                            ProductID = Convert.ToInt64(sqlDataReader["ProductID"]),
                            ReturnedQuantity = Convert.ToInt16(sqlDataReader["ReturnedQuantity"]),
                            ReturnedTotalDiscount = Convert.ToDecimal(sqlDataReader["ReturnedTotalDiscount"]),
                            ReturnedTotalAmount = Convert.ToDecimal(sqlDataReader["ReturnedTotalAmount"]),
                            ReturnedDate = Convert.ToDateTime(sqlDataReader["ReturnedDate"]),
                            CreatedBy = sqlDataReader["CreatedBy"].ToString(),
                            ModifiedBy = sqlDataReader["ModifiedBy"].ToString(),
                            CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]),
                            ModifiedDate = Convert.ToDateTime(sqlDataReader["ModifiedDate"])
                        };
                    }
                    sqlConnection.Close();
                }
                return purchases;
            }
            public ReturnStoreInfo AddReturn(ReturnStoreInfo returnStoreInfo)
            {
                string Connection = _configuration.GetConnectionString("ShoppingDb");
                ReturnStoreInfo purchases = new ReturnStoreInfo();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "SP_ADDRETURN";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@PurchaseID", returnStoreInfo.PurchaseID);
                sqlCommand.Parameters.AddWithValue("@ProductID", returnStoreInfo.ProductID);
                sqlCommand.Parameters.AddWithValue("@ReturnedQuantity", returnStoreInfo.ReturnedQuantity);
                sqlCommand.Parameters.AddWithValue("@CreatedBy", returnStoreInfo.CreatedBy);
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                sqlConnection.Close();

                return returnStoreInfo;
            }
            public ReturnStoreInfo UpdateReturn(ReturnStoreInfo returnStoreInfo)
            {
                string Connection = _configuration.GetConnectionString("ShoppingDb");
                ReturnStoreInfo purchases = new ReturnStoreInfo();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "sp_UpsertPurchase";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ReturnID", returnStoreInfo.ReturnID);
                sqlCommand.Parameters.AddWithValue("@PurchaseID", returnStoreInfo.PurchaseID);
                sqlCommand.Parameters.AddWithValue("@ProductID", returnStoreInfo.ProductID);
                sqlCommand.Parameters.AddWithValue("@ReturnedQuantity", returnStoreInfo.ReturnedQuantity);
                sqlCommand.Parameters.AddWithValue("@ReturnedTotalDiscount", returnStoreInfo.ReturnedTotalDiscount);
                sqlCommand.Parameters.AddWithValue("@ReturnedTotalAmount", returnStoreInfo.ReturnedTotalAmount);
                sqlCommand.Parameters.AddWithValue("@ReturnedDate", returnStoreInfo.ReturnedDate);
                sqlCommand.Parameters.AddWithValue("@CreatedBy", returnStoreInfo.CreatedBy);
                sqlCommand.Parameters.AddWithValue("ModifiedBy", returnStoreInfo.ModifiedBy);
                sqlCommand.Parameters.AddWithValue("CreatedDate", returnStoreInfo.CreatedDate);
                sqlCommand.Parameters.AddWithValue("ModifiedDate", returnStoreInfo.ModifiedDate);
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                sqlConnection.Close();

                return returnStoreInfo;
            }
            public void DeleteReturn(long ReturnID)
            {
                string Connection = _configuration.GetConnectionString("ShoppingDb");
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "DELETERETURN";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ReturnID", ReturnID);
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();
                sqlConnection.Close();
            }

        }
    }
}