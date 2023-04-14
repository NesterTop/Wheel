using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Wheel
{
    public class DataBase : IDisposable
    {
        public bool isConnected;
        private string _connectionString = @"Data Source=DESKTOP-A9MP2FF\SQLEXPRESS;Initial Catalog=wheels;Integrated Security=True";
        public SqlConnection _connection;

        public DataBase()
        {
            _connection = new SqlConnection(_connectionString);
            OpenConnection();
        }

        private void OpenConnection()
        {
            _connection.Open();
            isConnected = true;
        }

        private void CloseConnection()
        {
            _connection.Close();
            isConnected = false;
        }

        public DataTable ExecuteSql(string sql)
        {
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand(sql, _connection);
            table.Load(command.ExecuteReader());

            return table;
        }

        public bool ExecuteNonQuery(string sql)
        {
            try
            {
                SqlCommand command = new SqlCommand(sql, _connection);
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            CloseConnection();
        }
    }
}

