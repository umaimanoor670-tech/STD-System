using System.Data.SqlClient;

namespace STD_SYSTEM.DataAccess
    {
        public class DBHelper
        {
            public static SqlConnection GetConnection()
            {
                return new SqlConnection( @"Data Source=DESKTOP-VOCMGLJ\SQLEXPRESS;Initial Catalog=STdb;Integrated Security=True;Encrypt=False"
                );
            }
        }
    }

