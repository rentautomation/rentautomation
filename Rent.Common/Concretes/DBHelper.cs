using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Rent.Common.Concretes
{
    /// <summary>
    ///     <english>
    ///         This static class helps for Database operations.
    ///     </english>
    ///     <turkish>
    ///         Bu statik sınıf Database işlemleri için yardımcı olmaktadır.
    ///     </turkish>
    /// </summary>
    public static class DBHelper
    {
        public static SqlConnection sqlConnection;
        public static SqlCommand sqlCommand;

        public static void Open()
        {
            if (sqlConnection == null)
                sqlConnection = new SqlConnection(DBHelper.GetConnectionString());
            sqlConnection.Open();
        }

        public static SqlCommand GetSqlCommand(string commandText)
        {
            sqlCommand = new SqlCommand(commandText, sqlConnection);
            return sqlCommand;
        }

        public static void Close()
        {
            sqlConnection.Close();
        }

        // Get connection string from .config file.
        public static string GetConnectionString()
        {
            return @"Data Source=DESKTOP-3A61024\SQLEXPRESS;Initial Catalog=rentautomationdatabase;Integrated Security=True";
        }

        

       
    }
}
