using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            try
            {
                Properties.Settings.Default.host = textBox1.Text;
                Properties.Settings.Default.database = textBox2.Text;
                Properties.Settings.Default.user = textBox3.Text;
                Properties.Settings.Default.password = textBox4.Text;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Close();
            }
        }
    }
}
