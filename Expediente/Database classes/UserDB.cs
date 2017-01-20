using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Expediente.Database_classes
{
    class UserDB
    {
        public Object_classes.User GetUser(string username)
        {
            Object_classes.User user = new Object_classes.User();
            DatabaseConnection mydatabase = new DatabaseConnection();
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            string sql = "SELECT * FROM alumnos_suayed WHERE ch_alumno_num_cta = ?username";

            try
            {
                conn = mydatabase.GetConnection();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add(new MySqlParameter("username", username));

                conn.Open();

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user.Firstname = reader.GetString("ch_persona_nombre");
                        user.Lastname = reader.GetString("ch_persona_appaterno") + " " + reader.GetString("ch_persona_apmaterno");
                        user.Email = reader.GetString("ch_persona_email");
                        user.Headquarters = reader.GetString("ch_dependencia_nombre");
                        user.Generation = reader.GetString("nu_alumno_ingreso");
                        user.Field = reader.GetString("ch_plan_cve");
                        user.Curp = reader.GetString("ch_persona_curp");
                        user.Phone = reader.GetString("ch_persona_telefono");
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
    }
}
