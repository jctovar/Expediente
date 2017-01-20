using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Expediente.Database_classes
{
    class DatabaseConnection
    {
        public MySqlConnection GetConnection()
        {
            MySqlConnection conn = new MySqlConnection();

            string host = Properties.Settings.Default.host;
            string database = Properties.Settings.Default.database;
            string username = Properties.Settings.Default.user;
            string password = Properties.Settings.Default.password;

            string myConnectionString = String.Format("server={0};uid={1};pwd={2};database={3};", host, username, password, database);

            try
            {
                conn.ConnectionString = myConnectionString;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return conn;
        }
    }
}
