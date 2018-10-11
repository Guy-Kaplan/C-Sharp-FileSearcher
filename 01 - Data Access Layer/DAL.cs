using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace JohnBryce
{
    // DAL = Data Access Layer
    public class DAL
    {
        private SqlConnection connection = new SqlConnection();

        public DAL() // ctor //+++++++++
        { // +++ To do: change the DB from ["Northwind"] to my DB (its name...) +++
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            //connection.ConnectionString = "Server=.\\SqlExpress;Database=Northwind;Trusted_Connection=True";
        }

        // Insert / Update / Delete
        public void Execute(SqlCommand command)
        {
            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        // Return any scalar from the DB
        public object GetScalar(SqlCommand command)
        {
            command.Connection = connection;
            connection.Open();
            object obj = command.ExecuteScalar();
            connection.Close();
            return obj;
        }
        public DataTable GetTable(SqlCommand command)
        {
            command.Connection = connection;
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }
    }
}

