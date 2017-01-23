using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Expediente.Database_classes
{
    class UserDB
    {
        public Object_classes.User GetUser(int Id)
        {
            Object_classes.User user = new Object_classes.User();
            DatabaseConnection mydatabase = new DatabaseConnection();
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            string sql = "SELECT * FROM users WHERE user_id = ?id";

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
                        user.Id = reader.GetInt16("user_id");
                        user.Firstname = reader.GetString("user_firstname");
                        user.Lastname = reader.GetString("user_lastname");
                        user.Email = reader.GetString("user_email");
                        user.Birthday = reader.GetDateTime("user_birthday");
                        user.Gender = reader.GetInt16("gender_id");
                    }
                }
                else
                {
                    user = null;
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

            return user;
        }

        public DataTable UserGetList()
        {
            DataTable dt = new DataTable();
            DatabaseConnection mydatabase = new DatabaseConnection();
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            string sql = "SELECT user_id,user_firstname,user_lastname,user_email FROM users ORDER BY user_id DESC";

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

        public Boolean UpdateUser(Object_classes.User user)
        {
            DataTable dt = new DataTable();
            DatabaseConnection mydatabase = new DatabaseConnection();
            MySqlConnection conn = null;
            MySqlCommand cmd = null;

            string sql = "UPDATE users SET user_firstname=?firstname, user_lastname=?lastname, user_email=?email, gender_id=?gender, user_birthday=?birthday WHERE user_id = ?id";

            try
            {
                conn = mydatabase.GetConnection();
                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.Add(new MySqlParameter("id", user.Id));
                cmd.Parameters.Add(new MySqlParameter("firstname", user.Firstname));
                cmd.Parameters.Add(new MySqlParameter("lastname", user.Lastname));
                cmd.Parameters.Add(new MySqlParameter("email", user.Email));
                cmd.Parameters.Add(new MySqlParameter("gender", user.Gender));
                cmd.Parameters.Add(new MySqlParameter("birthday", user.Birthday));

                conn.Open();

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        public Boolean AddUser(Object_classes.User user)
        {
            DataTable dt = new DataTable();
            DatabaseConnection mydatabase = new DatabaseConnection();
            MySqlConnection conn = null;
            MySqlCommand cmd = null;

            string sql = "INSERT users SET user_firstname=?firstname, user_lastname=?lastname, user_email=?email, gender_id=?gender, user_birthday=?birthday;";

            try
            {
                conn = mydatabase.GetConnection();
                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.Add(new MySqlParameter("id", user.Id));
                cmd.Parameters.Add(new MySqlParameter("firstname", user.Firstname));
                cmd.Parameters.Add(new MySqlParameter("lastname", user.Lastname));
                cmd.Parameters.Add(new MySqlParameter("email", user.Email));
                cmd.Parameters.Add(new MySqlParameter("gender", user.Gender));
                cmd.Parameters.Add(new MySqlParameter("birthday", user.Birthday));

                conn.Open();

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        public DataTable GenderGetList()
        {
            DataTable dt = new DataTable();
            DatabaseConnection mydatabase = new DatabaseConnection();
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            string sql = "SELECT * FROM gender ORDER BY gender_id"; ;

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
