using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Expediente.Database_classes
{
    class AccountDB
    {
        public Object_classes.Account GetAccount(int Id)
        {
            Object_classes.Account account = new Object_classes.Account();
            DatabaseConnection mydatabase = new DatabaseConnection();
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            string sql = "SELECT * FROM accouunts WHERE account_id = ?id";

            try
            {
                conn = mydatabase.GetConnection();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add(new MySqlParameter("id", Id));

                conn.Open();

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        account.Firstname = reader.GetString("account_firstname");
                        account.Lastname = reader.GetString("account_lastname");
                        account.Username = reader.GetString("account_username");
                        account.Email = reader.GetString("account_email");
                        account.Password = reader.GetString("account_password");
                    }
                }
                else
                {
                    account = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null) reader.Close();
                if (conn != null) conn.Close();
            }

            return account;
        }
        public Object_classes.Account Authentication(string username, string password)
        {
            Object_classes.Account account = new Object_classes.Account();
            DatabaseConnection mydatabase = new DatabaseConnection();
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            string sql = "SELECT * FROM accounts WHERE account_username = ?username AND account_password = ?password AND account_enable = 1 LIMIT 1";

            try
            {
                conn = mydatabase.GetConnection();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add(new MySqlParameter("username", username));
                cmd.Parameters.Add(new MySqlParameter("password", password));

                conn.Open();

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        account.Firstname = reader.GetString("account_firstname");
                        account.Lastname = reader.GetString("account_lastname");
                        account.Username = reader.GetString("account_username");
                        account.Email = reader.GetString("account_email");
                        account.Password = reader.GetString("account_password");
                    }
                }
                else
                {
                    account = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null) reader.Close();
                if (conn != null) conn.Close();
            }

            return account;
        }

        public DataTable AccountGetList()
        {
            DataTable dt = new DataTable();
            DatabaseConnection mydatabase = new DatabaseConnection();
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            string sql = "SELECT * FROM accounts"; ;

            try
            {
                conn = mydatabase.GetConnection();
                cmd = new MySqlCommand(sql, conn);

                conn.Open();

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null) reader.Close();
                if (conn != null) conn.Close();
            }

            return dt;
        }
    }
}
