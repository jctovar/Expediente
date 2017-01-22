using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Expediente
{
    public partial class BaseDatos : Form
    {
        public BaseDatos()
        {
            InitializeComponent();
        }

        private void BaseDatos_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName;

            textBox1.Text = Properties.Settings.Default.host;
            textBox2.Text = Properties.Settings.Default.database;
            textBox3.Text = Properties.Settings.Default.user;
            textBox4.Text = Properties.Settings.Default.password;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.host = textBox1.Text;
            Properties.Settings.Default.database = textBox2.Text;
            Properties.Settings.Default.user = textBox3.Text;
            Properties.Settings.Default.password = textBox4.Text;
            Properties.Settings.Default.Save();

            Database_classes.DatabaseConnection mydatabase = new Database_classes.DatabaseConnection();
            MySqlConnection conn = null;

            try
            {
                conn = mydatabase.GetConnection();
                conn.Open();

                MessageBox.Show("La conexión a la base de datos fue satisfactoria!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Ocurrio el siguiente error {0}", ex.Message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }
    }
}
