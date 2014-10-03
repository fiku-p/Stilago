using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace WebApplication1.DataAccess
{
    public static class DatabaseHelper
    {
        static SqlDataReader _dataReader;
        static SqlConnection _sqlConnection;
        static SqlCommand _sqlCommand;

        public static DataTable ExcecuteStoreProcedure(string storeProcedureName)
        {
            var result = new DataTable();

            using (_sqlCommand = new SqlCommand(storeProcedureName, _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString())))
            {
                _sqlConnection.Open();
                _sqlCommand.CommandType = CommandType.StoredProcedure;

                using (var rdr = _sqlCommand.ExecuteReader())
                {
                    result.Load(rdr);
                }
                _sqlConnection.Close();
            }

            return result;
        }

        public static void ExcecuteSaveStoreProcedure<T>(string storeProcedureName, T objectToSave) where T : class
        {
            using (_sqlCommand = new SqlCommand(storeProcedureName, _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString())))
            {
                //Open connection
                _sqlConnection.Open();
                _sqlCommand.CommandType = CommandType.StoredProcedure;

                //Get generic type properties
                PropertyInfo[] properties = typeof(T).GetProperties();

                //Mapp each property to appropriate SqlParameter
                foreach (var propertyInfo in properties)
                {
                    if (propertyInfo.Name != "id")
                    {
                        var paramenter = "@" + propertyInfo.Name;
                        _sqlCommand.Parameters.Add(new SqlParameter(paramenter, propertyInfo.GetValue(objectToSave, null)));
                    }
                }

                _sqlCommand.ExecuteNonQuery();
                _sqlConnection.Close();
            }
        }

        public static DataTable ExcecuteGetStoreProcedure(string storeProcedureName, int id)
        {
            var result = new DataTable();

            using (_sqlCommand = new SqlCommand(storeProcedureName, _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString())))
            {
                _sqlConnection.Open();

                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.Add(new SqlParameter("@id", id));

                using (var reader = _sqlCommand.ExecuteReader())
                {
                    result.Load(reader);
                }

                _sqlConnection.Close();
            }
            return result;
        }
    }
}
