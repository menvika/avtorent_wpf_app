using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace interf
{
    internal class Database
    {
        // Подключение базы данных AVTORENT.
        public SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-4SP2QQQ\SQLSERVER;Initial Catalog=AVTORENT; Integrated Security = True");
        
            //public SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-PARFATM;Initial Catalog=AVTORENT; Integrated Security = True");
        // Открытие БД.
        public void OpenConnection()
        { 
            if (sqlConnection.State == System.Data.ConnectionState.Closed) 
            {
                sqlConnection.Open();
            }
        }
        // Закрытие БД.
        public void CloseConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        // Возвращение строки подключения.
        public SqlConnection GetConnection()
        { 
            return sqlConnection;
        }
    }
}
