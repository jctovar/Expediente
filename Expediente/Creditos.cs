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
    public partial class Creditos : Form
    {
        public Creditos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Creditos_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName;

            label1.Text = Application.ProductName;
            label2.Text = Application.ProductVersion;
            label3.Text = Application.CompanyName;
        }
    }
}
